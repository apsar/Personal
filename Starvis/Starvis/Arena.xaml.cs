using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using Starvis.Utilities;
using StarvisDB;

namespace Starvis
{
    /// <summary>
    /// Interaction logic for Arena.xaml
    /// </summary>
    public partial class Arena : UserControl
    {

        ListBox dragSource = null;

        ObservableCollection<string> itemlist = new ObservableCollection<string>();


        private void ListBox_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ListBox parent = (ListBox)sender;
            dragSource = parent;
            object data = GetDataFromListBox(dragSource, e.GetPosition(parent));

            if (data != null)
            {
                DragDrop.DoDragDrop(parent, data, DragDropEffects.Move);
            }
        }
        #region GetDataFromListBox(ListBox,Point)
        private static object GetDataFromListBox(ListBox source, Point point)
        {
            UIElement element = source.InputHitTest(point) as UIElement;
            if (element != null)
            {
                object data = DependencyProperty.UnsetValue;
                while (data == DependencyProperty.UnsetValue)
                {
                    data = source.ItemContainerGenerator.ItemFromContainer(element);
                    if (data == DependencyProperty.UnsetValue)
                    {
                        element = VisualTreeHelper.GetParent(element) as UIElement;
                    }
                    if (element == source)
                    {
                        return null;
                    }
                }
                if (data != DependencyProperty.UnsetValue)
                {
                    return data;
                }
            }
            return null;
        }

        #endregion


        private void ListBox_Drop(object sender, DragEventArgs e)
        {
            ListBox parent = (ListBox)sender;
            object data = e.Data.GetData(typeof(string));

            itemlist.Remove(data.ToString());
            listBox.ItemsSource = itemlist;
            parent.Items.Add(data);
        }
        public Arena()
        {
            InitializeComponent();
            GetInstalledApps();
            setSource();
        }




        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            // Set filter for file extension and default file extension
            dlg.DefaultExt = ".txt";
            dlg.Filter = "Text documents (.txt)|*.txt";

            // Display OpenFileDialog by calling ShowDialog method
            Nullable<bool> result = dlg.ShowDialog();

            // Get the selected file name and display in a TextBox
            if (result == true)
            {
                // Open document
                string filename = dlg.FileName;
                FileNameTextBox.Text = filename;
            }
        }
        private void Button_Click_Create(object sender, RoutedEventArgs e)
        {

            string keyValue = this.keyValue.Text;
            string voiceValue = this.VoiceValue.Text;
            string result = string.Empty;
            string configName = this.ConfigName.Text;
            foreach (var item in listBox1.Items)
            {
                result = result + ";" + item;
            }


            using (var db = new Models())
            {
                var blog = new ArenaDB { Name = "Name1", AppList = result, TextCommand = keyValue, VoiceCommand = voiceValue };
                db.ArenaDB.Add(blog);
                db.SaveChanges();
            }


        }

        public void GetInstalledApps()
        {
            string uninstallKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
            using (RegistryKey rk = Registry.LocalMachine.OpenSubKey(uninstallKey))
            {
                foreach (string skName in rk.GetSubKeyNames())
                {
                    using (RegistryKey sk = rk.OpenSubKey(skName))
                    {
                        try
                        {
                            if (!string.IsNullOrEmpty(sk.GetValue("DisplayName").ToString()) && !string.IsNullOrEmpty(sk.GetValue("InstallLocation").ToString()))
                                itemlist.Add(sk.GetValue("DisplayName").ToString());

                        }
                        catch (Exception ex)
                        { }
                    }
                }
                listBox.ItemsSource = itemlist;
                //  label.Text = listBox.Items.Count.ToString();
            }
        }


        public void setSource()
        {
            using (var db = new Models())
            {

                DataGrid1.ItemsSource = db.ArenaDB.ToList();

            }
        }

        private void Button_Click_Reset(object sender, RoutedEventArgs e)
        {


        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            // Set filter for file extension and default file extension
            dlg.DefaultExt = ".exe";
            dlg.Filter = "*.exe";

            // Display OpenFileDialog by calling ShowDialog method
            Nullable<bool> result = dlg.ShowDialog();

            // Get the selected file name and display in a TextBox
            if (result == true)
            {
                // Open document
                string filename = dlg.FileName;
                FileNameTextBox.Text = filename;
            }
        }

        private void FileNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void listBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
