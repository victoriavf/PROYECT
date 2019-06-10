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

namespace FarmaVitality
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
           
            ButtonCloseMenu.Visibility = Visibility.Hidden;
            ButtonOpenMenu.Visibility = Visibility.Visible;


        }

        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {

            ButtonCloseMenu.Visibility = Visibility.Visible;
            ButtonOpenMenu.Visibility = Visibility.Hidden;
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void lvwMenuBar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BtnCollapseMenu_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnOpenMenu_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnUsuario_Click(object sender, RoutedEventArgs e)
        {
            Usuario.vwUsuario vw = new Usuario.vwUsuario();
            vw.ShowDialog();
        }

        private void BtnMedicamento_Click(object sender, RoutedEventArgs e)
        {
            Medicamento.vwMedicamento vw = new Medicamento.vwMedicamento();
            vw.ShowDialog();
        }

        private void BtnOcultar_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }     

        private void BtnMaximizar_Click_1(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Maximized;
        }

        private void BtnMenimizar_Click_1(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Normal;
        }
    }
    }

