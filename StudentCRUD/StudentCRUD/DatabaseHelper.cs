using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using System.Windows;

namespace ParcialFinalProgramacion
{
    public class DatabaseHelper
    {
        private string connectionString = "Server=HPERIKA\\SQLEXPRESS;Database=StudentDB;Encrypt=True;Integrated Security=True;";

        public DataTable GetAllStudents()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Usuarios";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
                return null;
            }
        }

        public void AddStudent(string carnet, string nombre, string telefono, string grado, string usuario)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO Usuarios (Carnet, Nombre, Telefono, Grado, Usuario) VALUES (@Carnet, @Nombre, @Telefono, @Grado, @Usuario)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Carnet", carnet);
                    command.Parameters.AddWithValue("@Nombre", nombre);
                    command.Parameters.AddWithValue("@Telefono", telefono);
                    command.Parameters.AddWithValue("@Grado", grado);
                    command.Parameters.AddWithValue("@Usuario", usuario);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        public void UpdateStudent(string carnet, string nombre, string telefono, string grado, string usuario)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "UPDATE Usuarios SET Nombre = @Nombre, Telefono = @Telefono, Grado = @Grado, Usuario = @Usuario WHERE Carnet = @Carnet";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Carnet", carnet);
                    command.Parameters.AddWithValue("@Nombre", nombre);
                    command.Parameters.AddWithValue("@Telefono", telefono);
                    command.Parameters.AddWithValue("@Grado", grado);
                    command.Parameters.AddWithValue("@Usuario", usuario);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        public void DeleteStudent(string carnet)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM Usuarios WHERE Carnet = @Carnet";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Carnet", carnet);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
    }
}
