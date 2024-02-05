using ACT_1.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Act._2_Entregable.Data
{
    class UsuarioData
    {
        private static string connectionString = @"Server=localhost\SQLEXPRESS;Database=CatpuccinoDB;Trusted_Connection=true;";
        public static List<Usuario> ListarUsuarios()
        {
            List<Usuario> ListaUsuarios = new List<Usuario>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string getAllQuery = "select * from Usuarios";
                using (SqlCommand command = new SqlCommand(getAllQuery, connection))
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {

                            while (reader.Read())
                            {
                                Usuario usuario = new Usuario();
                                usuario.Id = Convert.ToInt32(reader["Id"]);
                                usuario.Nombre = reader["Nombre"].ToString();
                                usuario.Apellido = reader["Apellido"].ToString();
                                usuario.Nickname = reader["Nickname"].ToString();
                                usuario.Password = reader["Password"].ToString();
                                usuario.Mail = reader["Mail"].ToString();
                                usuario.InfusionFavorita = reader["InfusionFavorita"].ToString();

                                ListaUsuarios.Add(usuario);

                            }
                        }

                    }
                }

                connection.Close();
                return ListaUsuarios;
            }
        }

        public static Usuario ObtenerUsuario(int id)
        {
            Usuario usuario = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string getIdQuery = "select * from Usuarios where Id = @idUsuario";
                using (SqlCommand command = new SqlCommand(getIdQuery, connection))
                {
                    var parametro = new SqlParameter();
                    parametro.ParameterName = "idUsuario";
                    parametro.SqlDbType = System.Data.SqlDbType.Int;
                    parametro.Value = id;

                    command.Parameters.Add(parametro);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {

                            while (reader.Read())
                            {
                                usuario = new Usuario
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    Nombre = reader["Nombre"].ToString(),
                                    Apellido = reader["Apellido"].ToString(),
                                    Nickname = reader["Nickname"].ToString(),
                                    Password = reader["Password"].ToString(),
                                    Mail = reader["Mail"].ToString(),
                                    InfusionFavorita = reader["InfusionFavorita"].ToString()
                                };
                                
                            }
                        }
                        
                    }
                }
                
                connection.Close();
                return usuario;
            }
        }

        public static void CrearUsuario(Usuario usuario)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string insertQuery = "insert into Usuarios (Nombre, Apellido, Nickname, Password, Mail, InfusionFavorita) " +
                                     "values (@Nombre, @Apellido, @Nickname, @Password, @Mail, @InfusionFavorita)";
                using SqlCommand command = new SqlCommand(insertQuery, connection);

                command.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                command.Parameters.AddWithValue("@Apellido", usuario.Apellido);
                command.Parameters.AddWithValue("@Nickname", usuario.Nickname);
                command.Parameters.AddWithValue("@Password", usuario.Password);
                command.Parameters.AddWithValue("@Mail", usuario.Mail);
                command.Parameters.AddWithValue("@InfusionFavorita", usuario.InfusionFavorita);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    Console.WriteLine($"Se insertó correctamente el usuario. Filas afectadas: {rowsAffected}");
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"Error al insertar el usuario: {ex.Message}");
                }
                connection.Close();
            }
        }

        public static void ModificarUsuario(Usuario usuario)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                if (ObtenerUsuario(usuario.Id) != null)
                {
                    string updateQuery = "update Usuarios set Nombre = @NuevoNombre, Apellido = @NuevoApellido, " +
                              "Nickname = @NuevoNickname, Password = @NuevaPassword, " +
                              "Mail = @NuevoMail, InfusionFavorita = @NuevaInfusionFavorita " +
                              "where Id = @IdUsuario";
                    using SqlCommand command = new SqlCommand(updateQuery, connection);

                    command.Parameters.AddWithValue("@IdUsuario", usuario.Id);
                    command.Parameters.AddWithValue("@NuevoNombre", usuario.Nombre);
                    command.Parameters.AddWithValue("@NuevoApellido", usuario.Apellido);
                    command.Parameters.AddWithValue("@NuevoNickname", usuario.Nickname);
                    command.Parameters.AddWithValue("@NuevaPassword", usuario.Password);
                    command.Parameters.AddWithValue("@NuevoMail", usuario.Mail);
                    command.Parameters.AddWithValue("@NuevaInfusionFavorita", usuario.InfusionFavorita);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine($"Se modificó correctamente el usuario. Filas afectadas: {rowsAffected}");
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine($"Error al modificar el usuario: {ex.Message}");
                    }
                    connection.Close();
                }
            }
        }

        public static void EliminarUsuario(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                if (ObtenerUsuario(id) != null)
                {
                    string deleteQuery = "delete from Usuarios where Id = @IdUsuario";
                    using SqlCommand command = new SqlCommand(deleteQuery, connection);

                    command.Parameters.AddWithValue("@IdUsuario", id);
                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine($"Se eliminó correctamente al usuario. Filas afectadas: {rowsAffected}");
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine($"Error al eliminar al usuario: {ex.Message}");
                    }
                    connection.Close();
                }
            }
        }
    }
}
