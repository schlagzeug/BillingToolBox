using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Input;
using System.Xml.Linq;
using BillingToolBox.Classes;

namespace BillingToolBox.Windows
{
    /// <summary>
    /// Interaction logic for PathTableMainWindow.xaml
    /// </summary>
    public partial class PathTableMainWindow : Window
    {
        private readonly InsurityCustomer _customer;
        public PathTableMainWindow()
        {
            InitializeComponent();
        }

        public PathTableMainWindow(InsurityCustomer customer)
        {
            _customer = customer;
            InitializeComponent();
            PopulateFields(customer);
        }

        private void PopulateFields(InsurityCustomer customer)
        {
            label_PathTable.Content = customer.PathTableLocation;
            GetPathTableValues(customer.PathTableLocation);
            PopulatePathTable();
        }

        private void PopulatePathTable()
        {
            dataGrid_PathTableItems.ItemsSource = null;
            if (_customer == null) return;

            if (File.Exists(_customer.PathTableLocation))
            {
                var entries = new List<PathTableEntry>();
                
                try
                {
                    XDocument xdoc = XDocument.Load(_customer.PathTableLocation);
                    
                    foreach (var node in xdoc.Descendants("XMaskTable__x0024__x0024_"))
                    {
                        var entry = new PathTableEntry();

                        var mask = node.Descendants("Mask");
                        foreach (var ele in mask)
                        {
                            entry.Mask = ele.Value;   
                        }

                        var path = node.Descendants("Path");
                        foreach (var ele in path)
                        {
                            entry.Path = ele.Value;
                        }

                        entries.Add(entry);
                    }
                }
                catch (Exception ex)
                {
                    entries = new List<PathTableEntry>();
                    Log.WriteToLog(ex.Message);
                }

                dataGrid_PathTableItems.ItemsSource = entries;
            }
        }

        private void GetPathTableValues(string path)
        {
            if (File.Exists(path))
            {
                try
                {
                    XDocument xdoc = XDocument.Load(path);

                    foreach (var node in xdoc.Descendants("XMaskTable__x0024__x0024_"))
                    {
                        var mask = node.Descendants("Mask");
                        foreach (var ele in mask)
                        {
                            if (ele.Value == "BILLINGDATABASENAME")
                            {
                                var descendants = node.Descendants("Path");
                                foreach (var xElement in descendants)
                                {
                                    textBox_BillingDatabase.Text = xElement.Value;
                                }
                            }
                            else if (ele.Value == "BILLINGSERVERNAME")
                            {
                                var descendants = node.Descendants("Path");
                                foreach (var xElement in descendants)
                                {
                                    textBox_BillingServer.Text = xElement.Value;
                                }
                            }
                        }
                    }

                }
                catch (Exception ex)
                {
                    Tools.ShowErrorPopUpModal("Unable to retrieve data.");
                    Log.WriteToLog(ex.Message);
                }
            }
        }

        private void button_AddEntry_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists(label_PathTable.Content.ToString()))
            {
                var x = new PathTableAddEntryWindow(label_PathTable.Content.ToString());
                x.ShowDialog();
                if (_customer != null)
                    PopulateFields(_customer);
                else
                    PopulatePathTable();
            }
            else
            {
                Tools.ShowErrorPopUpModal("Path table doesn't exist.");
            }
        }

        private void button_Cancel_Click(object sender, RoutedEventArgs e)
        {
            PopulatePathTable();
        }

        private void button_Save_Click(object sender, RoutedEventArgs e)
        {
            if (WriteValuesBackToPathTable())
                PopulatePathTable();
        }

        private bool WriteValuesBackToPathTable()
        {
            var path = label_PathTable.Content.ToString();
            if (File.Exists(path))
            {
                try
                {
                    bool updated = false;
                    XDocument xdoc = XDocument.Load(path);

                    foreach (var node in xdoc.Descendants("XMaskTable__x0024__x0024_"))
                    {
                        var mask = node.Descendants("Mask");
                        foreach (var ele in mask)
                        {
                            if (ele.Value == "BILLINGDATABASENAME")
                            {
                                var descendants = node.Descendants("Path");
                                foreach (var xElement in descendants)
                                {
                                    xElement.Value = textBox_BillingDatabase.Text;
                                    updated = true;
                                }
                            }
                            else if (ele.Value == "BILLINGSERVERNAME")
                            {
                                var descendants = node.Descendants("Path");
                                foreach (var xElement in descendants)
                                {
                                    xElement.Value = textBox_BillingServer.Text;
                                    updated = true;
                                }
                            }
                        }
                    }

                    if (updated)
                    {
                        xdoc.Save(path);
                    }

                    Tools.ShowMessagePopUpModal("File updated.");
                    return true;
                }
                catch (Exception ex)
                {
                    Tools.ShowErrorPopUpModal("Unable to write data to file.");
                    Log.WriteToLog(ex.Message);
                    return false;
                }
            }

            Tools.ShowErrorPopUpModal("Path table file does not exist.");
            return false;
        }

        private void button_OpenPathTable_Click(object sender, RoutedEventArgs e)
        {
            Tools.OpenFile(label_PathTable.Content.ToString());
        }

        private void dataGrid_PathTableItems_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (dataGrid_PathTableItems.SelectedItem != null)
            {
                var entry = (PathTableEntry) dataGrid_PathTableItems.SelectedItem;
                var x = new PathTableAddEntryWindow(_customer.PathTableLocation, entry);
                x.ShowDialog();
                if (_customer != null)
                    PopulateFields(_customer);
                else
                    PopulatePathTable();
            }
        }
    }
}
