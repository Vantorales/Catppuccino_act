using System;

namespace ACT_1.Models
{
    public class Venta
    {
        public int Id { get; set; }
        public string? Descripcion { get; set; }
        public int Precio { get; set; }
        public int Descuento { get; set; }
        public string? TipoInfusion { get; set; }
        public int IdUsuario { get; set; }
        public int Stock { get; set; }

        public Venta() { }
        public Venta(int id, string comentarios, int total, int descuento, int idUsuario, int stock, string tipoInfusion)
        {
            Id = id;
            Descripcion = comentarios;
            Precio = total;
            Descuento = descuento;
            IdUsuario = idUsuario;
            TipoInfusion = tipoInfusion;
            Stock = stock;
        }
    }
}
