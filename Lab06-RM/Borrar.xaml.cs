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
    /// Lógica de interacción para Borrar.xaml
    /// </summary>
    public partial class Borrar : Window
    {
        public Borrar()
        {
            InitializeComponent();
        }

        private void btnBorrarEmpleado_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string cadena = "Data Source=LAB1507-09\\SQLEXPRESS02; Initial Catalog=Neptuno; User ID=usuario01; Password=142857**;";
                using (SqlConnection connection = new SqlConnection(cadena))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("EliminarEmpleadoLogico", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;


                        SqlParameter sqlParameter1 = new SqlParameter("@IdEmpleado", SqlDbType.Int);
                        sqlParameter1.Value = Convert.ToInt32(txtIdEmpleado.Text);
                        command.Parameters.Add(sqlParameter1);

                        int result = command.ExecuteNonQuery();
                        if (result > 0)
                        {
                            MessageBox.Show("Empleado borrado correctamente.");
                        }
                        else
                        {
                            MessageBox.Show("Error al borrar el empleado.");
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