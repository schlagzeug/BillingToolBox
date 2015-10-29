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
    /// Interaction logic for BDServicebusConfig.xaml
    /// </summary>
    public partial class BDServicebusConfig : Window
    {
        List<ServiceBusEndpoint> endpoints = new List<ServiceBusEndpoint>();

        public BDServicebusConfig()
        {
            InitializeComponent();

            SetSBCFields();
        }


        private void SetSBCFields()
        {
            textBox_SBC_Location.Text = BillingToolBoxSettings.Default.BDServiceBusConfigLocation;
            PopulateEndpointsGrid();
        }

        private void button_SBC_Refresh_Click(object sender, RoutedEventArgs e)
        {
            PopulateEndpointsGrid();
        }

        private void PopulateEndpointsGrid()
        {
            dataGrid_SBC_EndPoints.ItemsSource = null;
            endpoints = new List<ServiceBusEndpoint>();

            if (File.Exists(textBox_SBC_Location.Text))
            {
                try
                {
                    var xdoc = XDocument.Load(textBox_SBC_Location.Text);

                    foreach (var endpointXML in xdoc.Descendants("Endpoint"))
                    {
                        var serviceBusEndpoint = new ServiceBusEndpoint();

                        serviceBusEndpoint.Name = endpointXML.Attribute("name").Value;
                        var configXML = endpointXML.Descendants("MsmqTransportConfig");
                        foreach (var xElement in configXML)
                        {
                            serviceBusEndpoint.MaxRetries = xElement.Attribute("MaxRetries").Value;
                            serviceBusEndpoint.NumWorkerThreads = xElement.Attribute("NumberOfWorkerThreads").Value;
                        }
                        endpoints.Add(serviceBusEndpoint);
                    }

                }
                catch (Exception)
                {
                    endpoints = new List<ServiceBusEndpoint>();
                }

                dataGrid_SBC_EndPoints.ItemsSource = endpoints;
            }
        }

        private void button_SBC_OpenFile_Click(object sender, RoutedEventArgs e)
        {
            Tools.OpenFile(textBox_SBC_Location.Text);
        }

        private void dataGrid_SBC_EndPoints_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (dataGrid_SBC_EndPoints.SelectedItem == null) return;

            var x = new ServiceBusEndpointEditWindow(textBox_SBC_Location.Text, dataGrid_SBC_EndPoints.SelectedItem as ServiceBusEndpoint);
            x.ShowDialog();
            PopulateEndpointsGrid();
        }

    }
}
