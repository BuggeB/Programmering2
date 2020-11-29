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

namespace DemoWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void OkButton_Klick(object sender, RoutedEventArgs e)
        {
            if (e.Source is Button button)
            {
                TextOne.Text += button.Content;
            }
        }
        private void Equals(Object sender, RoutedEventArgs e)
        {
            if (TextOne.Text.Contains("+"))
            {
                TextOne.Text = Addition();
            }
            else if (TextOne.Text.Contains("-"))
            {
                TextOne.Text = Subtraction();
            }
            else if (TextOne.Text.Contains("x"))
            {
                TextOne.Text = Multiplication();
            }
            else if (TextOne.Text.Contains("/"))
            {
                TextOne.Text = Division();
            }
            else if (TextOne.Text.Contains("²"))
            {
                TextOne.Text = Squared();
            }
        }
        private string Addition()
        {
            var numbers = TextOne.Text.Split("+");
            var number1 = Convert.ToDouble(numbers[0]);
            var number2 = Convert.ToDouble(numbers[1]);
            var sum = number1 + number2;
            return sum + "";
        }
        private string Subtraction()
        {
            var numbers = TextOne.Text.Split("-");
            var number1 = Convert.ToDouble(numbers[0]);
            var number2 = Convert.ToDouble(numbers[1]);
            var sum = number1 - number2;
            return sum + "";
        }
        private string Multiplication()
        {
            var numbers = TextOne.Text.Split("x");
            var number1 = Convert.ToDouble(numbers[0]);
            var number2 = Convert.ToDouble(numbers[1]);
            var sum = number1 * number2;
            return sum + "";
        }
        private string Division()
        {
            var numbers = TextOne.Text.Split("/");
            var number1 = Convert.ToDouble(numbers[0]);
            var number2 = Convert.ToDouble(numbers[1]);
            var sum = number1 / number2;
            return sum + "";
        }
        private void Clear(Object sender, RoutedEventArgs e)
        {
            TextOne.Text = "";
        }
        private void Regret(object sender, RoutedEventArgs e)
        {
            TextOne.Text = TextOne.Text.Remove(TextOne.Text.Length - 1);
        }

        private string Squared()
        {
            var numbers = TextOne.Text.Split("²");
            var number1 = Convert.ToDouble(numbers[0]);
            var sum = Math.Pow(number1, 2);
            return sum + "";
        }
    }
}
