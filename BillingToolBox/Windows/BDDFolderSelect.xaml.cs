using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.IO;

namespace BillingToolBox.Windows
{
    /// <summary>
    /// Interaction logic for BDDFolderSelect.xaml
    /// </summary>
    public partial class BDDFolderSelect : Window
    {
        public BDDFolderSelect()
        {
            InitializeComponent();
            textBox_BDD.Text = BillingToolBoxSettings.Default.BDD_Directory;

            foreach (var mergeFolder in BillingToolBoxSettings.Default.MergeFolders)
            {
                listBox_Selected.Items.Add(mergeFolder);
            }
            RefreshTextBoxes();

            //foreach (var item in listBox_Selected.Items)
            //{
            //    if (listBox_Available.Items.Contains(item.ToString()))
            //        listBox_Available.Items.Remove(item);
            //}
        }

        private void listBox_Selected_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var x = listBox_Selected.SelectedItem.ToString();

            listBox_Selected.Items.Remove(x);
            if (Directory.Exists(Path.Combine(textBox_BDD.Text, x)))
            {
                listBox_Available.Items.Add(x);
            }
        }

        private void listBox_Available_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var x = listBox_Available.SelectedItem.ToString();
            listBox_Available.Items.Remove(x);
            listBox_Selected.Items.Add(x);
        }

        private void RefreshTextBoxes()
        {
            listBox_Available.Items.Clear();
            //listBox_Selected.Items.Clear();

            if (Directory.Exists(textBox_BDD.Text))
            {
                var di = new DirectoryInfo(textBox_BDD.Text);
                var subs = di.GetDirectories();
                foreach (var sub in subs)
                {
                    if (listBox_Selected.Items.Contains(sub.ToString())) continue;
                    listBox_Available.Items.Add(sub.ToString());
                }

                for (int i = 0; i < listBox_Selected.Items.Count; i++)
                {
                    bool found = false;
                    foreach (var sub in subs)
                    {
                        if (sub.ToString() == listBox_Selected.Items[i].ToString())
                        {
                            found = true;
                            break;
                        }
                    }
                    if (!found)
                    {
                        listBox_Selected.Items.RemoveAt(i);
                        i--;
                    }
                }

                foreach (var item in listBox_Selected.Items)
                {
                    if (listBox_Available.Items.Contains(item.ToString()))
                        listBox_Available.Items.Remove(item);
                }
            }
        }

        private void button_UpdateBDD_Click(object sender, RoutedEventArgs e)
        {
            RefreshTextBoxes();
        }

        private void button_Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void button_Save_Click(object sender, RoutedEventArgs e)
        {
            BillingToolBoxSettings.Default.BDD_Directory = textBox_BDD.Text;

            BillingToolBoxSettings.Default.MergeFolders.Clear();

            foreach (var item in listBox_Selected.Items)
            {
                BillingToolBoxSettings.Default.MergeFolders.Add(item.ToString());
            }

            BillingToolBoxSettings.Default.Save();
            Close();
        }
    }
}
