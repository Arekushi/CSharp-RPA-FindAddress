using BuscaCEP.Model;
using BuscaCEP.Selenium;
using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace BuscaCEP
{
    public partial class MainWindow : Window
    {
        private Finder finder;

        #region [Public Methods]

        public MainWindow()
        {
            InitializeComponent();
        }

        #endregion

        #region [Private Methods]

        private void Init(object sender, RoutedEventArgs e)
        {
            finder = new Finder();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void TryFindAddress(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(GetOnlyCEP()) && GetOnlyCEP().Length == 8)
            {
                Address address = finder.FindAddressByCEP(BoxCEP.Text);
                finder.Reset();

                if(address.IsValid)
                {
                    Hide();
                    new Modal.Modal(address).ShowDialog();

                    Close();
                } else
                {
                    MessageBox.Show("O CEP Digitado não é válido!");
                    BoxCEP.Clear();
                }
            }
            else
            {
                MessageBox.Show("É necessário preencher o campo de CEP corretamente!");
            }

        }

        private String GetOnlyCEP()
        {
            return BoxCEP.Text
                .Replace('_'.ToString(), "")
                .Replace('-'.ToString(), "");
        }

        #endregion
    }
}
