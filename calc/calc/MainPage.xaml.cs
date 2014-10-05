using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace calc
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
 
        }

        float result = 0, digitMul = 1;
        float lastNumber = 0, currentNumber = 0;
        char  currentOperand = '#';
        bool  dot = false, wasResult = false;
        

        private void PrintResult()
        {
            Result.Text = result.ToString();
        }

        private void PrintCurrent()
        {
            Result.Text = currentNumber.ToString();
        }

        private void Process()
        {
            float x = currentNumber > 0 ? currentNumber : lastNumber;

            switch (currentOperand)
            {
                case '+': result += x; break;
                case '-': result -= x; break;
                case '×': result *= x; break;
                case '÷': result /= x; break;
                default: result = currentNumber; break;
            }
            
            if (currentNumber > 0)
            {
                lastNumber = currentNumber;
                ClearCurrent();
            }
            

            PrintResult();
        }

        private void Operand(char op)
        {
            if (currentNumber > 0)
            {
                if (currentOperand != '#')
                    Process();
                else
                    result = currentNumber;
            }

            ClearCurrent();
            currentOperand = op;
        }

        private void ClearCurrent()
        {
            currentNumber = 0;
            digitMul = 1;
            dot = false;
            wasResult = false;
        }

        private void Clear()
        {
            result = 0;
            lastNumber = 0;
            ClearCurrent();
            currentOperand = '#';
            dot = false;
            wasResult = false;
            PrintResult();
        }

        private void Button_Click_Digit(object sender, RoutedEventArgs e)
        {
            if (wasResult)
            {
                currentOperand = '#';
                wasResult = false;
            }
            int digit = (((Button)sender).Content.ToString()[0] - '0');
            digitMul = (dot ? digitMul / 10 : 1);
            currentNumber = (dot ? 1 : 10) * currentNumber + digit * digitMul;
            PrintCurrent();
        }

        private void Dot()
        {
            if (wasResult)
            {
                Clear();
                currentOperand = '#';
                wasResult = false;
            }

            dot = true;
        }

        private void Button_Click_Op(object sender, RoutedEventArgs e)
        {
            char op = (((Button)sender).Content.ToString()[0]);
            dot = false;
            switch (op)
            {
                case '+': Operand(op); break;
                case '-': Operand(op); break;
                case '×': Operand(op); break;
                case '÷': Operand(op); break;
                case '=': Process(); break;
                case 'A': Clear(); break;
                case ',': Dot(); break;
            }

            wasResult = op == '=';
        }

        SolidColorBrush[] brushes = {
            new SolidColorBrush(Windows.UI.Color.FromArgb(255, 255, 255, 255)),
            new SolidColorBrush(Windows.UI.Color.FromArgb(255, 250, 50, 50)),
            new SolidColorBrush(Windows.UI.Color.FromArgb(255, 50, 250, 50)),
            new SolidColorBrush(Windows.UI.Color.FromArgb(255, 50, 50, 250)),
            new SolidColorBrush(Windows.UI.Color.FromArgb(255, 250, 50, 250)),
            new SolidColorBrush(Windows.UI.Color.FromArgb(255, 250, 250, 50)),
            new SolidColorBrush(Windows.UI.Color.FromArgb(255, 50, 250, 250))
        };
        int currentBrush = 0;

        private void Button_Click_CC(object sender, RoutedEventArgs e)
        {
            if(++currentBrush > brushes.Length - 1)
                currentBrush = 0;
            Result.Foreground = brushes[currentBrush];
        }

        private void Button_Click_UP(object sender, RoutedEventArgs e)
        {
            Result.FontSize += 2;
        }

        private void Button_Click_DOWN(object sender, RoutedEventArgs e)
        {
            Result.FontSize -= 2;
        }

    }
}
