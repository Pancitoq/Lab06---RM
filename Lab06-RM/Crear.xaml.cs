using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace Lab06_RM
{
    /// <summary>
    /// Lógica de interacción para Crear.xaml
    /// </summary>
    public partial class Crear : Window
    {
        public Crear()
        {
            InitializeComponent();
        }

        private void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            {
                try
                {
                    string cadena = "Data Source=LAB1507-09\\SQLEXPRESS02; Initial Catalog=Neptuno; User ID=usuario01; Password=142857**;";
                    using (SqlConnection connection = new SqlConnection(cadena))
                    {
                        connection.Open();

                        using (SqlCommand command = new SqlCommand("InsertarEmpleado", connection))
                        {
                            command.CommandType = CommandType.StoredProcedure;


                            SqlParameter sqlParameter1 = new SqlParameter("@IdEmpleado", SqlDbType.Int);
                            sqlParameter1.Value = Convert.ToInt32(txtIdEmpleado.Text);
                            command.Parameters.Add(sqlParameter1);

                            SqlParameter sqlParameter2 = new SqlParameter("@Apellidos", SqlDbType.NVarChar, 50);
                            sqlParameter2.Value = txtApellidos.Text;
                            command.Parameters.Add(sqlParameter2);

                            SqlParameter sqlParameter3 = new SqlParameter("@Nombre", SqlDbType.NVarChar, 50);
                            sqlParameter3.Value = txtNombre.Text;
                            command.Parameters.Add(sqlParameter3);

                            SqlParameter sqlParameter4 = new SqlParameter("@Cargo", SqlDbType.NVarChar, 50);
                            sqlParameter4.Value = txtCargo.Text;
                            command.Parameters.Add(sqlParameter4);

                            SqlParameter sqlParameter5 = new SqlParameter("@Tratamiento", SqlDbType.NVarChar, 50);
                            sqlParameter5.Value = txtTratamiento.Text;
                            command.Parameters.Add(sqlParameter5);

                            SqlParameter sqlParameter6 = new SqlParameter("@FechaNacimiento", SqlDbType.Date);
                            sqlParameter6.Value = dpFechaNacimiento.SelectedDate;
                            command.Parameters.Add(sqlParameter6);

                            SqlParameter sqlParameter7 = new SqlParameter("@FechaContratacion", SqlDbType.Date);
                            sqlParameter7.Value = dpFechaContratacion.SelectedDate;
                            command.Parameters.Add(sqlParameter7);

                            SqlParameter sqlParameter8 = new SqlParameter("@Direccion", SqlDbType.NVarChar, 100);
                            sqlParameter8.Value = txtDireccion.Text;
                            command.Parameters.Add(sqlParameter8);

                            SqlParameter sqlParameter9 = new SqlParameter("@Ciudad", SqlDbType.NVarChar, 50);
                            sqlParameter9.Value = txtCiudad.Text;
                            command.Parameters.Add(sqlParameter9);

                            SqlParameter sqlParameter10 = new SqlParameter("@Region", SqlDbType.NVarChar, 50);
                            sqlParameter10.Value = txtRegion.Text;
                            command.Parameters.Add(sqlParameter10);

                            SqlParameter sqlParameter11 = new SqlParameter("@CodPostal", SqlDbType.NVarChar, 10);
                            sqlParameter11.Value = txtCodPostal.Text;
                            command.Parameters.Add(sqlParameter11);

                            SqlParameter sqlParameter12 = new SqlParameter("@Pais", SqlDbType.NVarChar, 50);
                            sqlParameter12.Value = txtPais.Text;
                            command.Parameters.Add(sqlParameter12);

                            SqlParameter sqlParameter13 = new SqlParameter("@TelDomicilio", SqlDbType.NVarChar, 20);
                            sqlParameter13.Value = txtTelDomicilio.Text;
                            command.Parameters.Add(sqlParameter13);

                            SqlParameter sqlParameter14 = new SqlParameter("@Extension", SqlDbType.NVarChar, 10);
                            sqlParameter14.Value = txtExtension.Text;
                            command.Parameters.Add(sqlParameter14);

                            SqlParameter sqlParameter15 = new SqlParameter("@Notas", SqlDbType.NVarChar, -1);
                            sqlParameter15.Value = txtNotas.Text;
                            command.Parameters.Add(sqlParameter15);

                            SqlParameter sqlParameter16 = new SqlParameter("@Jefe", SqlDbType.Int);
                            sqlParameter16.Value = Convert.ToInt32(txtJefe.Text);
                            command.Parameters.Add(sqlParameter16);

                            SqlParameter sqlParameter17 = new SqlParameter("@SueldoBasico", SqlDbType.Decimal);
                            sqlParameter17.Value = Convert.ToDecimal(txtSueldoBasico.Text);
                            command.Parameters.Add(sqlParameter17);

                            SqlParameter sqlParameter18 = new SqlParameter("@Activo", SqlDbType.Bit);
                            sqlParameter18.Value = chkActivo.IsChecked == true ? 1 : 0;
                            command.Parameters.Add(sqlParameter18);


                            int result = command.ExecuteNonQuery();
                            if (result > 0)
                            {
                                MessageBox.Show("Empleado registrado correctamente.");
                            }
                            else
                            {
                                MessageBox.Show("Error al registrar el empleado.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
        }
    }
}
