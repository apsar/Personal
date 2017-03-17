using System;
using System.Collections.Generic;
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
using StarvisDB;
using Microsoft.EntityFrameworkCore;

namespace Starvis
{
    /// <summary>
    /// Interaction logic for Outlook.xaml
    /// </summary>
    public partial class Outlook : UserControl
    {
        public Outlook()
        {
            InitializeComponent();
            Loaded += Window_Loaded;
        }

        private Models models { get; set; }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // do work here
            models = new Models();
            dataGrid.ItemsSource = models.OutlookDB.ToList();
        }

        private void commandType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!commandType.IsLoaded)
            {
                return;
            }
            int index = commandType.SelectedIndex;
            
            switch (index)
            {
                case 0:
                    ALLSTACK.Visibility = Visibility.Visible;
                    COMPOSESTACK.Visibility = Visibility.Hidden;
                    SEARCHSTACK.Visibility = Visibility.Hidden;
                    READSTACK.Visibility = Visibility.Hidden;
                    break;
                case 1:
                    ALLSTACK.Visibility = Visibility.Hidden;
                    COMPOSESTACK.Visibility = Visibility.Visible;
                    SEARCHSTACK.Visibility = Visibility.Hidden;
                    READSTACK.Visibility = Visibility.Hidden;
                    break;
                case 2:
                    ALLSTACK.Visibility = Visibility.Hidden;
                    COMPOSESTACK.Visibility = Visibility.Hidden;
                    SEARCHSTACK.Visibility = Visibility.Visible;
                    READSTACK.Visibility = Visibility.Hidden;
                    break;
                case 3:
                    ALLSTACK.Visibility = Visibility.Hidden;
                    COMPOSESTACK.Visibility = Visibility.Hidden;
                    SEARCHSTACK.Visibility = Visibility.Hidden;
                    READSTACK.Visibility = Visibility.Visible;
                    break;
            }
        }

        private void addComposeMessageCommand_Click(object sender, RoutedEventArgs e)
        {
            OutlookDB row = new OutlookDB() {
                VoiceCommand = voiceCommandTxt.Text,
                TextCommand = textCommandTxt.Text,
                Subject = Subject.Text,
                Body = EmailBody.Text,
                To = ToEmail.Text,
                Type = commandType.Text
            };
            new BaseWindow().OutlookInsert(row);
            dataGrid.ItemsSource = models.OutlookDB.ToList();
        }

        private void addSearchCommand_Click(object sender, RoutedEventArgs e)
        {
            OutlookDB row = new OutlookDB()
            {
                VoiceCommand = voiceCommandTxt.Text,
                TextCommand = textCommandTxt.Text,
//                To = ToEmails.Text,
                Type = commandType.Text,
                SearchKey = searchKey.Text,
//                From = fromEmails.Text
            };
            new BaseWindow().OutlookInsert(row);
            dataGrid.ItemsSource = models.OutlookDB.ToList();
        }

        private void addReadCommand_Click(object sender, RoutedEventArgs e)
        {
            OutlookDB row = new OutlookDB()
            {
                VoiceCommand = voiceCommandTxt.Text,
                TextCommand = textCommandTxt.Text,
//                To = readToEmails.Text,
//                From = readfromEmails.Text,
                Type = commandType.Text,
                SearchKey = containsKey.Text
            };
            new BaseWindow().OutlookInsert(row);
            dataGrid.ItemsSource = models.OutlookDB.ToList();
        }
    }
}
