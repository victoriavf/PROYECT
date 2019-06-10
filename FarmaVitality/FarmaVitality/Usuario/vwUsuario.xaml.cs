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
using System.Windows.Shapes;
using Common;
using BRL;
using System.Data;

namespace FarmaVitality.Usuario
{
    /// <summary>
    /// Lógica de interacción para vwUsuario.xaml
    /// </summary>
    public partial class vwUsuario : Window
    {

        byte opcion = 0;

        Common.Usuario user;
        UsuarioBRL brl;
        public vwUsuario()
        {
            InitializeComponent();
        }

        void Habilitar(byte opcion)
        {
            this.opcion = opcion;
            btnInsertar.IsEnabled = false;
            btnModificar.IsEnabled = false;
            btnElimiar.IsEnabled = false;

            btnGuardar.IsEnabled = true;
            btnCancelar.IsEnabled = true;
            dgvDatos.IsEnabled = true;
            txtNombreUsuario.Focus();



        }
        void DesHabilitar()
        {

            btnInsertar.IsEnabled = true;
            btnModificar.IsEnabled = true;
            btnElimiar.IsEnabled = true;

            btnGuardar.IsEnabled = false;
            btnCancelar.IsEnabled = false;
            dgvDatos.IsEnabled = false;



        }


        void FillDataGrid()
        {
            try
            {
                brl = new UsuarioBRL();
                dgvDatos.ItemsSource = null;
                dgvDatos.ItemsSource = brl.Select().DefaultView;
                dgvDatos.Columns[0].Visibility = Visibility.Hidden;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + " error al filtrar");
            }
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnInsertar_Click(object sender, RoutedEventArgs e)
        {
            Habilitar(1);
        }

        private void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {

            switch (opcion)
            {
                case 1:

                    try
                    {
                        
                        user = new Common.Usuario(txtNombre.Text, txtprimerAp.Text, txtSegundoApellido.Text, txtCi.Text, int.Parse(txtTelefono.Text), txtDireccion.Text, txtEmail.Text,DateTime.Parse(dtfecha.ToString()), txtRol.Text, txtNombreUsuario.Text, txtPassword.Password );
                        brl = new UsuarioBRL(user);
                        brl.Insert();

                        MessageBox.Show("Proveedor insertado con exito...");
                        FillDataGrid();
                        DesHabilitar();

                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show("error al insert  " + ex.Message);
                    }
                    break;

                case 2:
                    try
                    {
                        user.Nombre = txtNombre.Text;
                        user.NombreUsuario = txtNombreUsuario.Text;
                        user.PrimerApellido = txtprimerAp.Text;
                        user.SegundoApellido = txtSegundoApellido.Text;
                        user.Ci = txtCi.Text;
                        user.Telefono = int.Parse(txtTelefono.Text);
                        user.Direccion = txtDireccion.Text;
                        user.Rol = txtRol.Text;
                        user.Password = txtPassword.Password;
                        user.FechaRegistro = DateTime.Parse(dtfecha.ToString());
                        user.Email = txtEmail.Text;
                        brl = new UsuarioBRL(user);
                        brl.Update();



                        MessageBox.Show(" Proveedor Modificado con exito...");
                        FillDataGrid();

                        DesHabilitar();
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show("Error al modificar " + ex.Message);
                    }
                    break;
            }
        }

        private void BtnModificar_Click(object sender, RoutedEventArgs e)
        {
            Habilitar(2);
        }

        private void BtnElimiar_Click(object sender, RoutedEventArgs e)
        {

            if (dgvDatos.SelectedItem != null && user != null)
            {
                if (MessageBox.Show("esta realmente segur@ de eleminar el registro??", "Eleminar", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    try
                    {
                        brl = new UsuarioBRL(user);
                        brl.Delete();
                        FillDataGrid();
                        MessageBox.Show("Registro Eleminado con exito");
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            DesHabilitar();

        }

 

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            user = null;
            if (dgvDatos.SelectedItems != null && dgvDatos.Items.Count > 0)
            {
                try
                {
                    DataRowView dataRow = (DataRowView)dgvDatos.SelectedItem;
                    int id = int.Parse(dataRow.Row.ItemArray[0].ToString());
                    brl = new UsuarioBRL();

                    //user = brl.Get(id);
                    if (user != null)
                    {
                        txtNombreUsuario.Text = user.Nombre;
                        txtprimerAp.Text = user.PrimerApellido;
                        txtSegundoApellido.Text = user.SegundoApellido;
                        txtCi.Text = user.Ci;
                        txtTelefono.Text = user.Telefono.ToString();
                        txtDireccion.Text = user.Direccion;
                        txtRol.Text = user.Rol;
                        txtPassword.Password = user.Password;
                        dtfecha.Text = user.FechaRegistro.ToLongDateString();
                        txtEmail.Text = user.Email;
                        txtprimerAp.Text = user.PrimerApellido;

                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Error en el get " + ex.Message);
                }

            }
        }
    }
}




