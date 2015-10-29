using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using BillingToolBox.Classes;

namespace BillingToolBox.Windows
{
    /// <summary>
    /// Interaction logic for UpdateSystemSettings.xaml
    /// </summary>
    public partial class UpdateSystemSettings : Window
    {
        public UpdateSystemSettings()
        {
            InitializeComponent();
            PopulateDatabaseComboBox();
            PopulateTextBox();
        }

        private void button_Update_Click(object sender, RoutedEventArgs e)
        {
            UpdateDatabase();
            PopulateTextBox();
            textBox_ServerDateOverride.SelectAll();
        }

        private void comboBox_Database_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PopulateTextBox();
        }

        private void UpdateDatabase()
        {
            DateTime newDate ;
            if (DateTime.TryParse(textBox_ServerDateOverride.Text, out newDate)||
                textBox_ServerDateOverride.Text == string.Empty)
            {
                string connString = BillingToolBoxSettings.Default.ConnectionString.Replace("Provider=SQLOLEDB.1;", string.Empty);
                connString = connString.Replace("Initial Catalog=master;", string.Format("Initial Catalog={0};", comboBox_Database.SelectedItem.ToString()));

                var query = string.Empty;
                if (newDate != DateTime.MinValue)
                {
                    query = string.Format("UPDATE SystemSettings SET ServerDateOverride = '{0}'", newDate);
                }
                else
                {
                    query = "UPDATE SystemSettings SET ServerDateOverride = null";
                }

                using (SqlConnection connection = new SqlConnection(connString))
                {
                    try
                    {
                        SqlCommand command = new SqlCommand(query, connection);
                        connection.Open();
                        int result = command.ExecuteNonQuery();
                        //Tools.ShowMessagePopUpModal(result.ToString() + " row(s) updated");
                        
                    }
                    catch (Exception ex)
                    {
                        Tools.ShowErrorPopUpModal(ex.Message);
                    }
                }
            }
            else
            {
                Tools.ShowErrorPopUpModal(textBox_ServerDateOverride.Text + " is not a valid date, server not updated");
            }
        }

        private void PopulateTextBox()
        {
            string connString = BillingToolBoxSettings.Default.ConnectionString.Replace("Provider=SQLOLEDB.1;", string.Empty);
            connString = connString.Replace("Initial Catalog=master;", string.Format("Initial Catalog={0};", comboBox_Database.SelectedItem.ToString()));
            var query = "SELECT ServerDateOverride FROM SystemSettings";

            using (SqlConnection connection = new SqlConnection(connString))
            {
                try
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        textBox_ServerDateOverride.Text = reader["ServerDateOverride"].ToString();
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    textBox_ServerDateOverride.Text = "Nothing found";
                }
            }
        }

        private void PopulateDatabaseComboBox()
        {
            comboBox_Database.Items.Clear();
            var databases = Tools.GetDatabases();
            foreach (var database in databases)
            {
                comboBox_Database.Items.Add(database);
            }
            if (comboBox_Database.Items.Count > 0)
                comboBox_Database.SelectedIndex = 0;
        }

        private void textBox_ServerDateOverride_GotFocus(object sender, RoutedEventArgs e)
        {
            textBox_ServerDateOverride.SelectAll();
        }

        private void textBox_ServerDateOverride_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            textBox_ServerDateOverride.SelectAll();
        }

        private void textBox_ServerDateOverride_GotMouseCapture(object sender, MouseEventArgs e)
        {
            textBox_ServerDateOverride.SelectAll();
        }
    }
}
