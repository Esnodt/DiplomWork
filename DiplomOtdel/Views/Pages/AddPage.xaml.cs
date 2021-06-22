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
    /// Логика взаимодействия для AddPage.xaml
    /// </summary>
    public partial class AddPage : Page
    {
        public AddPage()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            tbGender.ItemsSource = dbcontext.db.GenderTable.Select(item => item.Gender).ToList();
            tbCondition.ItemsSource = dbcontext.db.EmployeeStatus.Select(item => item.Condition).ToList();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MainInfo addMaininfo = new MainInfo();
                AdditionalInformation AddAdditionalInformation = new AdditionalInformation();
                PhotoEmployee addPhotoEmployee = new PhotoEmployee();
                GenderTable adddGenderTable = new GenderTable();
                WorkSchedule addWorkSchedule = new WorkSchedule();
                Salary addSalary = new Salary();
                EmploymentRecord addEmploymentRecord = new EmploymentRecord();
                Passport addPassport = new Passport();
                EmployeeStatus addEmployeeStatus = new EmployeeStatus();

                var addGender = dbcontext.db.GenderTable.FirstOrDefault(item => item.Gender == tbGender.Text);
                var addStatus = dbcontext.db.EmployeeStatus.FirstOrDefault(item => item.Condition == tbCondition.Text);

                addMaininfo.idPhotoEmployee = addPhotoEmployee.ID;
                addMaininfo.idAdditionalInformation = AddAdditionalInformation.ID;
                addMaininfo.idPassport = AddAdditionalInformation.ID;
                addMaininfo.idEmploymentRecord = addEmploymentRecord.ID;
                addMaininfo.idWorkSchedule = addWorkSchedule.ID;
                addMaininfo.idSalary = AddAdditionalInformation.ID;
                addMaininfo.idEmployeeStatus = addStatus.ID;
                AddAdditionalInformation.idGender = addGender.ID;

                MemoryStream stream = new MemoryStream();
                JpegBitmapEncoder encoder = new JpegBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create((BitmapImage)imgLoad.Source));
                encoder.Save(stream);
                addPhotoEmployee.Photo = stream.ToArray();

                addMaininfo.Name = tbName.Text;
                addMaininfo.Surname = tbSurname.Text;
                addMaininfo.Patronymic = tbPatronymic.Text;
                addMaininfo.ServiceNote = tbServiceNote.Text;

                AddAdditionalInformation.DateOfBirth = tbpDateOfBirth.SelectedDate;
                AddAdditionalInformation.Nationality = tbNationality.Text;
                AddAdditionalInformation.Citizenship = tbCitizenship.Text;
                AddAdditionalInformation.PhoneNumber = tbPhoneNumber.Text;

                addEmploymentRecord.Education = tbEducation.Text;
                addEmploymentRecord.Specialization = tbSpecialization.Text;
                addEmploymentRecord.DateOfFillingIn = tbpDateOfFillingIn.SelectedDate;
                addEmploymentRecord.TotalWorkExperience = tbTotalWorkExperience.Text;

                addPassport.Issued = tbIssued.Text;
                addPassport.DateOfIssue = tbpDateOfIssue.SelectedDate;
                addPassport.DivisionCode = tbDivisionCode.Text;
                addPassport.SerialNumber = tbSerialNumber.Text;
                addPassport.PassportCode = tbPassportCode.Text;

                addSalary.TheAmount = tbTheAmount.Text;
                addSalary.Allowance = tbAllowance.Text;
                addSalary.LastIssueDate = tbpLastIssueDate.SelectedDate;

                addWorkSchedule.StartDate = tbpStartTime.SelectedDate;
                addWorkSchedule.ShiftType = tbShiftType.Text;

                dbcontext.db.MainInfo.Add(addMaininfo);
                dbcontext.db.AdditionalInformation.Add(AddAdditionalInformation);
                dbcontext.db.PhotoEmployee.Add(addPhotoEmployee);
                dbcontext.db.EmploymentRecord.Add(addEmploymentRecord);
                dbcontext.db.WorkSchedule.Add(addWorkSchedule);
                dbcontext.db.Salary.Add(addSalary);
                dbcontext.db.Passport.Add(addPassport);

                dbcontext.db.SaveChanges();

                MessageBox.Show("Вы успешно добавили данные", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            catch
            {
                MessageBox.Show("Ошибка, возможно заполнены не все обязательные поля", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        OpenFileDialog imgFile = new OpenFileDialog();
        private void buttonimage_Click(object sender, RoutedEventArgs e)
        {
            imgFile.Filter = "image (*.png *.jpg *.jpeg .jfif) | *.png; *.jpg; *.lpeg; *.jfif";
            if (imgFile.ShowDialog() == true)
            {
                BitmapImage imgBitmap = new BitmapImage(new Uri(imgFile.FileName));
                imgLoad.Source = imgBitmap;
            }
        }

        private void tbPhoneNumber_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "0123456789+-".IndexOf(e.Text) < 0;
        }

        private void tbDivisionCode_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "0123456789-".IndexOf(e.Text) < 0;
        }

        private void tbSerialNumber_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "0123456789".IndexOf(e.Text) < 0;
        }

        private void tbPassportCode_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "0123456789".IndexOf(e.Text) < 0;
        }

        private void tbTheAmount_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "0123456789".IndexOf(e.Text) < 0;
        }

        private void tbAllowance_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "0123456789".IndexOf(e.Text) < 0;
        }

    }
}
