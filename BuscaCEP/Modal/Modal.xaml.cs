using BuscaCEP.Model;
using System;
using System.Windows;

namespace BuscaCEP.Modal
{
    public partial class Modal : Window
    {
        private readonly Address address;

        public Modal(Address address)
        {
            InitializeComponent();

            this.address = address;
        }

        private void Init(object sender, RoutedEventArgs e)
        {
            Street.Text = $"Logradouro: {address.Street}";
            District.Text = $"Bairro: {address.District}";
            Locality.Text = $"Localidade/UF: {address.Locality}/{address.UF}";
        }

        private void ClosedWindow(object sender, EventArgs e)
        {
            new MainWindow().Show();
        }
    }
}
