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

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        /// <summary>
        /// Вычисляет
        /// </summary>
      
        private void Button_Click(object sender, RoutedEventArgs e)
        {   
            if (!int.TryParse(variantNumber.Text, out int _))
            {
                MessageBox.Show("Ошибка!");
            }
        }
        /// <summary>
        /// Провека на то что введено не пустое значение, что введен текст, а не строка при потере фокуса
        /// </summary>

        private void OnVariantEdit(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(variantNumber.Text, out int _))
            {
                MessageBox.Show("Введено неккоректные данные, введите номер варианта", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);

                Calculate2.IsEnabled = false;
                Calculate3.IsEnabled = false;

                return;
            }

            Calculate2.IsEnabled = true;
            Calculate3.IsEnabled = true;
        }


        private void Rachet1(object sender, RoutedEventArgs e)
        {   //Провека на то что введено не пустое значение, что введен текст, а не строка
            if (!int.TryParse(variantNumber.Text, out int _))
            {
                MessageBox.Show("Введите номер варианта", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            //Проверка на то, что выброна хотя бы 1 радиокнопа
            if(SochitanieIzHElementov1.IsChecked == true)
            {

            } else if (SochetaniaSPovtoreniami.IsChecked == true) {

            }else if (RazmechenieIzHElementovPo1.IsChecked == true)
            {

            } else if (RazmecheniaSPovtoreniem.IsChecked == true)
            {

            } else if (PerestanovkiHElementiv.IsChecked == true)
            {

            } else if (PerestanovkiSPovtoreniavi.IsChecked == true)
            {

            }
            else
            {
                MessageBox.Show("Выберите комбинаторный метод", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
