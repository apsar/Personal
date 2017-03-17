using StarvisDB;
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

namespace Starvis
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : UserControl
    {
        private string gender = null;
        public Settings()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            LangPre.SelectedIndex = 0;
            Models models = new Models();
            SettingsDB rec = models.SettingsDB.Where(q => q.Key == "Name").FirstOrDefault();
            if (rec != null)
                Name.Text = rec.Value;
            rec = models.SettingsDB.Where(q => q.Key == "Gender").FirstOrDefault();
            if (rec != null)
            {
                if (rec.Value == "Male")
                    G_Male.IsChecked = true;
                if (rec.Value == "Female")
                    G_Female.IsChecked = true;
            }
            rec = models.SettingsDB.Where(q => q.Key == "Language Preference").FirstOrDefault();
            if (rec != null)
            {
                LangPre.Text = rec.Value;
            }
            rec = models.SettingsDB.Where(q => q.Key == "BING API Key").FirstOrDefault();
            if (rec != null)
                BINGKEY.Text = rec.Value;
            rec = models.SettingsDB.Where(q => q.Key == "Mode").FirstOrDefault();
            if (rec != null)
                Mode.IsChecked = rec.Value == "Voice Mode" ? true : false;

        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            gender = (sender as RadioButton).Content.ToString();
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            gender = (sender as RadioButton).Content.ToString();
        }

        public bool Validate()
        {
            bool res = true;
            BaseWindow obj = new BaseWindow();

            if (String.IsNullOrEmpty(Name.Text))
            {
                if(obj.GetCurrentModeType() == "Voice Mode")
                    TextToSpeech.SpeakAsync("Please fill up the Name!!!");
                res = false;
            }
            if (String.IsNullOrEmpty(gender))
            {
                if (obj.GetCurrentModeType() == "Voice Mode")
                    TextToSpeech.SpeakAsync("Please select the gender!!!");
                res = false;
            }

            if(LangPre.SelectedItem == null)
            {
                if (obj.GetCurrentModeType() == "Voice Mode")
                    TextToSpeech.SpeakAsync("Please select the Language Preference!!!");
                res = false;
            }

            if(String.IsNullOrEmpty(BINGKEY.Text))
            {
                if (obj.GetCurrentModeType() == "Voice Mode")
                    TextToSpeech.SpeakAsync("Please fill up the BING API Key!!!");
                res = false;
            }

            return res;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Validate())
            {
                BaseWindow obj = new BaseWindow();
                obj.SettingsInsertUpdate("Name", Name.Text);
                obj.SettingsInsertUpdate("Gender", gender);
                obj.SettingsInsertUpdate("Language Preference", LangPre.Text);
                obj.SettingsInsertUpdate("BING API Key", BINGKEY.Text);
                obj.SettingsInsertUpdate("Mode", Mode.IsChecked == true ? "Voice Mode" : "Text Mode");

                if(obj.GetCurrentModeType() == "Voice Mode")
                    TextToSpeech.SpeakAsync("Successfully updated your information!!!");
            }
        }
    }
}
