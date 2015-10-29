using System.Collections.Generic;
using System.ServiceProcess;
using System.Windows;
using System.Windows.Input;

namespace BillingToolBox.Windows
{
    /// <summary>
    /// Interaction logic for ServiceEditWindow.xaml
    /// </summary>
    public partial class ServiceEditWindow : Window
    {
        public List<string> AvailableServices = new List<string>();
        public List<string> CurrentServices = new List<string>(); 

        public ServiceEditWindow()
        {
            InitializeComponent();
            SetUpLists();
        }

        private void SetUpLists()
        {
            var services = ServiceController.GetServices();
            var deviceservices = ServiceController.GetDevices();

            foreach (var serviceController in services)
            {
                AvailableServices.Add(serviceController.ServiceName);
            }

            //foreach (var serviceController in deviceservices)
            //{
            //    AvailableServices.Add(serviceController.ServiceName);
            //}

            foreach (var service in BillingToolBoxSettings.Default.Services)
            {
                CurrentServices.Add(service);
            }

            foreach (var service in CurrentServices)
            {
                AvailableServices.Remove(service);
            }

            AvailableServices.Sort();
            CurrentServices.Sort();

            listBox_AvailableServices.ItemsSource = AvailableServices;
            listBox_CurrentServices.ItemsSource = CurrentServices;
        }

        private void button_Save_Click(object sender, RoutedEventArgs e)
        {
            BillingToolBoxSettings.Default.Services.Clear();
            foreach (var service in CurrentServices)
            {
                BillingToolBoxSettings.Default.Services.Add(service);
            }
            BillingToolBoxSettings.Default.Save();
            Close();
        }

        private void button_Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void button_Add_Click(object sender, RoutedEventArgs e)
        {
            AddService();
        }

        private void listBox_AvailableServices_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            AddService();
        }

        private void button_Delete_Click(object sender, RoutedEventArgs e)
        {
            RemoveService();
        }

        private void listBox_ServiceList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            RemoveService();
        }
        
        private void AddService()
        {
            foreach (var item in listBox_AvailableServices.SelectedItems)
            {
                CurrentServices.Add(item.ToString());
                AvailableServices.Remove(item.ToString());
            }

            SortAndRefreshLists();
        }

        private void RemoveService()
        {
            foreach (var item in listBox_CurrentServices.SelectedItems)
            {
                AvailableServices.Add(item.ToString());
                CurrentServices.Remove(item.ToString());
            }

            SortAndRefreshLists();
        }

        private void SortAndRefreshLists()
        {
            AvailableServices.Sort();
            CurrentServices.Sort();

            listBox_AvailableServices.ItemsSource = null;
            listBox_AvailableServices.ItemsSource = AvailableServices;
            listBox_CurrentServices.ItemsSource = null;
            listBox_CurrentServices.ItemsSource = CurrentServices;
        }
    }
}
