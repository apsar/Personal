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
    /// Interaction logic for Outlook.xaml
    /// </summary>
    public partial class Outlook : UserControl
    {
        public Outlook()
        {
            InitializeComponent();
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!comboBox.IsLoaded)
                return;
            int index = comboBox.SelectedIndex;
            
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

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void textBox2_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
