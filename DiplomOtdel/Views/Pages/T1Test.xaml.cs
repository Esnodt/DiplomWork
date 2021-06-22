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
using Word = Microsoft.Office.Interop.Word;

namespace DiplomOtdel.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для T1Test.xaml
    /// </summary>
    public partial class T1Test : Page
    {
        private readonly string TemplateFileName = @"E:\Бланк принятий.docx";

        public T1Test()
        {
            InitializeComponent();
        }

        private void addt1Test_Click(object sender, RoutedEventArgs e)
        {
            var NameCompany = tbNameCompany.Text;
            var NubmerDocument = tbNubmerDocument.Text;
            var DateCreate = tbDateCreate.SelectedDate;
            var OKPO = tbOKPO.Text;
            var DateStartWork = tbDateStartWork.SelectedDate;
            var DateEndWork = tbDateEndWork.SelectedDate;
            var FullNameEmployee = tbFullNameEmployee.Text;
            var TableNubmer = tbTableNubmer.Text;

            var StructuralDivision = tbStructuralDivision.Text;
            var Post = tbPost.Text;
            var Education = tbEducation.Text;
            var KindOfWork = tbKindOfWork.Text;
            var Salary = tbSalary.Text;
            var Allowance = tbAllowance.Text;

            var TrialPeriod = tbTrialPeriod.Text;
            var ContractDate = tbContractDate.SelectedDate;
            var Number = tbNumber.Text;
            var Director = tbDirector.Text;
            var DateReview = tbDateReview.SelectedDate;

            var wordApp = new Word.Application();
            wordApp.Visible = false;

            try
            {
                var wordDocument = wordApp.Documents.Open(TemplateFileName);
                ReplaceWordStub("{NameCompany}", NameCompany, wordDocument);
                ReplaceWordStub("{NubmerDocument}", NubmerDocument, wordDocument);
                ReplaceWordStub("{DateCreate}", Convert.ToString(DateCreate.Value.ToString("yyyy-MM-dd")), wordDocument);
                ReplaceWordStub("{OKPO}", OKPO, wordDocument);
                ReplaceWordStub("{DateStartWork}", Convert.ToString(DateStartWork.Value.ToString("yyyy-MM-dd")), wordDocument);
                ReplaceWordStub("{DateEndWork}", Convert.ToString(DateEndWork.Value.ToString("yyyy-MM-dd")), wordDocument);
                ReplaceWordStub("{FullNameEmployee}", FullNameEmployee, wordDocument);
                ReplaceWordStub("{TableNubmer}", TableNubmer, wordDocument);

                ReplaceWordStub("{StructuralDivision}", StructuralDivision, wordDocument);
                ReplaceWordStub("{Post}", Post, wordDocument);
                ReplaceWordStub("{Education}", Education, wordDocument);
                ReplaceWordStub("{KindOfWork}", KindOfWork, wordDocument);
                ReplaceWordStub("{Salary}", Salary, wordDocument);
                ReplaceWordStub("{Allowance}", Allowance, wordDocument);

                ReplaceWordStub("{TrialPeriod}", TrialPeriod, wordDocument);
                ReplaceWordStub("{ContractDate}", ContractDate.Value.ToString("yyyy-MM-dd"), wordDocument);
                ReplaceWordStub("{Number}", Number, wordDocument);
                ReplaceWordStub("{Director}", Director, wordDocument);
                ReplaceWordStub("{DateReview}", DateReview.Value.ToString("yyyy-MM-dd"), wordDocument);

                wordDocument.SaveAs(@"E:/Приказ о принятии на работу.docx");

                MessageBox.Show("Отчет сформирован", "Уведомление");
            }
            catch
            {
                MessageBox.Show("Что-то пошло не так", "Уведомление");
            }
        }

        private void ReplaceWordStub(string stubToReplace, string text, Word.Document wordDocument)
        {
            var range = wordDocument.Content;
            range.Find.ClearFormatting();
            range.Find.Execute(FindText: stubToReplace, ReplaceWith: text);
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
