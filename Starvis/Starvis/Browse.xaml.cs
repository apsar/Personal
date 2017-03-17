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
using System.Windows;

namespace Starvis
{
    /// <summary>
    /// Interaction logic for Browse.xaml
    /// </summary>
    public partial class Browse : UserControl
    {
        public Browse()
        {
            InitializeComponent();
            PopulateGrid();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            var db = new Models();
            string url = txtUrl.Text;
            string text = txtText.Text;
            string voice = txtVoice.Text;
            if (!string.IsNullOrWhiteSpace(text) && !string.IsNullOrWhiteSpace(url) && !string.IsNullOrWhiteSpace(voice))
            {
                lblValidation.Visibility = Visibility.Hidden;
                var web1 = new WebDB { URL = url, TextCommand = text, VoiceCommand = voice };
                db.WebDB.Add(web1);
                db.SaveChanges();

                ResetFields();
                PopulateGrid();
            }
            else
            {
                lblValidation.Visibility = Visibility.Visible;
            }
     
          
        }
        void ResetFields()
        {
            txtUrl.Text = string.Empty;
            txtText.Text = string.Empty;
            txtVoice.Text = string.Empty;
        }
        void PopulateGrid()
        {
            var db = new Models();
            dataGrid.ItemsSource = db.WebDB.ToList();
          
            
        }
    }
}
