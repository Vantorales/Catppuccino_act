using System;

namespace ACT_1.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Nickname { get; set; }
        public string Password { get; set; }
        public string Mail { get; set; }
        public string InfusionFavorita { get; set; }

        public Usuario() { }    

        public Usuario(int id, string nombre, string apellido, string nickname, string password, string mail, string infusionFavorita)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            Nickname = nickname;
            Password = password;
            Mail = mail;
            InfusionFavorita = infusionFavorita;
        }

        public void mostrarInfo()
        {
            Console.WriteLine($"Su ID es {Id}");
            Console.WriteLine($"Su nombre es {Nombre}");
            Console.WriteLine($"Su Apellido es {Apellido}");
            Console.WriteLine($"Su Nickname es {Nickname}");
            Console.WriteLine($"Su Mail es {Mail}");
            Console.WriteLine($"Su Infusion Favorita es {InfusionFavorita}");
        }

    }

    
}
