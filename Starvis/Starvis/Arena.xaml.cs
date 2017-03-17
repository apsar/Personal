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
                    if (source.ItemContainerGenerator != null)
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
            GetInstalledApps();
            setSource();
        }

        public void GetInstalledApps()
        {
            resetListBox();
            itemlist = new ObservableCollection<string>();
            
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


        public void resetListBox()
        {
           // listBox1.ItemsSource = new List<String>();
        }
        private void Button_Click_Reset(object sender, RoutedEventArgs e)
        {

            GetInstalledApps();
            setSource();
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
            
        }

        private void FileNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void listBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void VoiceValue_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
