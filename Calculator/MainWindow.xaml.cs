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

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double lastNumber, result;
        SelectedOperator selectedOperator;

        public MainWindow()
        {
            InitializeComponent();
            btnAC.Click += BtnAC_Click;
            btnNegative.Click += BtnNegative_Click;
            btnPercent.Click += BtnPercent_Click;
            btnEquals.Click += BtnEquals_Click;
                    
        }

        private void BtnEquals_Click(object sender, RoutedEventArgs e)
        {
            double newNumber;
            if (double.TryParse(lblResult.Content.ToString(), out newNumber))
            {
                switch(selectedOperator)
                {
                    case SelectedOperator.Addition:
                        result = SimpleMath.Add(lastNumber, newNumber);
                    break;
                    case SelectedOperator.Subtraction:
                        result = SimpleMath.Subtract(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Multiplication:
                        result = SimpleMath.Multiply(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Division:
                        result = SimpleMath.Divide(lastNumber, newNumber);
                        break;
                }

                lblResult.Content = result.ToString();


            }
        }

        private void BtnPercent_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(lblResult.Content.ToString(), out lastNumber))
            {
                lastNumber = lastNumber / 100;
                lblResult.Content = lastNumber.ToString();
            }
        }

        private void BtnNegative_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(lblResult.Content.ToString(), out lastNumber))
            {
                lastNumber = lastNumber * -1;
                lblResult.Content = lastNumber.ToString();
            }
        }

        private void BtnAC_Click(object sender, RoutedEventArgs e)
        {
            lblResult.Content = "0";
        }

        private void btnOperation_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(lblResult.Content.ToString(), out lastNumber))
            {

                lblResult.Content = "0";
            }

            if (sender == btnAdd) selectedOperator = SelectedOperator.Addition;
            if (sender == btnSubtract) selectedOperator = SelectedOperator.Subtraction;
            if (sender == btnMultiply) selectedOperator = SelectedOperator.Multiplication;
            if (sender == btnDivide) selectedOperator = SelectedOperator.Division;
        }

        private void btnDecimalPoint_Click(object sender, RoutedEventArgs e)
        {
            if (lblResult.Content.ToString().Contains("."))
            {
                //do nothing
            }
            else
            lblResult.Content = $"{lblResult.Content}.";
        }

        private void btnNumber_Click(object sender, RoutedEventArgs e)
        {
            int selectedValue = 0;

            if (sender == btnZero) selectedValue = 0;
            if (sender == btnOne) selectedValue = 1;
            if (sender == btnTwo) selectedValue = 2;
            if (sender == btnThree) selectedValue = 3;
            if (sender == btnFour) selectedValue = 4;
            if (sender == btnFive) selectedValue = 5;
            if (sender == btnSix) selectedValue = 6;
            if (sender == btnSeven) selectedValue = 7;
            if (sender == btnEight) selectedValue = 8;
            if (sender == btnNine) selectedValue = 9;
            

            if (lblResult.Content.ToString() == "0")
            {
                lblResult.Content = $"{selectedValue}";
            }
            else
            {
                lblResult.Content = $"{lblResult.Content}{selectedValue}";
            }
        }
    }
    public enum SelectedOperator
    {
        Addition,
        Subtraction,
        Multiplication,
        Division
    }
}
