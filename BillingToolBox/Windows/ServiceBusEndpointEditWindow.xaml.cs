using System;
using System.IO;
using System.Windows;
using System.Xml.Linq;
using BillingToolBox.Classes;

namespace BillingToolBox.Windows
{
    /// <summary>
    /// Interaction logic for ServiceBusEndpointEditWindow.xaml
    /// </summary>
    public partial class ServiceBusEndpointEditWindow : Window
    {
        private readonly string _configPath;
        public ServiceBusEndpointEditWindow()
        {
            InitializeComponent();
        }

        public ServiceBusEndpointEditWindow(string configPath, ServiceBusEndpoint endpoint)
        {
            InitializeComponent();
            _configPath = configPath;
            textBox_Name.Text = endpoint.Name;
            textBox_NumWorkerThreads.Text = endpoint.NumWorkerThreads;
            textBox_MaxRetries.Text = endpoint.MaxRetries;
        }

        private void button_Save_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists(_configPath))
            {
                try
                {
                    var xdoc = XDocument.Load(_configPath);

                    foreach (var endpointXML in xdoc.Descendants("Endpoint"))
                    {
                        if (endpointXML.Attribute("name").Value == textBox_Name.Text)
                        {
                            var configXML = endpointXML.Descendants("MsmqTransportConfig");
                            foreach (var xElement in configXML)
                            {
                                xElement.Attribute("MaxRetries").Value = textBox_MaxRetries.Text;
                                xElement.Attribute("NumberOfWorkerThreads").Value = textBox_NumWorkerThreads.Text;
                                xdoc.Save(_configPath);
                                break;
                            }
                            break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Log.WriteToLog(ex.Message);
                    Tools.ShowErrorPopUpModal(ex.Message);
                    return;
                }
            }
            Tools.ShowMessagePopUpModal("File updated.");
            Close();
        }

        private void button_Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
