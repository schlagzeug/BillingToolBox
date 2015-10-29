using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Xml.Linq;
using BillingToolBox.Classes;
using BillingToolBox.Windows;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;
using Insurity.Billing.Library.Enumerations;

namespace BillingToolBox
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CommandsAndArgs commandsAndArgs = new CommandsAndArgs();
        List<string> badSQLFiles = new List<string>();
        Dictionary<string, List<EnumSet>> EnumSets = new Dictionary<string, List<EnumSet>>();
        //private TestClass test = new TestClass();
        //private BackgroundWorker worker = new BackgroundWorker();
        DispatcherTimer servicesRefreshTimer = new DispatcherTimer();

        public MainWindow()
        {
            Log.WriteToLog("\r\n=============Beginning Log {0}=============\r\n", DateTime.Now.ToString("hh:mm:ss"));
            Log.WriteToLog("Starting up...");
            InitializeComponent();

            Log.WriteToLog("Setting up run test combo boxes");
            SetUpRunTestComboBoxes();

            Log.WriteToLog("Loading services");
            LoadServices();

            //Log.WriteToLog("Loading processes");
            //LoadProcesses();

            //Log.WriteToLog("Populating Databases");
            //PopulateDatabaseComboBox();
            //checkBox_MergeDB_GetLatest.IsChecked = true;
            //button_MergeDB_OpenFiles.IsEnabled = false;
            //button_MergeDB_RunFailed.IsEnabled = false;

            //PopulateConnectionStringLabel();
            GetLatestBillingLibraryDll();
            SetUpLists();

            servicesRefreshTimer.Tick += new EventHandler(ServicesRefreshTimerTick);
            servicesRefreshTimer.Interval = new TimeSpan(0, 0, 0, 1);
            if (Debugger.IsAttached) servicesRefreshTimer.Interval = new TimeSpan(0, 0, 0, 10);
            servicesRefreshTimer.Start();
            
            Log.WriteToLog("Main window initialized");
            
            //worker.DoWork += new DoWorkEventHandler(test.DoWork);
            //worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(test.Complete);
            //worker.RunWorkerAsync();
        }

        private void ServicesRefreshTimerTick(object sender, EventArgs e)
        {
            LoadServices();
        }

        protected override void OnClosed(EventArgs e)
        {
            Log.WriteToLog("\r\n==============Closing Log {0}==============\r\n", DateTime.Now.ToString("hh:mm:ss"));
            Log.CloseLog();
            base.OnClosed(e);
        }

        #region Menu

        #region Logs
        private void menu_Logs_Local_Click(object sender, RoutedEventArgs e)
        {
            Tools.OpenDirectory(@"C:\Logs");
        }

        private void menu_Logs_Current_Click(object sender, RoutedEventArgs e)
        {
            Log.OpenCurrentLogFile();
        }

        private void menu_Logs_ToolBox_Directory_Click(object sender, RoutedEventArgs e)
        {
            Log.OpenLogDirectory();
        }

        private void menu_Logs_Billing_DailyBuilds_Click(object sender, RoutedEventArgs e)
        {
            Tools.OpenDirectory(@"\\filer01\DailyBuilds\LOGS");
        }
        #endregion Logs

        private void menu_Database_ViewTable_Click(object sender, RoutedEventArgs e)
        {
            var x = new DatabaseTableViewer();
            x.Show();
        }

        #endregion Menu

        #region Service Tab

        private void LoadServices()
        {
            var serviceInfos = GetServiceInfos();
            int? sortColumnNum = null;
            ListSortDirection? sortColumnDirection = null;
            var selectedIndex = dataGrid_Services.SelectedIndex;
            var hasFocus = dataGrid_Services.IsFocused || dataGrid_Services.IsKeyboardFocused ||
                           dataGrid_Services.IsKeyboardFocusWithin;

            for (int i = 0; i < dataGrid_Services.Columns.Count; i++)
            {
                if (dataGrid_Services.Columns[i].SortDirection != null)
                {
                    sortColumnNum = i;
                    sortColumnDirection = dataGrid_Services.Columns[i].SortDirection;
                    break;
                }
            }

            dataGrid_Services.ItemsSource = serviceInfos;

            if (sortColumnNum != null && sortColumnDirection != null)
            {
                Tools.SortDataGrid(dataGrid_Services, sortColumnNum.GetValueOrDefault(),
                                   sortColumnDirection.GetValueOrDefault());
            }

            dataGrid_Services.SelectedIndex = selectedIndex;
            //if (hasFocus) dataGrid_Services.Focus();

        }

        private IEnumerable<ServiceInfo> GetServiceInfos()
        {
            var serviceInfos = new List<ServiceInfo>();
            foreach (var service in BillingToolBoxSettings.Default.Services)
            {
                var controller = new ServiceController(service);
                var si = new ServiceInfo { Name = service, Status = controller.Status.ToString() };
                serviceInfos.Add(si);
            }

            return serviceInfos;
        }

        private void button_Services_Refresh_Click(object sender, RoutedEventArgs e)
        {
            LoadServices();
        }

        private void button_Services_StartStop_Click(object sender, RoutedEventArgs e)
        {
            StartOrStopService();
            LoadServices();
        }

        private void StartOrStopService()
        {
            foreach (var service in dataGrid_Services.SelectedItems)
            {
                var si = (ServiceInfo)service;
                var controller = new ServiceController(si.Name);
                if (controller.Status == ServiceControllerStatus.Stopped)
                {
                    try
                    {
                        controller.Start();
                    }
                    catch (Exception exception)
                    {
                        Log.WriteToLog("Error is {0}", exception.Message);
                    }
                }
                else
                {
                    if (controller.CanStop)
                    {
                        try
                        {
                            controller.Stop();
                        }
                        catch (Exception exception)
                        {
                            Log.WriteToLog("Error is {0}", exception.Message);
                        }
                    }
                }
            }
        }

        private void button_Services_Edit_Click(object sender, RoutedEventArgs e)
        {
            var x = new ServiceEditWindow();
            x.ShowDialog();
            LoadServices();
        }

        private void dataGrid_Services_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            StartOrStopService();
            LoadServices();
        }

        #endregion Service Tab
        
        #region Run Test
        
        //private void button_RunTest_BDCentralConfig_Click(object sender, RoutedEventArgs e)
        //{
        //    var x = new BDCentralConfigEditor();
        //    x.Show();
        //}

        private void SetUpRunTestComboBoxes()
        {
            comboBox_RunTest_Commands.Items.Clear();
            comboBox_RunTest_Argument.Items.Clear();

            commandsAndArgs.PopulateCommandTable();

            foreach (var commandSet in commandsAndArgs.CommandTable)
            {
                comboBox_RunTest_Commands.Items.Add(commandSet.Key);
            }

            if (comboBox_RunTest_Commands.Items.Count > 0)
            {
                comboBox_RunTest_Commands.SelectedIndex = 0;
            }
        }
        
        private void comboBox_RunTest_Argument_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBox_RunTest_Argument.SelectedItem == null) return;
            SetFullCommand();
        }

        private void SetFullCommand()
        {
            textBox_RunTest_FullCommand.Text = string.Empty;
            textBox_RunTest_FullCommand.Text = string.Format("{0} {1}", comboBox_RunTest_Commands.SelectedItem, comboBox_RunTest_Argument.SelectedItem);
            textBox_RunTest_FullCommand.Focus();
            textBox_RunTest_FullCommand.CaretIndex = textBox_RunTest_FullCommand.Text.Length;
            textBox_RunTest_FullCommand.ScrollToEnd();
        }

        private void comboBox_RunTest_Commands_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBox_RunTest_Commands.SelectedItem == null) return;
            SetArgumentComboBox();
            SetFullCommand();
        }

        private void SetArgumentComboBox()
        {
            comboBox_RunTest_Argument.IsEnabled = true;
            comboBox_RunTest_Argument.Items.Clear();
            foreach (var argument in commandsAndArgs.CommandTable[comboBox_RunTest_Commands.SelectedItem.ToString()])
            {
                comboBox_RunTest_Argument.Items.Add(argument);
            }

            if (comboBox_RunTest_Argument.Items.Count > 0)
                comboBox_RunTest_Argument.SelectedIndex = 0;
            else
                comboBox_RunTest_Argument.IsEnabled = false;
        }

        private void button_RunTest_Run_Click(object sender, RoutedEventArgs e)
        {
            string command = string.Empty;
            string args = string.Empty;

            if (textBox_RunTest_FullCommand.Text.Contains(" "))
            {
                command = textBox_RunTest_FullCommand.Text.Substring(0, textBox_RunTest_FullCommand.Text.IndexOf(' '));
                args = textBox_RunTest_FullCommand.Text.Substring(textBox_RunTest_FullCommand.Text.IndexOf(' '));
            }
            else
            {
                command = textBox_RunTest_FullCommand.Text;
            }

            if (!File.Exists(command))
            {
                if (Directory.Exists(command))
                    Tools.OpenDirectory(command);
                else
                    Tools.ShowErrorPopUpModal("Command is invalid");
                return;
            }

            // everything should be good to go
            try
            {
                string spacer = "".PadRight(textBox_RunTest_FullCommand.Text.Length + 1, '-');
                //string spacer = "----------------------------------------------------------------------------------------------------------";
                WriteToRunTestOutput(string.Format("{0}\r\n{1} Running:\r\n{2} {3}\r\n{0}", spacer, DateTime.Now.ToString("HH:mm:ss"), command, args));
                ToggleRunButton(false);
                Task.Factory.StartNew(() =>
                {
                    try
                    {
                        var p = new Process();
                        p.StartInfo.FileName = command;
                        p.StartInfo.Arguments = args;
                        p.StartInfo.UseShellExecute = false;
                        p.StartInfo.CreateNoWindow = true;
                        p.StartInfo.RedirectStandardOutput = true;
                        p.StartInfo.RedirectStandardError = true;
                        p.OutputDataReceived += new DataReceivedEventHandler(TextOutputHandler);
                        p.Start();
                        p.BeginOutputReadLine();
                        p.BeginErrorReadLine();

                        p.WaitForExit();
                        
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
                        WriteToRunTestOutput(string.Format("\r\n{0}\r\n{1} Finished:\r\n{2} {3}\r\n{0}", spacer,
                                                           DateTime.Now.ToString("HH:mm:ss"), command, args));
                        ToggleRunButton(true);
                    }
                });
            }
            catch (Exception ex)
            {
                Tools.ShowErrorPopUpModal(ex.Message);
                Log.WriteToLog(ex.Message);
            }
        }

        private void TextOutputHandler(object sendingProcess, DataReceivedEventArgs outLine)
        { 
            if (!String.IsNullOrEmpty(outLine.Data))
            {
                WriteToRunTestOutput(outLine.Data);
            }
        }

        private void ToggleRunButton(bool enabled)
        {
            if (button_RunTest_Run.Dispatcher.CheckAccess())
            {
                button_RunTest_Run.IsEnabled = enabled;
            }
            else
            {
                this.Dispatcher.Invoke((Action)(() =>
                {
                    button_RunTest_Run.IsEnabled = enabled;
                }));
            }
        }

        private void WriteToRunTestOutput(string output)
        {
            if (textBox_RunTest_Output.Dispatcher.CheckAccess())
            {
                textBox_RunTest_Output.Text += output + "\r\n";
                textBox_RunTest_Output.UpdateLayout();
                textBox_RunTest_Output.ScrollToEnd();
            }
            else
            {
                this.Dispatcher.Invoke((Action)(() =>
                {
                    textBox_RunTest_Output.Text += output + "\r\n";
                    textBox_RunTest_Output.UpdateLayout();
                    textBox_RunTest_Output.ScrollToEnd();
                }));
            }
        }

        private void button_RunTest_Customize_Click(object sender, RoutedEventArgs e)
        {
            var x = new CustomizeCommandsAndArgumentsWindow();
            x.ShowDialog();
            SetUpRunTestComboBoxes();
        }

        #endregion Run Test

        #region Merge DB (TO REMOVE)
        
        //private void button_MergeDB_GetList_Click(object sender, RoutedEventArgs e)
        //{
        //    PopulateDatabaseComboBox();
        //}

        //private void PopulateDatabaseComboBox()
        //{
        //    //BillingToolBoxSettings.Default.ConnectionString = textBox_MergeDB_ConnectionString.Text;
        //    comboBox_MergeDB_Databases.Items.Clear();
        //    var databases = Tools.GetDatabases();
        //    foreach (var database in databases)
        //    {
        //        comboBox_MergeDB_Databases.Items.Add(database);
        //    }
        //    if (comboBox_MergeDB_Databases.Items.Count > 0)
        //        comboBox_MergeDB_Databases.SelectedIndex = 0;
        //}

        //private void PopulateConnectionStringLabel()
        //{
        //    textBox_MergeDB_ConnectionString.Text = BillingToolBoxSettings.Default.ConnectionString;
        //    textBox_MergeDB_Server.Text = GetServerFromConnectionString();
        //}

        //private void button_MergeDB_Run_Click(object sender, RoutedEventArgs e)
        //{
        //    //MergeDatabaseCMDFile();
        //    MergeDatabaseCSharp();
        //}

        //private void MergeDatabaseCMDFile()
        //{
        //    FileStream stream = File.Open("Merge.cmd", FileMode.Open);
        //    StreamReader reader = new StreamReader(stream);
        //    string fileContent = reader.ReadToEnd();
        //    reader.Close();
        //    stream.Close();

        //    string dataBase = comboBox_MergeDB_Databases.SelectedItem.ToString();
        //    string server = textBox_MergeDB_Server.Text;
        //    if (string.IsNullOrEmpty(dataBase) || string.IsNullOrEmpty(server))
        //    {
        //        Tools.ShowErrorPopUpModal("Database or server not found.");
        //        return;
        //    }
        //    fileContent = fileContent.Replace("<DATABASE>", dataBase);
        //    fileContent = fileContent.Replace("<SERVER>", server);

        //    stream = File.Open("MergeEdit.cmd", FileMode.OpenOrCreate);
        //    StreamWriter writer = new StreamWriter(stream);
        //    writer.Write(fileContent);
        //    writer.Close();
        //    stream.Close();

        //    Process.Start("MergeEdit.cmd");
        //}

        //private void MergeDatabaseCSharp()
        //{
        //    textBox_MergeDB_Output.Text = string.Empty;
        //    RunThisStuff();
        //    //if (badSQLFiles.Count > 0)
        //    //    button_MergeDB_RunFailed.IsEnabled = true;
        //    //ToggleMergeRunButton(false);
        //    //GetLatestBDDFromTFS();
        //    //RunBDDFiles();
        //    //ToggleMergeRunButton(true);
        //}

        //private void ParseErrors()
        //{
        //    SetLabelText(string.Format("{0} Errors", badSQLFiles.Count));
        //    if (badSQLFiles.Count > 0)
        //        ToggleMergeRunFailedButton(true);
        //    ToggleMergeOpenFileButton(true);
        //}

        //private void ToggleMergeRunFailedButton(bool enabled)
        //{
        //    if (button_MergeDB_RunFailed.Dispatcher.CheckAccess())
        //    {
        //        button_MergeDB_RunFailed.IsEnabled = enabled;
        //    }
        //    else
        //    {
        //        this.Dispatcher.Invoke((Action)(() =>
        //        {
        //            button_MergeDB_RunFailed.IsEnabled = enabled;
        //        }));
        //    }
        //}

        //private void ToggleMergeOpenFileButton(bool enabled)
        //{
        //    if (button_MergeDB_OpenFiles.Dispatcher.CheckAccess())
        //    {
        //        button_MergeDB_OpenFiles.IsEnabled = enabled;
        //    }
        //    else
        //    {
        //        this.Dispatcher.Invoke((Action)(() =>
        //        {
        //            button_MergeDB_OpenFiles.IsEnabled = enabled;
        //        }));
        //    }
        //}

        //private void SetLabelText(string text)
        //{
        //    if (label_MergeDB_ErrorStats.Dispatcher.CheckAccess())
        //    {
        //        label_MergeDB_ErrorStats.Content = text;
        //        label_MergeDB_ErrorStats.UpdateLayout();
        //    }
        //    else
        //    {
        //        this.Dispatcher.Invoke((Action)(() =>
        //        {
        //            label_MergeDB_ErrorStats.Content = text;
        //            label_MergeDB_ErrorStats.UpdateLayout();
        //        }));
        //    }
        //}

        //private void RunThisStuff()
        //{
        //    ToggleMergeRunButton(false);
        //    ToggleMergeOpenFileButton(false);
        //    ToggleMergeRunFailedButton(false);
        //    ToggleCheckBoxes(false);
        //    var getLatest = checkBox_MergeDB_GetLatest.IsChecked;
        //    var force = (checkBox_MergeDB_ForceGet.IsChecked == true) ? "/force" : string.Empty;
        //    string connString = BillingToolBoxSettings.Default.ConnectionString.Replace("Provider=SQLOLEDB.1;", string.Empty);
        //    connString = connString.Replace("Initial Catalog=master;", string.Format("Initial Catalog={0};", comboBox_MergeDB_Databases.SelectedItem.ToString()));
        //    badSQLFiles = new List<string>();

        //    //if (checkBox_MergeDB_GetLatest.IsChecked == true)
        //    {
                
        //        Task.Factory.StartNew(() =>
        //        {
        //            try
        //            {
        //                if (getLatest == true)
        //                {
        //                    SetLabelText("Getting latest...");
        //                    var p = new Process();
        //                    p.StartInfo.FileName =
        //                        @"C:\Program Files (x86)\Microsoft Visual Studio 10.0\Common7\IDE\TF.EXE";

        //                    p.StartInfo.Arguments = "get \"C:\\Work\\Products\\DailyBuild\\Billing\\Database\\BDD\" " +
        //                                            force + " /recursive";
        //                    WriteToMergeDBOutput(string.Format("Running: {0} {1}", p.StartInfo.FileName,
        //                                                       p.StartInfo.Arguments));

        //                    p.StartInfo.UseShellExecute = false;
        //                    p.StartInfo.CreateNoWindow = true;
        //                    p.StartInfo.RedirectStandardOutput = true;
        //                    p.StartInfo.RedirectStandardError = true;
        //                    p.OutputDataReceived += new DataReceivedEventHandler(MergeDBOutputHandler);
        //                    p.Start();
        //                    p.BeginOutputReadLine();
        //                    p.BeginErrorReadLine();

        //                    p.WaitForExit();
        //                    WriteToMergeDBOutput("Finished getting latest.\r\n");
        //                }

        //                SetLabelText("Running DB files...");
        //                const string bddDirectory = @"C:\Work\Products\DailyBuild\Billing\Database\BDD";
        //                var di = new DirectoryInfo(bddDirectory);
        //                var files = di.GetFiles("*.sql", SearchOption.AllDirectories);
        //                var connection = new SqlConnection(connString);
        //                var server = new Server(new ServerConnection(connection));
        //                foreach (var fileInfo in files)
        //                {
        //                    var sqlScriptWorker = new SQLScriptWorker();

        //                    var workerThread = new Thread(() => sqlScriptWorker.RunScript(fileInfo, server));
        //                    workerThread.Start();
        //                    while (sqlScriptWorker.statusMessage == string.Empty)
        //                    {
        //                        Thread.Sleep(1);
        //                    }
        //                    workerThread.Join();
        //                    WriteToMergeDBOutput(sqlScriptWorker.statusMessage);
        //                    if (sqlScriptWorker.statusMessage.StartsWith("Error"))
        //                        badSQLFiles.Add(fileInfo.FullName);
        //                }

        //                WriteToMergeDBOutput("Merge finished.");
        //            }
        //            catch (Exception ex)
        //            {
        //                Dispatcher.Invoke((Action)(() =>
        //                {
        //                    Tools.ShowErrorPopUpModal(ex.Message);
        //                    Log.WriteToLog(ex.Message);
        //                }));
        //            }
        //            finally
        //            {
        //                ToggleMergeRunButton(true);
        //                ToggleCheckBoxes(true);
        //                ParseErrors();
        //            }
        //        });
        //    }
        //}

        //private void MergeDBOutputHandler(object sendingProcess, DataReceivedEventArgs outLine)
        //{
        //    if (!String.IsNullOrEmpty(outLine.Data))
        //    {
        //        WriteToMergeDBOutput(outLine.Data);
        //    }
        //}

        //private void WriteToMergeDBOutput(string output)
        //{
        //    if (textBox_MergeDB_Output.Dispatcher.CheckAccess())
        //    {
        //        textBox_MergeDB_Output.Text += output + "\r\n";
        //        textBox_MergeDB_Output.UpdateLayout();
        //        textBox_MergeDB_Output.ScrollToEnd();
        //    }
        //    else
        //    {
        //        Dispatcher.Invoke((Action)(() =>
        //        {
        //            textBox_MergeDB_Output.Text += output + "\r\n";
        //            textBox_MergeDB_Output.UpdateLayout();
        //            textBox_MergeDB_Output.ScrollToEnd();
        //        }));
        //    }
        //}

        //private void ToggleMergeRunButton(bool enabled)
        //{
        //    if (button_MergeDB_Run.Dispatcher.CheckAccess())
        //    {
        //        button_MergeDB_Run.IsEnabled = enabled;
        //    }
        //    else
        //    {
        //        Dispatcher.Invoke((Action)(() =>
        //        {
        //            button_MergeDB_Run.IsEnabled = enabled;
        //        }));
        //    }
        //}

        //private void ToggleCheckBoxes(bool enabled)
        //{
        //    if (checkBox_MergeDB_GetLatest.Dispatcher.CheckAccess())
        //    {
        //        checkBox_MergeDB_GetLatest.IsEnabled = enabled;
        //        if (checkBox_MergeDB_GetLatest.IsChecked == true)
        //        {
        //            ToggleForceGet(enabled);
        //        }
        //    }
        //    else
        //    {
        //        Dispatcher.Invoke((Action)(() =>
        //        {
        //            checkBox_MergeDB_GetLatest.IsEnabled = enabled;
        //            if (checkBox_MergeDB_GetLatest.IsChecked == true)
        //            {
        //                ToggleForceGet(enabled);
        //            }

        //        }));
        //    }
        //}

        //private void ToggleForceGet(bool enabled)
        //{
        //    if (checkBox_MergeDB_ForceGet.Dispatcher.CheckAccess())
        //    {
        //        checkBox_MergeDB_ForceGet.IsEnabled = enabled;
        //    }
        //    else
        //    {
        //        Dispatcher.Invoke((Action)(() =>
        //        {
        //            checkBox_MergeDB_ForceGet.IsEnabled = enabled;
        //        }));
        //    }
        //}

        //private static string GetServerFromConnectionString()
        //{
        //    var returnValue = BillingToolBoxSettings.Default.ConnectionString;
        //    returnValue = returnValue.Substring(returnValue.IndexOf("Data Source"));
        //    returnValue = returnValue.Substring(returnValue.IndexOf("=") + 1).Trim();
        //    return returnValue;
        //}

        //private void button_MergeDB_ChangeConnectionString_Click(object sender, RoutedEventArgs e)
        //{
        //    var x = new ChangeConnectionStringWindow();
        //    x.ShowDialog();
        //    PopulateDatabaseComboBox();
        //}

        //private void checkBox_MergeDB_GetLatest_Checked(object sender, RoutedEventArgs e)
        //{
        //    checkBox_MergeDB_ForceGet.IsEnabled = true;
        //}

        //private void checkBox_MergeDB_ForceGet_Checked(object sender, RoutedEventArgs e)
        //{

        //}

        //private void checkBox_MergeDB_GetLatest_Unchecked(object sender, RoutedEventArgs e)
        //{
        //    checkBox_MergeDB_ForceGet.IsEnabled = false;
        //}

        //private void button_MergeDB_OpenFiles_Click(object sender, RoutedEventArgs e)
        //{
        //    if (badSQLFiles.Count < 1) Tools.ShowErrorPopUpModal("No files to open.");
        //    else
        //    {
        //        foreach (var badSqlFile in badSQLFiles)
        //        {
        //            Tools.OpenFile(badSqlFile);
        //        }
        //    }
        //}

        //private void button_MergeDB_RunFailed_Click(object sender, RoutedEventArgs e)
        //{
        //    textBox_MergeDB_Output.Text = string.Empty;

        //    ToggleMergeRunButton(false);
        //    ToggleMergeOpenFileButton(false);
        //    ToggleCheckBoxes(false);
        //    var getLatest = checkBox_MergeDB_GetLatest.IsChecked;
        //    var force = (checkBox_MergeDB_ForceGet.IsChecked == true) ? "/force" : string.Empty;
        //    string connString = BillingToolBoxSettings.Default.ConnectionString.Replace("Provider=SQLOLEDB.1;", string.Empty);
        //    connString = connString.Replace("Initial Catalog=master;", string.Format("Initial Catalog={0};", comboBox_MergeDB_Databases.SelectedItem.ToString()));
        //    var badSQLFiles2 = new List<string>();

        //    //if (checkBox_MergeDB_GetLatest.IsChecked == true)
        //    {

        //        Task.Factory.StartNew(() =>
        //        {
        //            try
        //            {
        //                SetLabelText("Running DB files...");
        //                const string bddDirectory = @"C:\Work\Products\DailyBuild\Billing\Database\BDD";
        //                //var di = new DirectoryInfo(bddDirectory);
        //                //var files = di.GetFiles("*.sql", SearchOption.AllDirectories);
        //                var connection = new SqlConnection(connString);
        //                var server = new Server(new ServerConnection(connection));
        //                foreach (var badSqlFile in badSQLFiles)
        //                {
        //                    var fileInfo = new FileInfo(badSqlFile);
        //                    var sqlScriptWorker = new SQLScriptWorker();
        //                    var workerThread = new Thread(() => sqlScriptWorker.RunScript(fileInfo, server));
        //                    workerThread.Start();
        //                    while (sqlScriptWorker.statusMessage == string.Empty)
        //                    {
        //                        Thread.Sleep(1);
        //                    }
        //                    workerThread.Join();
        //                    WriteToMergeDBOutput(sqlScriptWorker.statusMessage);
        //                    if (sqlScriptWorker.statusMessage.StartsWith("Error"))
        //                        badSQLFiles2.Add(fileInfo.FullName);
        //                }

        //                WriteToMergeDBOutput("Merge finished.");
        //            }
        //            catch (Exception ex)
        //            {
        //                this.Dispatcher.Invoke((Action)(() =>
        //                {
        //                    Tools.ShowErrorPopUpModal(ex.Message);
        //                    Log.WriteToLog(ex.Message);
        //                }));
        //            }
        //            finally
        //            {
        //                badSQLFiles = new List<string>();
        //                foreach (var badSqlFile in badSQLFiles2)
        //                {
        //                    badSQLFiles.Add(badSqlFile);
        //                }
        //                ToggleMergeRunButton(true);
        //                ToggleCheckBoxes(true);
        //                ParseErrors();
        //            }
        //        });
        //    }
        //}

        //private void comboBox_MergeDB_Databases_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    textBox_MergeDB_Output.Text = string.Empty;
        //    label_MergeDB_ErrorStats.Content = string.Empty;
        //    ToggleMergeRunFailedButton(false);
        //    ToggleMergeOpenFileButton(false);
        //}

        #endregion Merge DB

        #region Enum Lists

        private void SetUpLists()
        {
            EnumSets = new Dictionary<string, List<EnumSet>>();

            #region BillingStatusIndicatorEnum
            var valuesBillingStatusIndicatorEnum = Tools.GetValues<BillingStatusIndicatorEnum>();
            var enumSets = new List<EnumSet>();
            foreach (var value in valuesBillingStatusIndicatorEnum)
            {
                var enumSet = new EnumSet();
                enumSet.Name = value.ToString();
                enumSet.Value = StringEnum.GetStringValue(value);
                enumSets.Add(enumSet);
            }
            EnumSets.Add("BillingStatusIndicatorEnum", enumSets);
            #endregion
            #region BillingTypeIndicatorEnum
            var valuesBillingTypeIndicatorEnum = Tools.GetValues<BillingTypeIndicatorEnum>();
            enumSets = new List<EnumSet>();
            foreach (var value in valuesBillingTypeIndicatorEnum)
            {
                var enumSet = new EnumSet();
                enumSet.Name = value.ToString();
                enumSet.Value = StringEnum.GetStringValue(value);
                enumSets.Add(enumSet);
            }
            EnumSets.Add("BillingTypeIndicatorEnum", enumSets);
            #endregion
            #region ServiceBusStatusEnum
            var valuesServiceBusStatusEnum = Tools.GetValues<ServiceBusStatusEnum>();
            enumSets = new List<EnumSet>();
            foreach (var value in valuesServiceBusStatusEnum)
            {
                var enumSet = new EnumSet();
                enumSet.Name = value.ToString();
                enumSet.Value = StringEnum.GetStringValue(value);
                enumSets.Add(enumSet);
            }
            EnumSets.Add("ServiceBusStatusEnum", enumSets);
            #endregion
            #region ServiceBusMessageEnum
            var valuesServiceBusMessageEnum = Tools.GetValues<ServiceBusMessageEnum>();
            enumSets = new List<EnumSet>();
            foreach (var value in valuesServiceBusMessageEnum)
            {
                var enumSet = new EnumSet();
                enumSet.Name = value.ToString();
                enumSet.Value = StringEnum.GetStringValue(value);
                enumSets.Add(enumSet);
            }
            EnumSets.Add("ServiceBusMessageEnum", enumSets);
            #endregion
            #region ClientRuleCodeEnum
            var valuesClientRuleCodeEnum = Tools.GetValues<ClientRuleCodeEnum>();
            enumSets = new List<EnumSet>();
            foreach (var value in valuesClientRuleCodeEnum)
            {
                var enumSet = new EnumSet();
                enumSet.Name = value.ToString();
                enumSet.Value = StringEnum.GetStringValue(value);
                enumSets.Add(enumSet);
            }
            EnumSets.Add("ClientRuleCodeEnum", enumSets);
            #endregion

            SetUpListComboBox();
        }

        private void SetUpListComboBox()
        {
            foreach (var enumSet in EnumSets)
            {
                comboBox_Lists_Category.Items.Add(enumSet.Key);
            }

            if (comboBox_Lists_Category.Items.Count > 0)
                comboBox_Lists_Category.SelectedIndex = 0;
        }

        private void comboBox_Lists_Category_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dataGrid_Lists_View.ItemsSource = null;
            dataGrid_Lists_View.ItemsSource = EnumSets[comboBox_Lists_Category.SelectedItem.ToString()];
        }
        
        private void GetLatestBillingLibraryDll()
        {
            if (Debugger.IsAttached) return;
            try
            {
                var dllLocation = @"C:\Work\Products\DailyBuild\BIN\Insurity.Billing.Library.dll";
                var currentLocation = System.IO.Path.Combine(Directory.GetCurrentDirectory(), @"Insurity.Billing.Library.dll");
                File.Copy(dllLocation, currentLocation, true);
            }
            catch (Exception ex)
            {
                Log.WriteToLog("Couldn't get latest dll file: {0}", ex.Message);
            }
        }

        #endregion Enum Lists

        private void menu_Configs_CentralConfig_Click(object sender, RoutedEventArgs e)
        {
            var x = new BD_CentralConfig();
            x.Show();
        }

        private void menu_Configs_ServiceBusConfig_Click(object sender, RoutedEventArgs e)
        {
            var x = new BDServicebusConfig();
            x.Show();
        }

        private void menu_Database_UpdateSystemSettings_Click(object sender, RoutedEventArgs e)
        {
            var x = new UpdateSystemSettings();
            x.Show();
        }

        //private void button_Processes_Refresh_Click(object sender, RoutedEventArgs e)
        //{
        //    LoadProcesses();
        //}

        //private void button_Processes_Stop_Click(object sender, RoutedEventArgs e)
        //{
        //    var pd = (ProcessData)dataGrid_Processes.SelectedItem;
        //    var p = Process.GetProcessesByName(pd.ProcessName);
        //    foreach (var process in p)
        //    {
        //        process.Kill();
        //    }
            
        //    LoadProcesses();
        //}

        //private void LoadProcesses()
        //{
        //    var rawprocesses = Process.GetProcesses();
        //    var processes = new List<ProcessData>();
        //    foreach (var rawprocess in rawprocesses)
        //    {
        //        processes.Add(new ProcessData(rawprocess));
        //    }
        //    processes.Sort();

        //    int? sortColumnNum = null;
        //    ListSortDirection? sortColumnDirection = null;
        //    for (int i = 0; i < dataGrid_Processes.Columns.Count; i++)
        //    {
        //        if (dataGrid_Processes.Columns[i].SortDirection != null)
        //        {
        //            sortColumnNum = i;
        //            sortColumnDirection = dataGrid_Processes.Columns[i].SortDirection;
        //            break;
        //        }
        //    }
        //    dataGrid_Processes.ItemsSource = processes;
        //    if (sortColumnNum != null && sortColumnDirection != null)
        //    {
        //        Tools.SortDataGrid(dataGrid_Processes, sortColumnNum.GetValueOrDefault(), sortColumnDirection.GetValueOrDefault());
        //    }
        //}

        private void menu_Database_MergeDatabase_Click(object sender, RoutedEventArgs e)
        {
            var x = new MergeDB();
            x.ShowDialog();
        }

        private void menu_Database_ChangeConnectionString_Click(object sender, RoutedEventArgs e)
        {
            var x = new ChangeConnectionStringWindow();
            x.ShowDialog();
        }

        private void menu_Database_FindColumn_Click(object sender, RoutedEventArgs e)
        {
            var x = new TableLookupByColumnName();
            x.Show();
        }

        private void menu_Reset_IIS_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(@"C:\Windows\System32\iisreset.exe");
        }

        private void menu_System_TaskManager_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("taskmgr");
        }

        private void Menu_MouseDown(object sender, MouseButtonEventArgs e)
        {
            menu.Focus();
        }
    }
}
