using System.Windows;

namespace BillingToolBox.Windows
{
    /// <summary>
    /// Interaction logic for PopUpWindow.xaml
    /// </summary>
    public partial class PopUpWindow : Window
    {
        public PopUpWindow()
        {
            InitializeComponent();
        }

        public PopUpWindow(string title, string message)
        {
            InitializeComponent();
            Title = title;
            textBlock_Message.Text = message;
            button_OK.Focus();
        }

        private void button_OK_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
