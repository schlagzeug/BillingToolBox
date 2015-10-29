using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using BillingToolBox.Classes;
using System.IO;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Threading;
using System.Data.SqlClient;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;

namespace BillingToolBox.Windows
{
    /// <summary>
    /// Interaction logic for MergeDB.xaml
    /// </summary>
    public partial class MergeDB : Window
    {
        List<string> badSQLFiles = new List<string>();

        public MergeDB()
        {
            InitializeComponent();

            Log.WriteToLog("Populating Databases");
            PopulateDatabaseComboBox();
            checkBox_MergeDB_GetLatest.IsChecked = true;
            button_MergeDB_OpenFiles.IsEnabled = false;
            button_MergeDB_RunFailed.IsEnabled = false;
            PopulateConnectionStringLabel();
        }


        private void button_MergeDB_GetList_Click(object sender, RoutedEventArgs e)
        {
            PopulateDatabaseComboBox();
        }

        private void PopulateDatabaseComboBox()
        {
            comboBox_MergeDB_Databases.Items.Clear();
            var databases = Tools.GetDatabases();
            foreach (var database in databases)
            {
                comboBox_MergeDB_Databases.Items.Add(database);
            }
            if (comboBox_MergeDB_Databases.Items.Count > 0)
                comboBox_MergeDB_Databases.SelectedIndex = 0;
        }

        private void PopulateConnectionStringLabel()
        {
            textBox_MergeDB_Server.Text = GetServerFromConnectionString();
        }

        private void button_MergeDB_Run_Click(object sender, RoutedEventArgs e)
        {
            textBox_MergeDB_Output.Text = string.Empty;
            RunMerge();
        }

        private void ParseErrors()
        {
            SetLabelText(string.Format("{0} Errors", badSQLFiles.Count));
            if (badSQLFiles.Count > 0)
                ToggleMergeRunFailedButton(true);
            ToggleMergeOpenFileButton(true);
        }

        private void ToggleMergeRunFailedButton(bool enabled)
        {
            if (button_MergeDB_RunFailed.Dispatcher.CheckAccess())
            {
                button_MergeDB_RunFailed.IsEnabled = enabled;
            }
            else
            {
                this.Dispatcher.Invoke((Action)(() =>
                {
                    button_MergeDB_RunFailed.IsEnabled = enabled;
                }));
            }
        }

        private void ToggleMergeOpenFileButton(bool enabled)
        {
            if (button_MergeDB_OpenFiles.Dispatcher.CheckAccess())
            {
                button_MergeDB_OpenFiles.IsEnabled = enabled;
            }
            else
            {
                this.Dispatcher.Invoke((Action)(() =>
                {
                    button_MergeDB_OpenFiles.IsEnabled = enabled;
                }));
            }
        }

        private void SetLabelText(string text)
        {
            if (label_MergeDB_ErrorStats.Dispatcher.CheckAccess())
            {
                label_MergeDB_ErrorStats.Content = text;
                label_MergeDB_ErrorStats.UpdateLayout();
            }
            else
            {
                this.Dispatcher.Invoke((Action)(() =>
                {
                    label_MergeDB_ErrorStats.Content = text;
                    label_MergeDB_ErrorStats.UpdateLayout();
                }));
            }
        }

        private void RunMerge()
        {
            ToggleMergeRunButton(false);
            ToggleMergeOpenFileButton(false);
            ToggleMergeRunFailedButton(false);
            ToggleCheckBoxes(false);
            ToggleFolderButton(false);
            var getLatest = checkBox_MergeDB_GetLatest.IsChecked;
            var force = (checkBox_MergeDB_ForceGet.IsChecked == true) ? " /force " : string.Empty;
            var connString = BillingToolBoxSettings.Default.ConnectionString.Replace("Provider=SQLOLEDB.1;", string.Empty);
            connString = connString.Replace("Initial Catalog=master;", string.Format("Initial Catalog={0};", comboBox_MergeDB_Databases.SelectedItem));
            badSQLFiles = new List<string>();

            Task.Factory.StartNew(() =>
            {
                try
                {
                    if (getLatest == true)
                    {
                        SetLabelText("Getting latest...");
                        var p = new Process();
                        p.StartInfo.FileName = @"C:\Program Files (x86)\Microsoft Visual Studio 10.0\Common7\IDE\TF.EXE";

                        p.StartInfo.Arguments = string.Format("get \"{0}\"{1}/recursive", BillingToolBoxSettings.Default.BDD_Directory, force);
                        WriteToMergeDBOutput(string.Format("Running: {0} {1}", p.StartInfo.FileName, p.StartInfo.Arguments));

                        p.StartInfo.UseShellExecute = false;
                        p.StartInfo.CreateNoWindow = true;
                        p.StartInfo.RedirectStandardOutput = true;
                        p.StartInfo.RedirectStandardError = true;
                        p.OutputDataReceived += new DataReceivedEventHandler(MergeDBOutputHandler);
                        p.Start();
                        p.BeginOutputReadLine();
                        p.BeginErrorReadLine();

                        p.WaitForExit();
                        WriteToMergeDBOutput("Finished getting latest.\r\n");
                    }

                    SetLabelText("Running DB files...");

                    foreach (var path in BillingToolBoxSettings.Default.MergeFolders)
                    {
                        var directory = Path.Combine(BillingToolBoxSettings.Default.BDD_Directory, path);
                        var titleString = "Running Files in: " + directory;
                        var spacer = "".PadRight(titleString.Length + 1, '-');
                        WriteToMergeDBOutput(string.Format("{0}\r\n{1}\r\n{0}", spacer, titleString));
                        var di = new DirectoryInfo(directory);
                        var files = di.GetFiles("*.sql", SearchOption.AllDirectories);
                        var connection = new SqlConnection(connString);
                        var server = new Server(new ServerConnection(connection));
                        foreach (var fileInfo in files)
                        {
                            var sqlScriptWorker = new SQLScriptWorker();

                            var workerThread = new Thread(() => sqlScriptWorker.RunScript(fileInfo, server));
                            workerThread.Start();
                            while (sqlScriptWorker.statusMessage == string.Empty)
                            {
                                Thread.Sleep(1);
                            }
                            workerThread.Join();
                            WriteToMergeDBOutput(sqlScriptWorker.statusMessage);
                            if (sqlScriptWorker.statusMessage.StartsWith("Error"))
                                badSQLFiles.Add(fileInfo.FullName);
                        }
                    }

                    WriteToMergeDBOutput("\r\n\r\nMerge finished.");
                }
                catch (Exception ex)
                {
                    Dispatcher.Invoke((Action)(() =>
                    {
                        Tools.ShowErrorPopUpModal(ex.Message);
                        Log.WriteToLog(ex.Message);
                    }));
                }
                finally
                {
                    ToggleMergeRunButton(true);
                    ToggleCheckBoxes(true);
                    ToggleFolderButton(true);
                    ParseErrors();
                }
            });
        }

        private void MergeDBOutputHandler(object sendingProcess, DataReceivedEventArgs outLine)
        {
            if (!String.IsNullOrEmpty(outLine.Data))
            {
                WriteToMergeDBOutput(outLine.Data);
            }
        }

        private void WriteToMergeDBOutput(string output)
        {
            if (textBox_MergeDB_Output.Dispatcher.CheckAccess())
            {
                textBox_MergeDB_Output.Text += output + "\r\n";
                textBox_MergeDB_Output.UpdateLayout();
                textBox_MergeDB_Output.ScrollToEnd();
            }
            else
            {
                Dispatcher.Invoke((Action)(() =>
                {
                    textBox_MergeDB_Output.Text += output + "\r\n";
                    textBox_MergeDB_Output.UpdateLayout();
                    textBox_MergeDB_Output.ScrollToEnd();
                }));
            }
        }

        private void ToggleMergeRunButton(bool enabled)
        {
            if (button_MergeDB_Run.Dispatcher.CheckAccess())
            {
                button_MergeDB_Run.IsEnabled = enabled;
            }
            else
            {
                Dispatcher.Invoke((Action)(() =>
                {
                    button_MergeDB_Run.IsEnabled = enabled;
                }));
            }
        }

        private void ToggleFolderButton(bool enabled)
        {
            if (button_SetFolders.Dispatcher.CheckAccess())
            {
                button_SetFolders.IsEnabled = enabled;
            }
            else
            {
                Dispatcher.Invoke((Action)(() =>
                {
                    button_SetFolders.IsEnabled = enabled;
                }));
            }
        }

        private void ToggleCheckBoxes(bool enabled)
        {
            if (checkBox_MergeDB_GetLatest.Dispatcher.CheckAccess())
            {
                checkBox_MergeDB_GetLatest.IsEnabled = enabled;
                if (checkBox_MergeDB_GetLatest.IsChecked == true)
                {
                    ToggleForceGet(enabled);
                }
            }
            else
            {
                Dispatcher.Invoke((Action)(() =>
                {
                    checkBox_MergeDB_GetLatest.IsEnabled = enabled;
                    if (checkBox_MergeDB_GetLatest.IsChecked == true)
                    {
                        ToggleForceGet(enabled);
                    }

                }));
            }
        }

        private void ToggleForceGet(bool enabled)
        {
            if (checkBox_MergeDB_ForceGet.Dispatcher.CheckAccess())
            {
                checkBox_MergeDB_ForceGet.IsEnabled = enabled;
            }
            else
            {
                Dispatcher.Invoke((Action)(() =>
                {
                    checkBox_MergeDB_ForceGet.IsEnabled = enabled;
                }));
            }
        }

        private static string GetServerFromConnectionString()
        {
            var returnValue = BillingToolBoxSettings.Default.ConnectionString;
            returnValue = returnValue.Substring(returnValue.IndexOf("Data Source"));
            returnValue = returnValue.Substring(returnValue.IndexOf("=") + 1).Trim();
            return returnValue;
        }

        private void checkBox_MergeDB_GetLatest_Checked(object sender, RoutedEventArgs e)
        {
            checkBox_MergeDB_ForceGet.IsEnabled = true;
        }

        private void checkBox_MergeDB_ForceGet_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void checkBox_MergeDB_GetLatest_Unchecked(object sender, RoutedEventArgs e)
        {
            checkBox_MergeDB_ForceGet.IsEnabled = false;
        }

        private void button_MergeDB_OpenFiles_Click(object sender, RoutedEventArgs e)
        {
            if (badSQLFiles.Count < 1) Tools.ShowErrorPopUpModal("No files to open.");
            else
            {
                foreach (var badSqlFile in badSQLFiles)
                {
                    Tools.OpenFile(badSqlFile);
                }
            }
        }

        private void button_MergeDB_RunFailed_Click(object sender, RoutedEventArgs e)
        {
            textBox_MergeDB_Output.Text = string.Empty;

            ToggleMergeRunButton(false);
            ToggleMergeOpenFileButton(false);
            ToggleCheckBoxes(false);
            var connString = BillingToolBoxSettings.Default.ConnectionString.Replace("Provider=SQLOLEDB.1;", string.Empty);
            connString = connString.Replace("Initial Catalog=master;", string.Format("Initial Catalog={0};", comboBox_MergeDB_Databases.SelectedItem));
            var badSQLFiles2 = new List<string>();

            Task.Factory.StartNew(() =>
            {
                try
                {
                    SetLabelText("Running DB files...\r\n");
                    var connection = new SqlConnection(connString);
                    var server = new Server(new ServerConnection(connection));
                    foreach (var badSqlFile in badSQLFiles)
                    {
                        var fileInfo = new FileInfo(badSqlFile);
                        var sqlScriptWorker = new SQLScriptWorker();
                        var workerThread = new Thread(() => sqlScriptWorker.RunScript(fileInfo, server));
                        workerThread.Start();
                        while (sqlScriptWorker.statusMessage == string.Empty)
                        {
                            Thread.Sleep(1);
                        }
                        workerThread.Join();
                        WriteToMergeDBOutput(sqlScriptWorker.statusMessage);
                        if (sqlScriptWorker.statusMessage.StartsWith("Error"))
                            badSQLFiles2.Add(fileInfo.FullName);
                    }

                    WriteToMergeDBOutput("\r\n\r\nMerge finished.");
                }
                catch (Exception ex)
                {
                    this.Dispatcher.Invoke((Action)(() =>
                    {
                        Tools.ShowErrorPopUpModal(ex.Message);
                        Log.WriteToLog(ex.Message);
                    }));
                }
                finally
                {
                    badSQLFiles = new List<string>();
                    foreach (var badSqlFile in badSQLFiles2)
                    {
                        badSQLFiles.Add(badSqlFile);
                    }
                    ToggleMergeRunButton(true);
                    ToggleCheckBoxes(true);
                    ParseErrors();
                }
            });
        }

        private void comboBox_MergeDB_Databases_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            textBox_MergeDB_Output.Text = string.Empty;
            label_MergeDB_ErrorStats.Content = string.Empty;
            ToggleMergeRunFailedButton(false);
            ToggleMergeOpenFileButton(false);
        }

        private void button_SetFolders_Click(object sender, RoutedEventArgs e)
        {
            var x = new BDDFolderSelect();
            x.ShowDialog();
        }

    }
}
