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
using Starvis.Utilities;
using Microsoft.CognitiveServices.SpeechRecognition;
using StarvisDB;
using MahApps.Metro.Controls;
using System.Windows.Media.Animation;
using Starvis.Properties;

namespace Starvis
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow

    {
        public  MainWindow()
        {
            InitializeComponent();
        }

        private void StackPanel_MouseEnter(object sender, MouseEventArgs e)
        {
            Border sp = sender as Border;
            DoubleAnimation db = new DoubleAnimation();
            //db.From = 12;
            db.To = 150;
            db.Duration = TimeSpan.FromSeconds(0.5);
            db.AutoReverse = false;
            db.RepeatBehavior = new RepeatBehavior(1);
            sp.BeginAnimation(StackPanel.HeightProperty, db);
            MainWindowTest.Height = 400;
        }

        private void StackPanel_MouseLeave(object sender, MouseEventArgs e)
        {
            Border sp = sender as Border;
            DoubleAnimation db = new DoubleAnimation();
            //db.From = 12;
            db.To = 12;
            db.Duration = TimeSpan.FromSeconds(0.5);
            db.AutoReverse = false;
            db.RepeatBehavior = new RepeatBehavior(1);
            sp.BeginAnimation(StackPanel.HeightProperty, db);
            MainWindowTest.Height = 600;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Profiles_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void btnLeftMenuHide_Click(object sender, RoutedEventArgs e)
        {
            ShowHideMenu("sbHideLeftMenu", btnLeftMenuHide, btnLeftMenuShow, pnlLeftMenu);
        }


        private void btnLeftMenuShow_Click(object sender, RoutedEventArgs e)
        {
            ShowHideMenu("sbShowLeftMenu", btnLeftMenuHide, btnLeftMenuShow, pnlLeftMenu);
        }
        private void ShowHideMenu(string Storyboard, Button btnHide, Button btnShow, StackPanel pnl)
        {
            Storyboard sb = Resources[Storyboard] as Storyboard;
            sb.Begin(pnl);

            if (Storyboard.Contains("Show"))
            {
                btnHide.Visibility = System.Windows.Visibility.Visible;
                btnShow.Visibility = System.Windows.Visibility.Hidden;
            }
            else if (Storyboard.Contains("Hide"))
            {
                btnHide.Visibility = System.Windows.Visibility.Hidden;
                btnShow.Visibility = System.Windows.Visibility.Visible;
            }

        }
        private void HideAllControl()
        {
            ProfileTab.Visibility = System.Windows.Visibility.Hidden;
            OutlookTab.Visibility = System.Windows.Visibility.Hidden;
            JiraTab.Visibility = System.Windows.Visibility.Hidden;
            
                BrowseTab.Visibility = System.Windows.Visibility.Hidden;
          
                ArenaTab.Visibility = System.Windows.Visibility.Hidden;
           
                SettingsTab.Visibility = System.Windows.Visibility.Hidden;
            
                VisualStudioTab.Visibility = System.Windows.Visibility.Hidden;
           
                HotKeyTab.Visibility = System.Windows.Visibility.Hidden;
           

        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            HideAllControl();
            TabItem ti = Tabs.SelectedItem as TabItem;
            if ("Profiles".Equals(ti.Name))
            {
                ProfileTab.Visibility = System.Windows.Visibility.Visible;
            }
            else if ("Outlook".Equals(ti.Name))
            {
                OutlookTab.Visibility = System.Windows.Visibility.Visible;
            }
            else if ("Jira".Equals(ti.Name))
            {
                JiraTab.Visibility = System.Windows.Visibility.Visible;
            }

            else if ("Browse".Equals(ti.Name))
            {
                BrowseTab.Visibility = System.Windows.Visibility.Visible;
            }
            else if ("Arena".Equals(ti.Name))
            {
                ArenaTab.Visibility = System.Windows.Visibility.Visible;
            }
            else if ("Settings".Equals(ti.Name))
            {
                SettingsTab.Visibility = System.Windows.Visibility.Visible;
            }

            else if ("VisualStudio".Equals(ti.Name))
            {
                VisualStudioTab.Visibility = System.Windows.Visibility.Visible;
            }
            else if ("HotKey".Equals(ti.Name))
            {
                HotKeyTab.Visibility = System.Windows.Visibility.Visible;
            }


        }


        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)

        {
           
            SpeechToText.ConverSpeechToText();

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Batch b = new Batch();
              string textValue = this.MainText.Text;
            if(!string.IsNullOrEmpty(textValue))
            {
                string[] array = textValue.Split(' ');
                if (!string.IsNullOrEmpty(array[0]) && !string.IsNullOrEmpty(array[1]))
                {
                    if ("a".Equals(array[0].ToLower()))
                    {
                        b.findexe(array[1]);
                    }
                }
            }
        }

        private void MainWindowTest_Loaded(object sender, RoutedEventArgs e)
        {
            new BaseWindow().SettingsInsertUpdate("Mode", "Text Mode");
        }

        private void Listen_Click(object sender, RoutedEventArgs e)
        {
            SpeechToText.ConverSpeechToText();
        }
    }
}
