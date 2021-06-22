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
    /// Логика взаимодействия для T8Test.xaml
    /// </summary>
    public partial class T8Test : Page
    {

        private readonly string TemplateFileName = @"E:\Бланк увольнений.docx";
        public T8Test()
        {
            InitializeComponent();
        }


        private void Delete1Test_Click(object sender, RoutedEventArgs e)
        {
            var NameCompany = tbNameCompany.Text;
            var OKPO = tbOKPO.Text;
            var NubmerDocument = tbNubmerDocument.Text;
            var DateCreate = tbDateCreate.SelectedDate;
            var DateEndDocument = tbDateEndDocument.SelectedDate;
            var DateDismissal = tbDateDismissal.SelectedDate;
            var DismissalNumber = tbDismissalNumber.Text;
            var TableNubmer = tbTableNubmer.Text;

            var FullNameEmployee = tbFullNameEmployee.Text;
            var StructuralDivision = tbStructuralDivision.Text;
            var Post = tbPost.Text;
            var Reason = tbReason.Text;
            var GroundsDocument = tbGroundsDocument.Text;
            var GroundsDate = tbGroundsDate.SelectedDate;
            var GroundsNumber = tbGroundsNumber.Text;

            var Director = tbDirector.Text;
            var DateReview = tbDateReview.SelectedDate;

            var wordApp = new Word.Application();
            wordApp.Visible = false;

            try
            {
                var wordDocument = wordApp.Documents.Open(TemplateFileName);
                ReplaceWordStub("{NameCompany}", NameCompany, wordDocument);
                ReplaceWordStub("{OKPO}", OKPO, wordDocument);
                ReplaceWordStub("{NubmerDocument}", NubmerDocument, wordDocument);
                ReplaceWordStub("{DateCreate}", Convert.ToString(DateCreate.Value.ToString("yyyy-MM-dd")), wordDocument);
                ReplaceWordStub("{DateEndDocument}", Convert.ToString(DateEndDocument.Value.ToString("yyyy-MM-dd")), wordDocument);
                ReplaceWordStub("{DateDismissal}", Convert.ToString(DateDismissal.Value.ToString("yyyy-MM-dd")), wordDocument);
                ReplaceWordStub("{DismissalNumber}", DismissalNumber, wordDocument);
                ReplaceWordStub("{TableNubmer}", TableNubmer, wordDocument);

                ReplaceWordStub("{FullNameEmployee}", FullNameEmployee, wordDocument);
                ReplaceWordStub("{StructuralDivision}", StructuralDivision, wordDocument);
                ReplaceWordStub("{Post}", Post, wordDocument);
                ReplaceWordStub("{Reason}", Reason, wordDocument);
                ReplaceWordStub("{GroundsDocument}", GroundsDocument, wordDocument);
                ReplaceWordStub("{GroundsDate}", Convert.ToString(GroundsDate.Value.ToString("yyyy-MM-dd")), wordDocument);
                ReplaceWordStub("{GroundsNumber}", GroundsNumber, wordDocument);

                ReplaceWordStub("{Director}", Director, wordDocument);
                ReplaceWordStub("{DateReview}", DateReview.Value.ToString("yyyy-MM-dd"), wordDocument);

                wordDocument.SaveAs(@"E:/Приказ о увольнение сотрудника.docx");

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
