using System;

namespace ACT_1.Models
{
    public class Venta
    {
        public int Id { get; set; }
        public string Comentarios { get; set; }
        public int Total { get; set; }
        public int Descuento { get; set; }

        public int IdUsuario { get; set; }

        public Venta() { }
        public Venta(int id, string comentarios, int total, int descuento, int idUsuario)
        {
            Id = id;
            Comentarios = comentarios;
            Total = total;
            Descuento = descuento;
            IdUsuario = idUsuario;
        }
    }
}
