using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Linq;
using CaclulateLib;
using CaclulateLib.ReportsResources;

namespace Valhalaaa
{
    /// <summary>
    /// Логика взаимодействия для ResultWindow.xaml
    /// </summary>
    public partial class ResultWindow : Window
    {
        private MaincalculateClass maincalculateClass;
        private Dictionary<string, double> textBoxeValues;

        public ResultWindow(Dictionary<string, double> _textBoxeValuesArg)
        {
            InitializeComponent();
            textBoxeValues = _textBoxeValuesArg;
            maincalculateClass = new MaincalculateClass();
            SendResultToView();
        }


        private void SendResultToView()
        {
            maincalculateClass.VelValue = textBoxeValues.First(x => x.Key == "Utext").Value;
            int counter1 = 0;
            int counter2 = 0;

            

            foreach (var textGrid in ResultMainGrid.Children.OfType<TextBox>())
            {


                if (counter2 < 5)
                {

                    WriteGridData(textGrid , counter1 , counter2);
                    WriteTextBoxes();

                    if (counter1 < 4)
                    {
                        counter1++;
                    }
                    else
                    {
                        counter2++;
                        counter1= 0;
                    }
                }

            }


            int counter3 = 0;

            foreach (TextBox textBox in InfoBoxTwo.Children.OfType<TextBox>())
            {
               
                if (counter3 < 5)
                {
                    textBox.Text = (Math.Round(maincalculateClass.Cx_ConcentCountRangeSolidCount(textBoxeValues["Etext"], textBoxeValues["ntext"], textBoxeValues["V1text"], textBoxeValues["Dtext"], textBoxeValues["Htext"], textBoxeValues["Tgtext"], textBoxeValues["Tvtext"], textBoxeValues["Z0text"], textBoxeValues["Atext"])[counter3], 4).ToString());
                }
                if (counter3 < 4)
                {
                    counter3++;
                }
                else
                {
                    counter3 = 0;
                }
            }

        }


        public void WriteTextBoxes()
        {

            DustSolid.Text = maincalculateClass.DustCalc(textBoxeValues["V1text"], textBoxeValues["Dtext"], textBoxeValues["Z0text"]).ToString();
            DangerBreezeSpeed.Text = maincalculateClass.um_DangerousBreezeSpeed(textBoxeValues["V1text"], textBoxeValues["Dtext"], textBoxeValues["Htext"], textBoxeValues["Tgtext"], textBoxeValues["Tvtext"]).ToString();
            Xmfak.Text = maincalculateClass.Xm_TorchRange(textBoxeValues["Etext"], textBoxeValues["ntext"], textBoxeValues["V1text"], textBoxeValues["Dtext"], textBoxeValues["Htext"], textBoxeValues["Tgtext"], textBoxeValues["Tvtext"], textBoxeValues["Z0text"]).ToString();

        }

        public void WriteGridData(TextBox textBox, int counter1 , int counter2)
        {
            textBox.Text = Math.Round(maincalculateClass.Cy_ConcentCountRangeCount(textBoxeValues["Etext"], textBoxeValues["ntext"], textBoxeValues["V1text"], textBoxeValues["Dtext"], textBoxeValues["Htext"], textBoxeValues["Tgtext"], textBoxeValues["Tvtext"], textBoxeValues["Z0text"], textBoxeValues["Atext"])[counter1, counter2], 4).ToString();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            var listRows = new List<RowReportModel>();
            listRows.Add(new RowReportModel()
            {
                r1= DataBlock4.Text,
                r2= DataBlock10.Text,
                r3 = DataBlock11.Text,
                r4 = DataBlock2.Text,
                r5 = DataBlock3.Text,
                r6 = Datablock1.Text,
            });

            listRows.Add(new RowReportModel()
            {
                r1 = DataBlock5.Text,
                r2 = Data9.Text,
                r3 = Data13.Text,
                r4 = Data18.Text,
                r5 = Data19.Text,
                r6 = Data20.Text,
            });

            listRows.Add(new RowReportModel()
            {
                r1 = DataBlock6.Text,
                r2 = Data14.Text,
                r3 = Data13.Text,
                r4 = Data21.Text,
                r5 = Data22.Text,
                r6 = Data23.Text,
            });

            listRows.Add(new RowReportModel()
            {
                r1 = DataBlock7.Text,
                r2 = Data11.Text,
                r3 = Data15.Text,
                r4 = Data24.Text,
                r5 = Data3.Text,
                r6 = Data4.Text,
            });

            listRows.Add(new RowReportModel()
            {
                r1 = DataBlock8.Text,
                r2 = Data16.Text,
                r3 = Data25.Text,
                r4 = Data7.Text,
                r5 = Data5.Text,
                r6 = Data2.Text,
            });

            listRows.Add(new RowReportModel()
            {
                r1 = DataBlock9.Text,
                r2 = Data12.Text,
                r3 = Data17.Text,
                r4 = Data8.Text,
                r5 = Data6.Text,
                r6 = Data1.Text,
            });

            var reportyModel = new ReportModel()
            {
                Xmfak = Xmfak.Text,
                Dust = DustSolid.Text,
                Range = DangerBreezeSpeed.Text,
                Title1 = M1Data1.Text,
                Title2 = M2Data2.Text,
                Title3 = M3Data3.Text,
                Title4 = M4Data4.Text,
                Title5 = M5Data5.Text,
                RowReport = listRows
            };

            var reportService = new ReportService();

            var fileArray = reportService.CreateReport(reportyModel);
            var result = reportService.CreateFile(fileArray);
            MessageBox.Show("Ваш отчет доступен по пути: "+result);

        }
    }
}
