using System.Windows;
using BillingToolBox.Classes;

namespace BillingToolBox.Windows
{
    /// <summary>
    /// Interaction logic for ChangeConnectionStringWindow.xaml
    /// </summary>
    public partial class ChangeConnectionStringWindow : Window
    {
        public ChangeConnectionStringWindow()
        {
            InitializeComponent();
            textBox_ConnectionString.Text = BillingToolBoxSettings.Default.ConnectionString;
        }

        private void button_Save_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_ConnectionString.Text))
            {
                Tools.ShowErrorPopUpModal("New conection string is empty.");
            }
            else
            {
                BillingToolBoxSettings.Default.ConnectionString = textBox_ConnectionString.Text;
                Tools.ShowMessagePopUpModal("Connection string updated.");
                Close();
            }
        }

        private void button_Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
