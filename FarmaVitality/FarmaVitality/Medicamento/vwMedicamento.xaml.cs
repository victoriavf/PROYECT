using System;
using System.Collections.Generic;
using System.Data;
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
using BRL;


namespace FarmaVitality.Medicamento
{
    /// <summary>
    /// Lógica de interacción para vwMedicamento.xaml
    /// </summary>
    public partial class vwMedicamento : Window
    {
        public vwMedicamento()
        {
            InitializeComponent();
        }
        byte opcion = 0;

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        Common.Medicamento med;
        MedicamentoBRL brl;
        void LlenarDataGrid()
        {
            try
            {
                brl = new MedicamentoBRL();
                dgvDatos.ItemsSource = null;
                dgvDatos.ItemsSource = brl.Select().DefaultView;
                dgvDatos.Columns[0].Visibility = Visibility.Hidden;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + " error al filtrar");
            }
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
            txtNombreMedicamento.Focus();



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
                        med = new Common.Medicamento(txtNombreMedicamento.Text, DateTime.Parse(dtFechaVen.ToString()), double.Parse(txtPrecioUnitario.Text), txtTipoMedicamento.Text, byte.Parse(txtCantidadMedicamentos.Text));
                        brl = new MedicamentoBRL(med);
                        brl.Insert();

                        MessageBox.Show("categoria insertado con exito...");
                     
                        DesHabilitar();
                        LlenarDataGrid();

                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message);
                    }
                    break;

                case 2:
                    try
                    {
                        med.NombreMedicamento = txtNombreMedicamento.Text;
                        med.PrecioUnitario = double.Parse(txtPrecioUnitario.ToString());
                        med.FechaVencimiento = DateTime.Parse(dtFechaVen.ToString());

                        brl = new MedicamentoBRL(med);
                        brl.Update();



                        MessageBox.Show(" categoria Modificado con exito...");
                    
                        LlenarDataGrid();
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

        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            DesHabilitar();
        }



        private void Window_Loaded(object sender, RoutedEventArgs e)
        {


        }
    

        private void BtnCerar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void DgvDatos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
                med = null;
                if (dgvDatos.SelectedItems != null && dgvDatos.Items.Count > 0)
                {
                    try
                    {
                        DataRowView dataRow = (DataRowView)dgvDatos.SelectedItem;
                        int id = int.Parse(dataRow.Row.ItemArray[0].ToString());
                        brl = new MedicamentoBRL();
                      med = brl.Get(id);
                    if (med != null)
                        {
                            txtNombreMedicamento.Text = med.NombreMedicamento;
                            dtFechaVen.Text = med.ToString();
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


