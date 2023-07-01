using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace GeradorDeSenhas
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        static readonly string SenhaLetras = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        static readonly string SenhaNumeros = "1234567890";
        static readonly string SenhaEspecial = "!@#$%&*()_-+=";

        private bool UsarNumeros = true;
        private bool UsarCaracteresEspeciais = true;
        public MainWindow()
        {
            InitializeComponent();
        }

        public string ObterSenha(int tamanho, TextBox box)
        {
            if (tamanho <= 0)
                tamanho = 10;

            string senha = string.Empty;
            Random random = new();

            string TempCaracteres;
            for (int i = 0; i < tamanho; i++){
                TempCaracteres = SenhaLetras;
                
                if(UsarNumeros)
                    TempCaracteres += SenhaNumeros;

                if(UsarCaracteresEspeciais)
                    TempCaracteres += SenhaEspecial;

                int letra = random.Next(0, TempCaracteres.Length);
                senha += TempCaracteres[letra];
                //if (box != null)
                //{
                //    box.Text = senha;
                //}
                //Thread.Sleep(1000);
            }
            return senha;
        }

        private void btnGerarSenha_Click(object sender, RoutedEventArgs e)
        {
            tbSenha.Text = "";
            tbSenha.Text = ObterSenha(20, tbSenha);
        }

        private void btnFecharApp_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void tbtnUsarNumeros_Click(object sender, RoutedEventArgs e)
        {
            UsarNumeros = !UsarNumeros;
        }

        private void tbtnUsarCharEspecial_Click(object sender, RoutedEventArgs e)
        {
            UsarCaracteresEspeciais = !UsarCaracteresEspeciais;
        }
    }
}
