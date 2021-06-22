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
    /// Логика взаимодействия для Authoization.xaml
    /// </summary>
    public partial class Authoization : Page
    {
        public Authoization()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }


        private void btnPassword_Click(object sender, RoutedEventArgs e)
        {
            if (txbPassword.Visibility == Visibility.Visible)
            {

                txbPasswordTB.Text = txbPassword.Password;
                txbPassword.Visibility = Visibility.Collapsed;
                txbPasswordTB.Visibility = Visibility.Visible;
            }

            else
            {
                txbPassword.Visibility = Visibility.Visible;
                txbPasswordTB.Visibility = Visibility.Collapsed;
            }
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            {
                if (txbLogin.Text == "admin" && txbPassword.Password == "admin")

                {
                    NavigationService.Navigate(new CaptchaTest());
                }

                if (txbLogin.Text == "user" && txbPassword.Password == "user")

                {
                    NavigationService.Navigate(new UserCaptchaTest());
                }


                else
                {
                    MessageBox.Show("Вы ввели неверные данные", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void txbLogin_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txbLogin.Text != "" & txbPassword.Password != "")
            {
                btnLogin.IsEnabled = true;
            }

            else
            {
                btnLogin.IsEnabled = false;
            }
        }

        private void txbPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (txbLogin.Text != "" & txbPassword.Password != "")
            {
                btnLogin.IsEnabled = true;
            }

            else
            {
                btnLogin.IsEnabled = false;
            }
        }
    }
}
