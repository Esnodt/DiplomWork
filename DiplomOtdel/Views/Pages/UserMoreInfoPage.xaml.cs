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
    /// Логика взаимодействия для UserMoreInfoPage.xaml
    /// </summary>
    public partial class UserMoreInfoPage : Page
    {
        private MainInfo usermoremain;
        public UserMoreInfoPage(MainInfo usermoremain)
        {
            InitializeComponent();
            this.usermoremain = usermoremain;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ListMainMoreInfo.ItemsSource = dbcontext.db.MainInfo.Where(item => item.ID == usermoremain.ID).ToList();
        }
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
