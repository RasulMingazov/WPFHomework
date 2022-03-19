using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Calculator
{
    public partial class MainWindow : Window
    {

        private Stack<double> elements = new Stack<double>();
        private Stack<char> operators = new Stack<char>();
        public MainWindow()
        {
            InitializeComponent();
        }
        private void AddDigitToValueClick(object sender, RoutedEventArgs e)
        {
            lblDisplay.Rules().CheckDigitAdding().ValidateSpecial((string) ((Button)e.OriginalSource).Content);
        }

        private void AddCommaToValueClick(object sender, RoutedEventArgs e)
        {
            lblDisplay.Rules().CheckCommaAdding().ValidateSpecial((string) ((Button)e.OriginalSource).Content);
        }
        private void CalculateClick(object sender, RoutedEventArgs e)
        {
            lblDisplay.Rules().CheckValue();
            elements.Push(Convert.ToDouble((string) lblDisplay.Content));
            operators.Push(((string) ((Button)e.OriginalSource).Content).ToCharArray()[0]);
            lblDisplay.Content = "0";
        }
        private void ClearClick(object sender, RoutedEventArgs e)
        {
            lblDisplay.Content = "0";
            elements.Clear();
            operators.Clear();
        }
        private void EqualsClick(object sender, RoutedEventArgs e)
        {
            if (elements.Count > 0)
            {
                lblDisplay.Rules().CheckValue();
                double FirstNumber = elements.Peek();
                double SecondNumber = Convert.ToDouble((string)lblDisplay.Content);

                string result = calculate(operators.Peek(), FirstNumber, SecondNumber).ToString();

                lblDisplay.Rules(result).CheckResultValue().Validate();


                lblDisplay.Content = calculate(operators.Peek(), FirstNumber, SecondNumber).ToString();

                elements.Push(SecondNumber);
            }

        }
        private void ChangeClick(object sender, RoutedEventArgs e)
        {
            if (lblDisplay.Content.ToString()!.StartsWith("-"))
            {
                lblDisplay.Content = lblDisplay.Content.ToString()!.Substring(1);
            }
            else
            {
                lblDisplay.Content = "-" + lblDisplay.Content.ToString();
            }

        }
        private double calculate(char o, double a, double b)
        {
            switch (o)
            {
                case '+': 
                    return a + b;
                case '-':
                    return a - b;
                case '*':   
                    return a * b;
                case '/':   
                    return a / b;
            }
            return 0;
        }
    }
    static class ControlValidationExtension
    {
        public static Validator Rules(this Label control) => new Validator(control, (string)control.Content);
        public static Validator Rules(this Label control, string value) => new Validator(control, value);
    }
}
