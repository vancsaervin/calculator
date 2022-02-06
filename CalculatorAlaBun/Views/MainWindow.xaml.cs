using System;
using System.Linq;
using System.Windows;
using CalculatorAlaBun.Classes;

namespace CalculatorAlaBun.Views
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddNumberToInputBox(object sender, RoutedEventArgs e)
        {
            String buttonContent = (e.Source as System.Windows.Controls.Button).Content.ToString();
            String inputText = inputBox.Text;
            String historyText = historyBox.Text;

            if (historyText.Contains("="))
            {
                historyText = String.Empty;
                inputText = String.Empty;
            }

            inputText = Utils.AddNumber(inputText, buttonContent);
            inputBox.Text = inputText;
            historyBox.Text = historyText;
        }

        private void AddOperationToInputBox(object sender, RoutedEventArgs e)
        {
            String buttonContent = (e.Source as System.Windows.Controls.Button).Content.ToString();
            String inputText = inputBox.Text;
            String historyText = historyBox.Text;

            if (inputText.Equals("x / 0 = !Exist"))
            {
                historyText = String.Empty;
                inputText = "0";
                inputBox.Text = inputText;
                historyBox.Text = historyText;
                return;
            }

            inputText = Utils.AddOperationToInputBox(inputText, buttonContent);
            inputBox.Text = inputText;
            historyBox.Text = historyText;
        }

        private void AddOperationToHistoryBox(object sender, RoutedEventArgs e)
        {
            String buttonContent = (e.Source as System.Windows.Controls.Button).Content.ToString();
            String inputText = inputBox.Text;
            String historyText = historyBox.Text;

            if (inputText.Equals("x / 0 = !Exist"))
            {
                historyText = String.Empty;
                inputText = "0";
                inputBox.Text = inputText;
                historyBox.Text = historyText;
                return;
            }

            if (inputText.Equals("0") && !buttonContent.Equals("C"))
            {
                return;
            }

            historyText = Utils.ConcatenateStrings(historyText, inputText);
            historyText = Utils.AddOperationToHistoryBox(historyText, buttonContent);
            inputText = "0";

            inputBox.Text = inputText;
            historyBox.Text = historyText;
        }

        private void Equals(object sender, RoutedEventArgs e)
        {
            String inputText = inputBox.Text;
            String historyText = historyBox.Text;

            if (String.IsNullOrEmpty(historyText))
                return;

            String memory = inputText;
            inputText = Utils.Calculate(inputText, historyText);
            historyText = String.Concat(historyText, " ", memory, " =");

            if (historyText.Contains("/ 0"))
                inputText = "x / 0 = !Exist";
            inputBox.Text = inputText;
            historyBox.Text = historyText;
        }

        private void Negative(object sender, RoutedEventArgs e)
        {
            String inputText = inputBox.Text;
            String historyText = historyBox.Text;

            if (inputText.Equals("x / 0 = !Exist"))
            {
                inputText = "0";
                historyText = String.Empty;

                inputBox.Text = inputText;
                historyBox.Text = historyText;
                return;
            }

            String operation = String.Empty;
            if (!String.IsNullOrEmpty(historyText) && (historyText.Last().ToString().Equals("+") || historyText.Last().ToString().Equals("-")))
            {
                historyText = Utils.ChangeHistoryBoxSign(historyText);
                historyBox.Text = historyText;

                return;
            }

            inputText = Utils.ChangeInputboxSign(inputText);
            inputBox.Text = inputText;
        }
    }
}
