using ACT_1.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Act._2_Entregable.Data
{
    class ProductoVendidoVendidoData
    {
        private static string connectionstring = @"server=localhost\sqlexpress;database=catpuccinodb;trusted_connection=true;";
        public static List<ProductoVendido> ListarProductoVendidosVendidos()
        {
            List<ProductoVendido> ListaProductoVendidos = new List<ProductoVendido>();

            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                string getallquery = "select * from ProductoVendido";
                using (SqlCommand command = new SqlCommand(getallquery, connection))
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {

                            while (reader.Read())
                            {
                                ProductoVendido productoVendido = new ProductoVendido();
                                productoVendido.Id = Convert.ToInt32(reader["Id"]);
                                productoVendido.IdProducto = Convert.ToInt32(["IdProducto"]);
                                productoVendido.Stock = Convert.ToInt32(["Stock"]); // revisar
                                productoVendido.IdVenta = Convert.ToInt32(["IdVenta"]);

                                ListaProductoVendidos.Add(productoVendido);

                            }
                        }

                    }
                }

                connection.Close();
                return ListaProductoVendidos;
            }
        }

        public static ProductoVendido ObtenerProductoVendido(int id)
        {
            ProductoVendido productoVendido = null;

            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                string getidquery = "select * from ProductoVendido where id = @IdProductoVendido";
                using (SqlCommand command = new SqlCommand(getidquery, connection))
                {
                    var parametro = new SqlParameter();
                    parametro.ParameterName = "IdProductoVendido";
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
                                productoVendido = new ProductoVendido
                                {
                                    Id = Convert.ToInt32(reader["id"]),
                                    IdProducto = Convert.ToInt32(["IdProducto"]),
                                    Stock = Convert.ToInt32(["Stock"]), // revisar
                                    IdVenta = Convert.ToInt32(["IdVenta"])
                                };
                            }
                        }
                    }
                }
                connection.Close();
                return productoVendido;
            }
        }

        public static void CrearProductoVendido(ProductoVendido productoVendido)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                string insertquery = "insert into ProductoVendido (IdProducto, Stock, IdVenta) " +
                                     "values (@IdProducto, @Stock, @IdVenta)";
                using SqlCommand command = new SqlCommand(insertquery, connection);

                command.Parameters.AddWithValue("@IdProducto", productoVendido.IdProducto);
                command.Parameters.AddWithValue("@Stock", productoVendido.Stock);
                command.Parameters.AddWithValue("@IdVenta", productoVendido.IdVenta);

                try
                {
                    connection.Open();
                    int rowsaffected = command.ExecuteNonQuery();
                    Console.WriteLine($"se insertó correctamente el Producto Vendido. filas afectadas: {rowsaffected}");
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"error al insertar el ProductoVendido: {ex.Message}");
                }
                connection.Close();
            }
        }

        public static void ModificarProductoVendido(ProductoVendido productoVendido)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                if (ObtenerProductoVendido(productoVendido.Id) != null)
                {
                    string updateQuery = "update ProductoVendido set Id = @NuevoIdProducto, IdProducto = @IdProducto, Stock = @NuevoStock " +
                                         "where Id = @IdProductoVendido";
                    using SqlCommand command = new SqlCommand(updateQuery, connection);

                    command.Parameters.AddWithValue("@IdProductoVendido", productoVendido.Id);
                    command.Parameters.AddWithValue("@NuevoIdProducto", productoVendido.IdProducto);
                    command.Parameters.AddWithValue("@NuevoStock", productoVendido.Stock);
                    command.Parameters.AddWithValue("@NuevoIdVenta", productoVendido.IdVenta);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine($"Se modificó correctamente el productoVendido. Filas afectadas: {rowsAffected}");
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine($"Error al modificar el productoVendido: {ex.Message}");
                    }
                    connection.Close();
                }
            }
        }

        public static void EliminarProductoVendido(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                if (ObtenerProductoVendido(id) != null)
                {
                    string deleteQuery = "delete from ProductoVendido where Id = @IdProductoVendido";
                    using SqlCommand command = new SqlCommand(deleteQuery, connection);

                    command.Parameters.AddWithValue("@IdProductoVendido", id);
                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine($"Se eliminó correctamente el Producto Vendido. Filas afectadas: {rowsAffected}");
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine($"Error al eliminar el Producto Vendido: {ex.Message}");
                    }
                    connection.Close();
                }
            }
        }
    }
}

