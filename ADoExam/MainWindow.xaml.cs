using ADoExam.Model;
using OfficeOpenXml;
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

namespace ADoExam
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static MCSSSS db = new MCSSSS();

      

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnGener_Click(object sender, RoutedEventArgs e)
        {
            string path = txtName2.Text;
            FileInfo template = new System.IO.FileInfo(@"C:\Users\ОстроуховМ\Documents\Visual Studio 2015\Projects\ADoExam\ADoExam\bin\Debug\OverallRepairList.xlsx");

            using (ExcelPackage package = new ExcelPackage(template, true))
            {
                int k = 2;
                ExcelWorksheet workshet = package.Workbook.Worksheets.Add("Sheet2");

             

                var t = db.TrackEvaluation.Where(w => w.dCreateDate >= datePicker1.SelectedDate && w.dCreateDate <= datePicker2.SelectedDate);

            
                foreach (var item in t)
                {

                    workshet.Cells[k++, 9].Value = item.newEquipment.TablesModel.strName;
                    workshet.Cells[k++, 10].Value = item.intEvalutionNumber;
                    workshet.Cells[k++, 11].Value = item.dCreateDate;
                    workshet.Cells[k++, 12].Value = item.strSalesOrderNumber;
                    workshet.Cells[k++, 13].Value = item.dConfirmDate;
                    workshet.Cells[k++, 14].Value = item.dDateOfSale;
                    workshet.Cells[k++, 15].Value = item.dEstimatedDateArrival;
                    workshet.Cells[k++, 16].Value = item.dArrivalDate;
                    workshet.Cells[k++, 17].Value = item.floatETTR;
                    workshet.Cells[k++, 18].Value = item.floatELTR;
                    workshet.Cells[k++, 19].Value = item.TableEvaluationSysStatus.strStatysName;
                    workshet.Cells[k++, 20].Value = db.TrackEvaluationPart.Where(w => w.intEvaluationPartId == item.intEvalutionId).Sum(s=>s.floatUnitCostAvia);


                }    
                
                try
                {
                    FileStream fs = File.Create(path);
                    fs.Close();
                    package.SaveAs(fs);

                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
                
                
           
           

            }



        }
    }
}
