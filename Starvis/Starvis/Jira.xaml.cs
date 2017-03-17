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
    /// Interaction logic for Jira.xaml
    /// </summary>
    public partial class Jira : UserControl
    {
        public Jira()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            datagrid.ItemsSource = new Models().JIRADB.ToList();
        }

        private void SelectCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!SelectCategory.IsLoaded)
                return;
            if (SelectCategory.SelectedIndex == 1)
            {
                SelectProject.Visibility = Visibility.Hidden;
                lblSelectProject.Visibility = Visibility.Hidden;
                lblJIRAID.Visibility = Visibility.Hidden;
                JIRAID.Visibility = Visibility.Hidden;
                lblQuery.Visibility = Visibility.Visible;
                QueryBox.Visibility = Visibility.Visible;
            }
            else
            {
                SelectProject.Visibility = Visibility.Visible;
                lblSelectProject.Visibility = Visibility.Visible;
                lblJIRAID.Visibility = Visibility.Visible;
                JIRAID.Visibility = Visibility.Visible;
                lblQuery.Visibility = Visibility.Hidden;
                QueryBox.Visibility = Visibility.Hidden;
            }

            lblTextCommand.Visibility = Visibility.Visible;
            lblVoiceCommand.Visibility = Visibility.Visible;
            TextCommand.Visibility = Visibility.Visible;
            VoiceCommand.Visibility = Visibility.Visible;
            btnCreate.Visibility = Visibility.Visible;
            btnReset.Visibility = Visibility.Visible;
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            if (SelectCategory.SelectedIndex == 0)
            {
                string url = null;
                if (SelectProject.Text == "REO")
                {
                    url = "https://jira.solutionstarit.com/browse/RCC-" + JIRAID.Text;
                }
                else if (SelectProject.Text == "Liberty")
                {
                    url = "https://jira.solutionstarit.com/browse/CAS-" + JIRAID.Text;
                }
                else if (SelectProject.Text == "Apollo")
                {
                    url = "https://jira.solutionstarit.com/browse/AUC-" + JIRAID.Text;
                }
                else if (SelectProject.Text == "Xome")
                {
                    url = "https://jira.solutionstarit.com/browse/XM-" + JIRAID.Text;
                }

                new BaseWindow().JIRAInsertUpdate(SelectProject.Text, url, TextCommand.Text, VoiceCommand.Text);
            }
            else
            {
                string url = "https://jira.solutionstarit.com/issues/?jql=" + QueryBox.Text;
                new BaseWindow().JIRAInsertUpdate("", url, TextCommand.Text, VoiceCommand.Text);
            }
            datagrid.ItemsSource = new Models().JIRADB.ToList();
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            SelectProject.SelectedIndex = 0;
            JIRAID.Text = "";
            QueryBox.Text = "";
        }
    }
}
