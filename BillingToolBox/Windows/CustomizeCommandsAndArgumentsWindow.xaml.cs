using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using BillingToolBox.Classes;

namespace BillingToolBox.Windows
{
    /// <summary>
    /// Interaction logic for CustomizeCommandsAndArgumentsWindow.xaml
    /// </summary>
    public partial class CustomizeCommandsAndArgumentsWindow : Window
    {
        CommandsAndArgs commandsAndArgs = new CommandsAndArgs();

        public CustomizeCommandsAndArgumentsWindow()
        {
            InitializeComponent();
            commandsAndArgs.PopulateCommandTable();
            PopulateFields();
            //if (comboBox_Commands.Items.Count > 0)
            //    comboBox_Commands.SelectedIndex = 0;
        }

        private void PopulateFields()
        {
            SetCommandBoxes();

            if (comboBox_Commands.Items.Count > 0)
            {
                comboBox_Commands.SelectedIndex = 0;

                SetArgumentListBox();
            }
        }

        private void SetCommandBoxes()
        {
            comboBox_Commands.Items.Clear();
            listBox_CommandList.Items.Clear();

            foreach (var commandSet in commandsAndArgs.CommandTable)
            {
                comboBox_Commands.Items.Add(commandSet.Key);
                listBox_CommandList.Items.Add(commandSet.Key);
            }
        }

        private void SetArgumentListBox()
        {
            listBox_ArgumentList.Items.Clear();
            if (comboBox_Commands.SelectedItem == null) return;
            if (!commandsAndArgs.CommandTable.ContainsKey(comboBox_Commands.SelectedItem.ToString())) return;

            foreach (var argument in commandsAndArgs.CommandTable[comboBox_Commands.SelectedItem.ToString()])
            {
                listBox_ArgumentList.Items.Add(argument);
            }
        }

        private void listBox_List_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (listBox_ArgumentList.SelectedItem != null)
            {
                commandsAndArgs.CommandTable[comboBox_Commands.SelectedItem.ToString()].Remove(
                    listBox_ArgumentList.SelectedItem.ToString());
                SetArgumentListBox();
            }
        }

        private void button_Add_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox_Add.Text) &&
                !commandsAndArgs.CommandTable.ContainsKey(textBox_Add.Text))
            {
                commandsAndArgs.CommandTable[comboBox_Commands.SelectedItem.ToString()].Add(textBox_Add.Text);
                SetArgumentListBox();
                textBox_Add.Text = string.Empty;
            }
            textBox_Add.Focus();
        }

        private void button_Save_Click(object sender, RoutedEventArgs e)
        {
            commandsAndArgs.SaveCommandTable();
            Tools.ShowMessagePopUpModal("Data saved.");
            Close();
        }

        private void button_Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void button_AddCommand_Click(object sender, RoutedEventArgs e)
        {
            tabItem_Commands.Focus();
        }

        private void listBox_CommandList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (listBox_CommandList.SelectedItem != null)
            {
                commandsAndArgs.CommandTable.Remove(listBox_CommandList.SelectedItem.ToString());
                PopulateFields();
            }
        }

        private void button_AddCommandToList_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox_NewCommand.Text) && 
                !commandsAndArgs.CommandTable.ContainsKey(textBox_NewCommand.Text))
            {
                commandsAndArgs.CommandTable.Add(textBox_NewCommand.Text, new List<string>());
                PopulateFields();
                textBox_NewCommand.Text = string.Empty;
            }
            textBox_NewCommand.Focus();
        }

        private void comboBox_Commands_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SetArgumentListBox();
        }
    }
}
