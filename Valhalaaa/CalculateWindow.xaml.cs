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


namespace Valhalaaa
{
    /// <summary>
    /// Логика взаимодействия для CalculateWindow.xaml
    /// </summary>
    public partial class CalculateWindow : Window
    {


        private Dictionary<string, double> textBoxeValues = new Dictionary<string, double>();

        public CalculateWindow()
        {
            InitializeComponent();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            var mainForm = new MainWindow();
            this.Close();
            mainForm.Show();
        }

        private void Colculate_Click(object sender, RoutedEventArgs e)
        {
            var listTextBox = new List<TextBox>();
            listTextBox.Add(Htext);
            listTextBox.Add(Atext);
            listTextBox.Add(Dtext);
            listTextBox.Add(Tgtext);
            listTextBox.Add(Tvtext);
            listTextBox.Add(Z0text);
            listTextBox.Add(V1text);
            listTextBox.Add(Etext);
            listTextBox.Add(Utext);
            listTextBox.Add(ntext);

            foreach (var textBox in listTextBox)
            {
                if(textBox.Text == "," || textBox.Text == "")
                {
                    MessageBox.Show(" Нельзя вводить только запятую!  Введите число");
                    return;
                }
                double num = 0;
                double.TryParse(textBox.Text, out num);
                if (num == 0)
                {
                    MessageBox.Show("Введите число");
                    return;
                }
                textBoxeValues.Add(textBox.Name, num);
                
            }

            var resultForm = new ResultWindow(textBoxeValues);
            this.Close();
            resultForm.Show();

           
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
