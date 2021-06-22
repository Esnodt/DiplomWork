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
    /// Логика взаимодействия для UserCaptchaTest.xaml
    /// </summary>
    public partial class UserCaptchaTest : Page
    {
        public UserCaptchaTest()
        {
            InitializeComponent();
            CaptchaText.Text = (new Random().Next(1000000, 9999999).ToString());
        }

        private void btnGo_Click(object sender, RoutedEventArgs e)
        {
            {
                if (txbforlogin.Text == CaptchaText.Text)
                {
                    NavigationService.Navigate(new UserMainPage());
                }

                else
                {
                    MessageBox.Show("Вы ввели неверные данные", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    CaptchaText.Text = (new Random().Next(1000000, 9999999).ToString());

                    txbforlogin.Text = "";
                }
            }
        }

        private void ButtonHelp_Click(object sender, RoutedEventArgs e)
        {
            CaptchaText.Text = (new Random().Next(1000000, 9999999).ToString());
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
