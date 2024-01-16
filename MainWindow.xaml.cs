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

        private void OnVariantEdit(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(variantNumber.Text, out int _))
            {
                MessageBox.Show("Ошибка!");

                Calculate2.IsEnabled = false;
                Calculate3.IsEnabled = false;

                return;
            }

            Calculate2.IsEnabled = true;
            Calculate3.IsEnabled = true;
        }
    }
}
