using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ConsoleСurrencyCalculator;
using System.Text.RegularExpressions;
using System.Windows.Threading;

namespace CurrencyCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        private int codeA;
        private int codeB;
        public int CodeA { get => codeA; set => codeA = value; }
        public int CodeB { get => codeB; set => codeB = value; }


        public MainWindow()
        {
            
            InitializeComponent();
            List<String> data = Program.ListCurrencies();
            data.Sort();
            ComboBox_First_Currency.ItemsSource = data;
            ComboBox_Second_Currency.ItemsSource = data;
            SetTime();
        }

        private void SetTime()
        {
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Label_Time.Content = DateTime.Now.ToLongTimeString();
        }

        private void Calculate()
        {
            string pattern = @"^\d+$";
            if (TextBox_I_Have.Text == "" || TextBox_I_Have.Text == null || ComboBox_First_Currency.SelectedItem == null || ComboBox_Second_Currency.SelectedItem == null)
            {
                return;
            }
            else
            {
                if (Regex.IsMatch(TextBox_I_Have.Text, pattern))
                {
                    float currency = Program.FindCurrency(codeA, codeB);
                    double I_Have = Convert.ToDouble(TextBox_I_Have.Text);
                    TextBox_I_Get.Text = (I_Have * currency).ToString();
                }
                else
                {
                    MessageBox.Show("Seems like input data are wrong.Try again");
                    return;
                }
            }
        }

        private void ComboBox_First_Currency_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            String selectedItem = ComboBox_First_Currency.SelectedItem as String;
            CodeA = Program.currencyName.FirstOrDefault(x => x.Value == selectedItem).Key;
            Calculate();
        }

        private void ComboBox_Second_Currency_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            String selectedItem = ComboBox_Second_Currency.SelectedItem as String;
            CodeB = Program.currencyName.FirstOrDefault(x => x.Value == selectedItem).Key;
            Calculate();
        }

        private void TextBox_I_Have_TextChanged(object sender, TextChangedEventArgs e)
        {
            Calculate();
        }

    }

}
