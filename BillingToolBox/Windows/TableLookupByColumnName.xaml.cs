using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.SqlClient;
using BillingToolBox.Classes;

namespace BillingToolBox.Windows
{
    /// <summary>
    /// Interaction logic for TableLookupByColumnName.xaml
    /// </summary>
    public partial class TableLookupByColumnName : Window
    {
        public TableLookupByColumnName()
        {
            InitializeComponent();
            PopulateDatabaseComboBox();
            textBox_SearchCriteria.Focus();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (textBox_SearchCriteria.Text.Contains(' '))
            {
                Tools.ShowMessagePopUpModal("Invalid search criteria.");
            }
            else
            {
                string connString = BillingToolBoxSettings.Default.ConnectionString.Replace("Provider=SQLOLEDB.1;", string.Empty);
                connString = connString.Replace("Initial Catalog=master;", string.Format("Initial Catalog={0};", comboBox_Database.SelectedItem.ToString()));
                var query = string.Format("SELECT t.name AS 'Table', c.name AS 'Column' FROM sys.tables t INNER JOIN sys.columns c ON t.OBJECT_ID = c.OBJECT_ID WHERE c.name LIKE '{0}' ORDER BY 'Table'", textBox_SearchCriteria.Text);

                using (SqlConnection connection = new SqlConnection(connString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    var resultList = new List<TableLookupResult>();

                    try
                    {
                        while (reader.Read())
                        {
                            var result = new TableLookupResult();
                            result.TableName = reader["Table"].ToString();
                            result.ColumnName = reader["Column"].ToString();
                            resultList.Add(result);
                        }
                        dataGrid_Results.ItemsSource = resultList;
                    }
                    catch (Exception ex)
                    {
                        Tools.ShowErrorPopUpModal(ex.Message);
                        dataGrid_Results.ItemsSource = null;
                    }
                    finally
                    {
                        reader.Close();
                    }
                }
            }
        }

        private void PopulateDatabaseComboBox()
        {
            //BillingToolBoxSettings.Default.ConnectionString = textBox_MergeDB_ConnectionString.Text;
            comboBox_Database.Items.Clear();
            var databases = Tools.GetDatabases();
            foreach (var database in databases)
            {
                comboBox_Database.Items.Add(database);
            }
            if (comboBox_Database.Items.Count > 0)
                comboBox_Database.SelectedIndex = 0;
        }

        private void button_CreateSelect_Click(object sender, RoutedEventArgs e)
        {
            var outputstring = string.Empty;
            foreach (TableLookupResult line in dataGrid_Results.SelectedItems)
            {
                if (textBox_Value.Text != string.Empty)
                {
                    outputstring += string.Format("SELECT {1}, * FROM {0} WHERE {1} = '{2}'\r\n", line.TableName, line.ColumnName, textBox_Value.Text);
                }
                else
                {
                    outputstring += string.Format("SELECT TOP 100 {1}, * FROM {0}", line.TableName, line.ColumnName);
                }
            }

            if (outputstring != string.Empty)
            {
                var writer = new StreamWriter("temp.sql");
                writer.WriteLine(string.Format("USE {0}", comboBox_Database.SelectedItem.ToString()));
                writer.WriteLine(string.Empty);
                writer.Write(outputstring);
                writer.Flush();
                writer.Close();
                Tools.OpenFile("temp.sql");
            }
        }

        private void textBox_Value_GotFocus(object sender, RoutedEventArgs e)
        {
            textBox_Value.SelectAll();
        }

        private void textBox_Value_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            textBox_Value.SelectAll();
        }

        private void textBox_Value_GotMouseCapture(object sender, MouseEventArgs e)
        {
            textBox_Value.SelectAll();
        }
    }
}
