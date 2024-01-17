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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Windows.Forms.DataVisualization;
using System.Windows.Forms.DataVisualization.Charting;
namespace AmountOfInformationApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        

        // Провека на то что введено не пустое значение, что введен текст, а не строка при потере фокуса
               private void OnVariantEdit(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(variantNumber.Text, out int _))
            {
                MessageBox.Show("Введено неккоректные данные, введите номер варианта", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);

                Rachet2.IsEnabled = false;
                Rachet3.IsEnabled = false;

                return;
            }

            Rachet2.IsEnabled = true;
            Rachet3.IsEnabled = true;
        }


        private void Rachet1(object sender, RoutedEventArgs e)
        {   //Провека на то что введено не пустое значение, что введен текст, а не строка
            if (!int.TryParse(variantNumber.Text, out int variant))
            {
                MessageBox.Show("Введите номер варианта", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            int h = variant + 2;
            int l = h % 2 == 0 ? 3 : 2;
            int alpha = 2;
            int beta = 2;
            int gamma = variant;

            //Проверка на то, что выброна хотя бы 1 радиокнопа
            if (SochitanieIzHElementov1.IsChecked == true)
            {   //сочетания из h элементов по l элементов
                double Q = (double)Factorial(h) / (double)(Factorial(l) * Factorial(h - l));
                output.Text = Q.ToString();
            }
            else if (SochetaniaSPovtoreniami.IsChecked == true)
            {
                //сочетания с повторениями
                double Q = (double)Factorial(h + l - 1) / (double)(Factorial(l) * Factorial(h - l));
                output.Text = Q.ToString();
            }
            else if (RazmechenieIzHElementovPo1.IsChecked == true)
            {
                //размещения из h элементов по l элементов 
                double Q = (double)Factorial(h) / (double)Factorial(h - l);
                output.Text = Q.ToString();
            }
            else if (RazmecheniaSPovtoreniem.IsChecked == true)
            {
                //размещения с повторениями по l элементов из h элементов 
                double Q = Math.Pow((double)h, l);
                output.Text = Q.ToString();
            }
            else if (PerestanovkiHElementiv.IsChecked == true)
            {
                //перестановки h элементов
                double Q = (double)Factorial(h);
                output.Text = Q.ToString();
            }
            else if (PerestanovkiSPovtoreniavi.IsChecked == true)
            {
                //перестановки с повторениями элементов
                alpha = 2;
                beta = 2;
                gamma = variant;
                double Q = (double)(alpha + beta + gamma) / (double)(Factorial(alpha) * Factorial(beta) * Factorial(gamma));
                output.Text = Q.ToString("N6");
            }
            else
            {
                MessageBox.Show("Выберите комбинаторный метод", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        //функция факториала
        private int Factorial(int number)
        {
            if (number == 0)
            {
                return 1;
            }

            return number * Factorial(number - 1);
        }


        private void Rachet2_Click(object sender, RoutedEventArgs e)
        {
            //Провека на то что введено не пустое значение, что введен текст, а не строка
            if (!int.TryParse(variantNumber.Text, out int variant))
            {
                MessageBox.Show("Введите номер варианта", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            //Очистка графика, задать зеленый цвет линии
            lineyniyGraphik.Series.Clear();
            series1.Color = System.Drawing.Color.Green;
            lineyniyGraphik.Series.Add(series1);

            double p1;
            double p2 = 0.0;
            double p3 = 1.0 / (1.0 + variant);
            double H;
            //Помещение элементов класса в лист
            List<TablitcsaRashetnieDannie> result = new List<TablitcsaRashetnieDannie>();

            //Цикл для расчета количества информации по формуле К. Э. Шеннона, прочертить линию на график, заполнить таблицу значениями
            for (int i = 0; p2 + p3 <= 1; i++)
            {
                p1 = 1.0 - p2 - p3;
                p2 += 0.05;
                H = -(p1 * Math.Log(p1, 2) + p2 * Math.Log(p2, 2) + p3 * Math.Log(p3, 2));
                series1.Points.AddXY(p2, H);
                result.Add(new TablitcsaRashetnieDannie
                {
                    Iteracia = i.ToString("N0"),
                    P1 = p1.ToString("N2"),
                    P2 = p2.ToString("N2"),
                    P3 = p3.ToString("N2"),
                    H = H.ToString("N2")
                });



            }
            //Добавление результатов в таблицу
            RashetnieDannie.ItemsSource = result;
        }

        private void Rachet3_Click(object sender, RoutedEventArgs e)
        {
            //Провека на то что введено не пустое значение, что введен текст, а не строка
            if (!int.TryParse(variantNumber.Text, out int variant))
            {
                MessageBox.Show("Введите номер варианта", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            double I1, I2;
            //Расчёт целесообразности информации по Харкевичу
            I1 = Math.Log(((3.0 / variant) * (2.0 / variant)), 2) - Math.Log((1.0 / 3.0), 2);
            I2 = Math.Log((2.0 / variant), 2) - Math.Log((1.0 / 3.0), 2);
            TextCeles1.Text = I1.ToString("r");
            TextCeles2.Text = I2.ToString("r");
        }

        //Выход из программы
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
        //Очистка всех элементов формы от данных
        private void Ochistka_Click(object sender, RoutedEventArgs e)
        {
            TextCeles1.Clear();
            TextCeles2.Clear();
            variantNumber.Clear();
            output.Clear();
            RashetnieDannie.ItemsSource = new List<TablitcsaRashetnieDannie>();
            lineyniyGraphik.Series.Clear();
        }
    }
}
