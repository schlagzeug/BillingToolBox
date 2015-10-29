using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Xml.Linq;
using BillingToolBox.Classes;

namespace BillingToolBox.Windows
{
    /// <summary>
    /// Interaction logic for BD_CentralConfig.xaml
    /// </summary>
    public partial class BD_CentralConfig : Window
    {
        List<InsurityCustomer> customers = new List<InsurityCustomer>();

        public BD_CentralConfig()
        {
            InitializeComponent();

            SetBDCCFields();
        }

        private void button_BDCC_Refresh_Click(object sender, RoutedEventArgs e)
        {
            PopulateCustomersGrid();
        }

        private void SetBDCCFields()
        {
            textBox_BDCC_Location.Text = BillingToolBoxSettings.Default.BDCentralConfigLocation;
            PopulateCustomersGrid();
        }

        private void PopulateCustomersGrid()
        {
            dataGrid_BDCC_InsurityCustomers.ItemsSource = null;
            customers = new List<InsurityCustomer>();

            if (File.Exists(textBox_BDCC_Location.Text))
            {
                try
                {
                    XDocument xdoc = XDocument.Load(textBox_BDCC_Location.Text);

                    var insurityCustomers = from node in xdoc.Descendants("InsurityCustomer")
                                            select new InsurityCustomer()
                                            {
                                                CustomerID = node.Attribute("CustomerId").Value,
                                                FileCode = node.Attribute("CustomerFileNmCd").Value,
                                                Name = node.Attribute("Name").Value,
                                                PathTableLocation = System.IO.Path.Combine(node.Attribute("PathTableLocation").Value, "pathtbl.xml")
                                            };

                    foreach (var customer in insurityCustomers)
                    {
                        customers.Add(customer);
                    }

                }
                catch (Exception)
                {
                    customers = new List<InsurityCustomer>();
                }

                dataGrid_BDCC_InsurityCustomers.ItemsSource = customers;
            }
        }

        private void button_BDCC_OpenFile_Click(object sender, RoutedEventArgs e)
        {
            Tools.OpenFile(textBox_BDCC_Location.Text);
        }

        private void dataGrid_BDCC_InsurityCustomers_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (dataGrid_BDCC_InsurityCustomers.SelectedItem != null)
            {
                var x = new PathTableMainWindow((InsurityCustomer)dataGrid_BDCC_InsurityCustomers.SelectedItem);
                x.Show();
            }
        }

    }
}
