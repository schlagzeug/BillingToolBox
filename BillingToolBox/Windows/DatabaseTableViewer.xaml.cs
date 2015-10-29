using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using BillingToolBox.Classes;

namespace BillingToolBox.Windows
{
    /// <summary>
    /// Interaction logic for SQLTableViewer.xaml
    /// </summary>
    public partial class DatabaseTableViewer : Window
    {
        public DatabaseTableViewer()
        {
            InitializeComponent();
            PopulateDatabaseComboBox();
            PopulateTableComboBox();
        }

        private void comboBox_Database_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PopulateDataGrid();
        }

        private void comboBox_Table_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PopulateDataGrid();
        }

        private void dataGrid_Results_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            // TODO
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

        private void PopulateTableComboBox()
        {
            foreach (var table in Enum.GetNames(typeof(DatabaseTable)))
            {
                comboBox_Table.Items.Add(table);
            }

            if (comboBox_Table.Items.Count > 0)
                comboBox_Table.SelectedIndex = 0;
        }

        private void PopulateDataGrid()
        {
            if (comboBox_Table.SelectedItem != null && comboBox_Table.SelectedItem.ToString() != string.Empty)
            {
                string connString = BillingToolBoxSettings.Default.ConnectionString.Replace("Provider=SQLOLEDB.1;", string.Empty);
                connString = connString.Replace("Initial Catalog=master;", string.Format("Initial Catalog={0};", comboBox_Database.SelectedItem.ToString()));
                var query = string.Format("SELECT * FROM {0}", comboBox_Table.SelectedItem);

                using (SqlConnection connection = new SqlConnection(connString))
                {
                    try
                    {
                        SqlCommand command = new SqlCommand(query, connection);
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        DatabaseTable table;
                        Enum.TryParse(comboBox_Table.SelectedItem.ToString(), out table);
                        PopulateDataGrid(reader, table);
                        reader.Close();
                    }
                    catch(Exception ex)
                    {
                        dataGrid_Results.ItemsSource = null;
                    }
                }
            }
        }

        private void PopulateDataGrid(SqlDataReader reader, DatabaseTable tableName)
        {
            dataGrid_Results.ItemsSource = null;
            switch (tableName)
            {
                case DatabaseTable.ProcessControl:
                    var processControls = new List<ProcessControl>();
                    while (reader.Read())
                    {
                        var x = new ProcessControl(reader);
                        processControls.Add(x);
                    }
                    dataGrid_Results.ItemsSource = processControls;
                    break;
                case DatabaseTable.SystemSettings:
                    var systemSettingses = new List<SystemSettings>();
                    while (reader.Read())
                    {
                        var x = new SystemSettings(reader);
                        systemSettingses.Add(x);
                    }
                    dataGrid_Results.ItemsSource = systemSettingses;
                    break;
                case DatabaseTable.BillingDecisionsConfiguration:
                    var billingDecisionsConfigurations = new List<BillingDecisionsConfiguration>();
                    while (reader.Read())
                    {
                        var x = new BillingDecisionsConfiguration(reader);
                        billingDecisionsConfigurations.Add(x);
                    }
                    dataGrid_Results.ItemsSource = billingDecisionsConfigurations;
                    break;
                default:
                    Tools.ShowErrorPopUpModal("Unsupported table");
                    break;
            }
        }
    }

    enum DatabaseTable
    {
        BillingDecisionsConfiguration,
        ProcessControl,
        SystemSettings
    }
}
