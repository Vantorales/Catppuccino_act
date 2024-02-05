using System;

namespace ACT_1.Models
{
    public class Producto
    {
        public int Id { get; set; }
        public string TipoInfusion { get; set; }
        public string Descripcion { get; set; }
        public int Precio { get; set; }
        public int Stock { get; set; }
        public int IdUsuario { get; set; }

        public Producto() { }
        public Producto(int id, string tipoInfusion, string descripcion, int precio, int stock, int idUsuario)
        {
            Id = id;
            TipoInfusion = tipoInfusion;
            Descripcion = descripcion;
            Precio = precio;
            Stock = stock;
            IdUsuario = idUsuario;
        }
    }
}
