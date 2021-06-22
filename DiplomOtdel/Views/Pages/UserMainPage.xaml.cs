using DiplomOtdel.Context;
using DiplomOtdel.ModelSQL;
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
    /// Логика взаимодействия для UserMainPage.xaml
    /// </summary>
    public partial class UserMainPage : Page
    {
        public UserMainPage()
        {
            InitializeComponent();
        }

        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            MainInfo editrow = (MainInfo)ListMain.SelectedItem;
            if (editrow != null)
            {
                NavigationService.Navigate(new UserEditPage(editrow));
            }

            else
            {
                MessageBox.Show("Вы не выбрали элемент", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new UserAddPAge());
        }

        private void ButtonMoreInfo_Click(object sender, RoutedEventArgs e)
        {
            MainInfo morerow = (MainInfo)ListMain.SelectedItem;
            if (morerow != null)
            {
                NavigationService.Navigate(new UserMoreInfoPage(morerow));
            }
            else
            {
                MessageBox.Show("Вы не выбрали элемент", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void TextBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            ListMain.ItemsSource = dbcontext.db.MainInfo.Where(item => item.Name.Contains(TextBoxSearch.Text) || item.EmploymentRecord.Specialization.Contains(TextBoxSearch.Text) || item.Surname.Contains(TextBoxSearch.Text)).ToList();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ListMain.ItemsSource = dbcontext.db.MainInfo.ToList();
        }
    }
}
