using System;
using System.Windows;
using System.Xml.Linq;
using BillingToolBox.Classes;

namespace BillingToolBox.Windows
{
    /// <summary>
    /// Interaction logic for PathTableAddEntryWindow.xaml
    /// </summary>
    public partial class PathTableAddEntryWindow : Window
    {
        private readonly string _path;
        private readonly PathTableEntry _entry;

        public PathTableAddEntryWindow()
        {
            InitializeComponent();
        }

        public PathTableAddEntryWindow(string path)
        {
            InitializeComponent();
            label_PathTablePath.Content = "Path Table: " + path;
            _path = path;
        }

        public PathTableAddEntryWindow(string path, PathTableEntry entry)
        {
            InitializeComponent();
            label_PathTablePath.Content = "Path Table: " + path;
            _path = path;
            _entry = entry;
            textBox_Mask.Text = _entry.Mask;
            textBox_Path.Text = _entry.Path;
            Title = "Update Path Table Entry";
        }

        private void button_Save_Click(object sender, RoutedEventArgs e)
        {
            if (_entry == null) // add new
            {
                if (textBox_Mask.Text != string.Empty && textBox_Path.Text != string.Empty)
                {
                    try
                    {
                        XDocument xDoc = XDocument.Load(_path);
                        var xMaskTable = new XElement("XMaskTable__x0024__x0024_");
                        xMaskTable.Add(new XElement("SeqNum", "xxxx"));
                        xMaskTable.Add(new XElement("Mask", textBox_Mask.Text));
                        xMaskTable.Add(new XElement("Path", textBox_Path.Text));
                        xMaskTable.Add(new XElement("Comments"));
                        xDoc.Root.Add(xMaskTable);
                        xDoc.Save(_path);
                        Tools.ShowMessagePopUpModal("Changes saved.");
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        Tools.ShowErrorPopUpModal(string.Format("Changes not saved: {0}", ex.Message));
                    }
                }
            }
            else // update old
            {
                if (textBox_Mask.Text != string.Empty && textBox_Path.Text != string.Empty)
                {
                    try
                    {
                        XDocument xDoc = XDocument.Load(_path);
                        foreach (var node in xDoc.Descendants("XMaskTable__x0024__x0024_"))
                        {
                            var mask = node.Descendants("Mask");
                            foreach (var ele in mask)
                            {
                                if (ele.Value == _entry.Mask)
                                {
                                    ele.Value = textBox_Mask.Text;
                                    var path = node.Descendants("Path");
                                    foreach (var xElement in path)
                                    {
                                        xElement.Value = textBox_Path.Text;

                                        xDoc.Save(_path);
                                        Tools.ShowMessagePopUpModal("Changes saved.");
                                        this.Close();
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Tools.ShowErrorPopUpModal(string.Format("Changes not saved: {0}", ex.Message));
                    }
                }
            }
        }

        private void button_Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
