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
    /// Логика взаимодействия для EditPage.xaml
    /// </summary>
    public partial class EditPage : Page
    {
        private MainInfo editmain;
        public EditPage()

        {
            InitializeComponent();
        }

        public EditPage(MainInfo editmain)
        {
            InitializeComponent();
            this.editmain = editmain;

            if (editmain.PhotoEmployee.Photo != null)
            {
                BitmapImage bitmap = new BitmapImage();
                using (MemoryStream stream = new MemoryStream(editmain.PhotoEmployee.Photo))
                {
                    bitmap.BeginInit();
                    bitmap.CacheOption = BitmapCacheOption.OnLoad;
                    bitmap.StreamSource = stream;
                    bitmap.EndInit();
                }
                imgLoad.Source = bitmap;
            }

            tbName.Text = editmain.Name;
            tbSurname.Text = editmain.Surname;
            tbPatronymic.Text = editmain.Patronymic;
            tbServiceNote.Text = editmain.ServiceNote;

            tbpDateOfBirth.SelectedDate = editmain.AdditionalInformation.DateOfBirth;
            tbNationality.Text = editmain.AdditionalInformation.Nationality;
            tbCitizenship.Text = editmain.AdditionalInformation.Citizenship;
            tbPhoneNumber.Text = editmain.AdditionalInformation.PhoneNumber;

            tbEducation.Text = editmain.EmploymentRecord.Education;
            tbSpecialization.Text = editmain.EmploymentRecord.Specialization;
            tbpDateOfFillingIn.SelectedDate = editmain.EmploymentRecord.DateOfFillingIn;
            tbTotalWorkExperience.Text = editmain.EmploymentRecord.TotalWorkExperience;

            tbIssued.Text = editmain.Passport.Issued;
            tbpDateOfIssue.SelectedDate = editmain.Passport.DateOfIssue;
            tbDivisionCode.Text = editmain.Passport.DivisionCode;
            tbSerialNumber.Text = editmain.Passport.SerialNumber;
            tbPassportCode.Text = editmain.Passport.PassportCode;

            tbTheAmount.Text = editmain.Salary.TheAmount;
            tbAllowance.Text = editmain.Salary.Allowance;
            tbpLastIssueDate.SelectedDate = editmain.Salary.LastIssueDate;

            tbServiceNote.Text = editmain.ServiceNote;

            tbpStartTime.SelectedDate = editmain.WorkSchedule.StartDate;
            tbShiftType.Text = editmain.WorkSchedule.ShiftType;

            tbGender.SelectedItem = editmain.AdditionalInformation.GenderTable.Gender;
            tbGender.ItemsSource = dbcontext.db.GenderTable.Select(item => item.Gender).ToList();

            tbCondition.SelectedItem = editmain.EmployeeStatus.Condition;
            tbCondition.ItemsSource = dbcontext.db.EmployeeStatus.Select(item => item.Condition).ToList();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            MainInfo Save = dbcontext.db.MainInfo.FirstOrDefault(item => item.ID == editmain.ID);

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

            Save.Passport.Issued = tbIssued.Text;
            Save.Passport.DateOfIssue = tbpDateOfIssue.SelectedDate;
            Save.Passport.DivisionCode = tbDivisionCode.Text;
            Save.Passport.SerialNumber = tbSerialNumber.Text;
            Save.Passport.PassportCode = tbPassportCode.Text;

            Save.Salary.TheAmount = tbTheAmount.Text;
            Save.Salary.Allowance = tbAllowance.Text;
            Save.Salary.LastIssueDate = tbpLastIssueDate.SelectedDate;

            Save.WorkSchedule.StartDate = tbpStartTime.SelectedDate;
            Save.WorkSchedule.ShiftType = tbShiftType.Text;

            var editgender = dbcontext.db.GenderTable.FirstOrDefault(item => item.Gender == tbGender.Text);
            editmain.AdditionalInformation.idGender = editgender.ID;

            var editcondition = dbcontext.db.EmployeeStatus.FirstOrDefault(item => item.Condition == tbCondition.Text);
            editmain.idEmployeeStatus = editcondition.ID;

            MemoryStream stream = new MemoryStream();
            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create((BitmapImage)imgLoad.Source));
            encoder.Save(stream);
            Save.PhotoEmployee.Photo = stream.ToArray();

            dbcontext.db.SaveChanges();

            MessageBox.Show("Вы изменили данные", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);

            NavigationService.GoBack();
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

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
