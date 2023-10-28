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

namespace PR_21._102_Glazirin_3option
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


        private void btnGeneration_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Переменные N - размер массива, minValue and maxValue - границы значений
                int N = Convert.ToInt32(tbArraySize.Text);
                int minValue = Convert.ToInt32(tbArrayMin.Text);
                int maxValue = Convert.ToInt32(tbArrayMax.Text);

                Random random = new Random();
                //Генерация массива
                int[] array = new int[N];
                for (int i = 0; i < N; i++)
                {
                    array[i] = random.Next(minValue, maxValue + 1);
                }

                //Вывыод 
                lbNewArray.ItemsSource = array;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при генерации массива: " + ex.Message);
            }

        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int[] array = (int[])lbNewArray.ItemsSource;
                if (array == null)
                {
                    throw new ArgumentException("Массив не был сгенерирован");
                }

                //Два указателя, один начинает с 0 элемента, другой с конца.
                int evenIndex = 0;
                int oddIndex = array.Length - 1;

                while (evenIndex < oddIndex)
                {
                    //Если условия выполняются, то индексы сдвигаются.
                    if (array[evenIndex] % 2 == 0)
                    {
                        evenIndex++;
                    }
                    else if (array[oddIndex] % 2 != 0)
                    {
                        oddIndex--;
                    }
                    //если нет, то элементы меняются местами
                    else
                    {
                        //temp - Доп. переменная для сохранения значения evenIndex. (буфер)
                        int temp = array[evenIndex];
                        array[evenIndex] = array[oddIndex];
                        array[oddIndex] = temp;
                        evenIndex++;
                        oddIndex--;
                    }
                }
                //Вывыод 
                lbResultaterray.ItemsSource = array;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при выполнении операции: " + ex.Message);
            }
        }

        //Очистка элементов под массивы
        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            lbResultaterray.ItemsSource = null;
            lbNewArray.ItemsSource = null;
        }
    }
}
