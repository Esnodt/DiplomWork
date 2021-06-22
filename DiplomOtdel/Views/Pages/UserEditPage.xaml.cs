using DiplomOtdel.Context;
using DiplomOtdel.ModelSQL;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для UserEditPage.xaml
    /// </summary>
    public partial class UserEditPage : Page
    {
        private MainInfo usereditmain;
        public UserEditPage()

        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
        public UserEditPage(MainInfo usereditmain)
        {
            InitializeComponent();
            this.usereditmain = usereditmain;

            if (usereditmain.PhotoEmployee.Photo != null)
            {
                BitmapImage bitmap = new BitmapImage();
                using (MemoryStream stream = new MemoryStream(usereditmain.PhotoEmployee.Photo))
                {
                    bitmap.BeginInit();
                    bitmap.CacheOption = BitmapCacheOption.OnLoad;
                    bitmap.StreamSource = stream;
                    bitmap.EndInit();
                }
                imgLoad.Source = bitmap;
            }

            tbName.Text = usereditmain.Name;
            tbSurname.Text = usereditmain.Surname;
            tbPatronymic.Text = usereditmain.Patronymic;
            tbServiceNote.Text = usereditmain.ServiceNote;

            tbpDateOfBirth.SelectedDate = usereditmain.AdditionalInformation.DateOfBirth;
            tbNationality.Text = usereditmain.AdditionalInformation.Nationality;
            tbCitizenship.Text = usereditmain.AdditionalInformation.Citizenship;
            tbPhoneNumber.Text = usereditmain.AdditionalInformation.PhoneNumber;

            tbEducation.Text = usereditmain.EmploymentRecord.Education;
            tbSpecialization.Text = usereditmain.EmploymentRecord.Specialization;
            tbpDateOfFillingIn.SelectedDate = usereditmain.EmploymentRecord.DateOfFillingIn;
            tbTotalWorkExperience.Text = usereditmain.EmploymentRecord.TotalWorkExperience;

            tbServiceNote.Text = usereditmain.ServiceNote;

            tbpStartTime.SelectedDate = usereditmain.WorkSchedule.StartDate;
            tbShiftType.Text = usereditmain.WorkSchedule.ShiftType;

            tbGender.SelectedItem = usereditmain.AdditionalInformation.GenderTable.Gender;
            tbGender.ItemsSource = dbcontext.db.GenderTable.Select(item => item.Gender).ToList();

        }

        private void buttonimage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileImg = new OpenFileDialog();
            fileImg.Filter = "Image (*.png; *.jpg; *.jpeg;) | *.png; *.jpg; *.jpeg;";
            if (fileImg.ShowDialog() == true)
            {
                BitmapImage imgBitmap = new BitmapImage(new Uri(fileImg.FileName));
                imgLoad.Source = imgBitmap;
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            MainInfo Save = dbcontext.db.MainInfo.FirstOrDefault(item => item.ID == usereditmain.ID);

            Save.Name = tbName.Text;
            Save.Surname = tbSurname.Text;
            Save.Patronymic = tbPatronymic.Text;
            Save.ServiceNote = tbServiceNote.Text;

            Save.AdditionalInformation.DateOfBirth = tbpDateOfBirth.SelectedDate;
            Save.AdditionalInformation.Nationality = tbNationality.Text;
            Save.AdditionalInformation.Citizenship = tbCitizenship.Text;
            Save.AdditionalInformation.PhoneNumber = tbPhoneNumber.Text;

            Save.EmploymentRecord.Education = tbEducation.Text;
            Save.EmploymentRecord.Specialization = tbSpecialization.Text;
            Save.EmploymentRecord.DateOfFillingIn = tbpDateOfFillingIn.SelectedDate;
            Save.EmploymentRecord.TotalWorkExperience = tbTotalWorkExperience.Text;


            Save.WorkSchedule.StartDate = tbpStartTime.SelectedDate;
            Save.WorkSchedule.ShiftType = tbShiftType.Text;

            var editgender = dbcontext.db.GenderTable.FirstOrDefault(item => item.Gender == tbGender.Text);
            usereditmain.AdditionalInformation.idGender = editgender.ID;

            MemoryStream stream = new MemoryStream();
            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create((BitmapImage)imgLoad.Source));
            encoder.Save(stream);
            Save.PhotoEmployee.Photo = stream.ToArray();

            dbcontext.db.SaveChanges();

            MessageBox.Show("Вы изменили данные", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);

            NavigationService.GoBack();
        }
    }
}
