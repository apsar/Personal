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

namespace Starvis
{
    /// <summary>
    /// Interaction logic for HotKey.xaml
    /// </summary>
    public partial class HotKey : UserControl
    {
        public HotKey()
        {
            InitializeComponent();
            PopulateGrid();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            var db = new Models();
            string text = txtCopy.Text;
            string textCommand = txtText.Text;
            string voice = txtVoice.Text;
            if (!string.IsNullOrWhiteSpace(text) && !string.IsNullOrWhiteSpace(textCommand) && !string.IsNullOrWhiteSpace(voice))
            {
                var web = new HotKeyDB { Value = text, TextCommand = textCommand, VoiceCommand = voice };
                db.HotKeyDB.Add(web);
                db.SaveChanges();
                ResetFields();
                lblValidation.Visibility = Visibility.Hidden;
            }
            else
            {
                lblValidation.Visibility = Visibility.Visible;
            }


        }
        void ResetFields()
        {
            txtCopy.Text = string.Empty;
            txtText.Text = string.Empty;
            txtVoice.Text = string.Empty;
            PopulateGrid();
        }
        void PopulateGrid()
        {
            var db = new Models();
            dataGrid.ItemsSource = db.HotKeyDB.ToList();


        }
    }
}
