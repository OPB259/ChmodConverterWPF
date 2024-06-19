using System;
using System.Windows;
using ChmodConverterLib;  

namespace ChmodConverterWPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Convert_Click(object sender, RoutedEventArgs e)
        {
            string input = PermissionsInput.Text.Trim();

            if (int.TryParse(input, out int numericMode))
            {
                // Tryb numeryczny na symboliczny
                try
                {
                    string symbolic = ChmodConverter.NumericToSymbolic(numericMode);
                    ResultText.Text = symbolic;
                }
                catch (ArgumentException ex)
                {
                    ResultText.Text = "Invalid numeric mode.";
                }
            }
            else
            {
                // Tryb symboliczny na numeryczny
                try
                {
                    int numericResult = ChmodConverter.SymbolicToNumeric(input);
                    ResultText.Text = numericResult.ToString();
                }
                catch (ArgumentException ex)
                {
                    ResultText.Text = "Invalid symbolic mode.";
                }
            }
        }
    }
}