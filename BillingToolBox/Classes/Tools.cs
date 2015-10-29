using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.OleDb;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
using System.Windows.Controls;
using BillingToolBox.Windows;

namespace BillingToolBox.Classes
{
    public static class Tools
    {
        public static void ShowErrorPopUpModal(string errorMessage)
        {
            var x = new PopUpWindow("ERROR", errorMessage);
            x.ShowDialog();
        }

        public static void ShowErrorPopUp(string errorMessage)
        {
            var x = new PopUpWindow("ERROR", errorMessage);
            x.Show();
        }

        public static void ShowMessagePopUpModal(string message)
        {
            var x = new PopUpWindow("Message", message);
            x.ShowDialog();
        }

        public static void ShowMessagePopUp(string message)
        {
            var x = new PopUpWindow("Message", message);
            x.Show();
        }

        public static List<string> GetDatabases()
        {
            var serverList = new List<string>();

            // SELECT * FROM sys.databases d WHERE d.name NOT IN ('master','tempdb','model','msdb','BDNETDAS')
            try
            {
                string sql = "SELECT * FROM sys.databases d WHERE d.name NOT IN ('master','tempdb','model','msdb','BDNETDAS')";

                using (var cn = new OleDbConnection(BillingToolBoxSettings.Default.ConnectionString))
                using (var cmd = new OleDbCommand(sql, cn))
                {
                    cn.Open();
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        serverList.Add(reader[0].ToString());
                    }
                }
            }
            catch (Exception e)
            {
                Log.WriteToLog(e.Message);
            }
            return serverList;
        }

        public static void OpenFile(string fileLocation)
        {
            if (File.Exists(fileLocation))
            {
                Process.Start(fileLocation);
            }
            else
            {
                ShowErrorPopUpModal("File doesn't exist.");
            }
        }

        public static void OpenDirectory(string directory)
        {
            if (Directory.Exists(directory))
            {
                Process.Start(directory);
            }
            else
            {
                ShowErrorPopUpModal("Directory doesn't exist.");
            }
        }

        public static IEnumerable<T> GetValues<T>()
        {
            return Enum.GetValues(typeof(T)).Cast<T>();
        }

        public static void SortDataGrid(DataGrid dataGrid, int columnIndex = 0, ListSortDirection sortDirection = ListSortDirection.Ascending)
        {
            var column = dataGrid.Columns[columnIndex];

            // Clear current sort descriptions
            dataGrid.Items.SortDescriptions.Clear();

            // Add the new sort description
            dataGrid.Items.SortDescriptions.Add(new SortDescription(column.SortMemberPath, sortDirection));

            // Apply sort
            foreach (var col in dataGrid.Columns)
            {
                col.SortDirection = null;
            }
            column.SortDirection = sortDirection;

            // Refresh items to display sort
            dataGrid.Items.Refresh();
        }

        public static string GetMainModuleFilepath(int processId)
        {
            string wmiQueryString = "SELECT ProcessId, ExecutablePath FROM Win32_Process WHERE ProcessId = " + processId;
            using (var searcher = new ManagementObjectSearcher(wmiQueryString))
            {
                using (var results = searcher.Get())
                {
                    ManagementObject mo = results.Cast<ManagementObject>().FirstOrDefault();
                    if (mo != null)
                    {
                        return (string)mo["ExecutablePath"];
                    }
                }
            }
            return null;
        }

        public static string GetFileVersionDescription(string path)
        {
            string description;
            try
            {
                description = FileVersionInfo.GetVersionInfo(path).FileDescription;
            }
            catch (Exception)
            {
                description = "N/A";
            }

            return description;
        }
    }
}