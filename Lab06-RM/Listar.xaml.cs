using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Windows;

namespace Lab06_RM
{
    public partial class Listar : Window
    {
        public Listar()
        {
            InitializeComponent();
        }

        private void btnListar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string cadena = "Data Source=LAB1507-09\\SQLEXPRESS02; Initial Catalog=Neptuno; User ID=usuario01; Password=142857**;";
                using (SqlConnection connection = new SqlConnection(cadena))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand("ListarEmpleados", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    List<Empleados> listaEmpleados = new List<Empleados>();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Empleados empleado = new Empleados
                        {
                            IdEmpleado = reader["IdEmpleado"].ToString(),
                            Apellidos = reader["Apellidos"].ToString(),
                            Nombre = reader["Nombre"].ToString(),
                            Cargo = reader["Cargo"].ToString(),
                            Tratamiento = reader["Tratamiento"].ToString(),
                            FechaNacimiento = reader.IsDBNull(reader.GetOrdinal("FechaNacimiento")) ? null : Convert.ToDateTime(reader["FechaNacimiento"]),
                            FechaContratacion = reader.IsDBNull(reader.GetOrdinal("FechaContratacion")) ? null : Convert.ToDateTime(reader["FechaContratacion"]),
                            Direccion = reader.IsDBNull(reader.GetOrdinal("Direccion")) ? null : reader["Direccion"].ToString(),
                            Ciudad = reader.IsDBNull(reader.GetOrdinal("Ciudad")) ? null : reader["Ciudad"].ToString(),
                            Region = reader.IsDBNull(reader.GetOrdinal("Region")) ? null : reader["Region"].ToString(),
                            CodPostal = reader.IsDBNull(reader.GetOrdinal("CodPostal")) ? null : reader["CodPostal"].ToString(),
                            Pais = reader.IsDBNull(reader.GetOrdinal("Pais")) ? null : reader["Pais"].ToString(),
                            TelDomicilio = reader.IsDBNull(reader.GetOrdinal("TelDomicilio")) ? null : reader["TelDomicilio"].ToString(),
                            Extension = reader.IsDBNull(reader.GetOrdinal("Extension")) ? null : reader["Extension"].ToString(),
                            Notas = reader.IsDBNull(reader.GetOrdinal("Notas")) ? null : reader["Notas"].ToString(),
                            Jefe = reader.IsDBNull(reader.GetOrdinal("Jefe")) ? null : reader["Jefe"].ToString(),
                            SueldoBasico = reader.IsDBNull(reader.GetOrdinal("SueldoBasico")) ? (decimal?)null : Convert.ToDecimal(reader["SueldoBasico"]),
                            Activo = reader.IsDBNull(reader.GetOrdinal("Activo")) ? false : Convert.ToBoolean(reader["Activo"])
                        };
                        listaEmpleados.Add(empleado);
                    }

                    dgvEmpleados.ItemsSource = listaEmpleados;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        public class Empleados
        {
            public string IdEmpleado { get; set; }
            public string Apellidos { get; set; }
            public string Nombre { get; set; }
            public string Cargo { get; set; }
            public string Tratamiento { get; set; }
            public DateTime? FechaNacimiento { get; set; } 
            public DateTime? FechaContratacion { get; set; }
            public string Direccion { get; set; }
            public string Ciudad { get; set; }
            public string Region { get; set; }
            public string CodPostal { get; set; }
            public string Pais { get; set; }
            public string TelDomicilio { get; set; }
            public string Extension { get; set; }
            public string Notas { get; set; }
            public string Jefe { get; set; }
            public decimal? SueldoBasico { get; set; }
            public bool Activo { get; set; }
        }
    }
}
