using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Логика взаимодействия для SupportPage.xaml
    /// </summary>
    public partial class SupportPage : Page
    {
        public SupportPage()
        {
            InitializeComponent();
        }

        private void vkSup_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("https://vk.com/esnodt");
        }

        private void qSup_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("https://yandex.ru/q/h1kk4kyn/");
        }

        private void tgSup_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("https://t.me/Essnodt");
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
