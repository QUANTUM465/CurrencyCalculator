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
using PostDataResponce;
using ConsoleСurrencyCalculator;

namespace CurrencyCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int codeA;
        private int codeB;
        public int CodeA { get => codeA; set => codeA = value; }
        public int CodeB { get => codeB; set => codeB = value; }

        public MainWindow()
        {
            InitializeComponent();
            List<String> data = Program.ListCurrencies();
            data.Sort();
            List_Box1.ItemsSource = data;
            List_Box2.ItemsSource = data;
        }

        //TODO:: Треба витягнути значення курсу для вибраних валют
        
        private void List_Box2_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            String stringList = List_Box2.SelectedItem as String;
            CurrencyLabel_SecondCurrency.Content = stringList.ToString();
            CodeB = Program.currencyName.FirstOrDefault(x => x.Value == stringList).Key;
        }

        private void List_Box1_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            String stringList = List_Box1.SelectedItem as String;
            CurrencyLabel_FirstCurrency.Content = stringList.ToString();
            CodeA = Program.currencyName.FirstOrDefault(x => x.Value == stringList).Key;
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            Currency currency = Program.FindCurrency(codeA, codeB);
            var data = currency.RateCross.ToString();
            CurrencyLabel_Result.Content =  data; //TODO:: Криво виводить данні
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CurrencyLabel_Result.Content = null;
        }

    }

}
