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
    /// Логика взаимодействия для MoreInfoPage.xaml
    /// </summary>
    public partial class MoreInfoPage : Page
    {
        private MainInfo moremain;
        public MoreInfoPage(MainInfo moremain)
        {
            InitializeComponent();
            this.moremain = moremain;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ListMainMoreInfo.ItemsSource = dbcontext.db.MainInfo.Where(item => item.ID == moremain.ID).ToList();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
