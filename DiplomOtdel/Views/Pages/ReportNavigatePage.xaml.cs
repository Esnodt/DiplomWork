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

namespace DiplomOtdel.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для ReportNavigatePage.xaml
    /// </summary>
    public partial class ReportNavigatePage : Page
    {
        public ReportNavigatePage()
        {
            InitializeComponent();
        }

        private void ButtonReceptoin_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new T1Test());
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void ButtonDismiss_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new T8Test());
        }
    }
}
