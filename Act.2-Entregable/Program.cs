using Act._2_Entregable.Data;
using ACT_1.Models;

string opcion = menuUser();

while (opcion != "6") 
{
    switch (opcion)
    {
        case "1":
            Console.Clear();
            Console.WriteLine("Mostrando Lista de Usuarios...");
            var usuarios = UsuarioData.ListarUsuarios();

            foreach(var usuario in usuarios)
            {
                usuario.mostrarInfo();
                Console.WriteLine("----------------------------------");
            }
            break;
        case "2":
            Console.Clear();
            Console.WriteLine("Ingrese el ID de Usuario a Buscar...");
            int id = Convert.ToInt32(Console.ReadLine());
            Usuario getUser = UsuarioData.ObtenerUsuario(id);
            getUser.mostrarInfo();

            break;
        case "3":
            Console.Clear();
            Console.WriteLine("Ingrese los datos del Usuario a Crear:");
            Console.Write("Nombre: ");
            string nombre = Console.ReadLine();
            Console.Write("Apellido: ");
            string apellido = Console.ReadLine();
            Console.Write("Nickname: ");
            string nickname = Console.ReadLine();
            Console.Write("Contraseña: ");
            string password = Console.ReadLine();
            Console.Write("Correo electrónico: ");
            string mail = Console.ReadLine();
            Console.Write("Infusión favorita: ");
            string infusionFavorita = Console.ReadLine();

            Usuario usuarioInfo = new Usuario(0, nombre, apellido, nickname, password, mail, infusionFavorita);
            UsuarioData.CrearUsuario(usuarioInfo);
            break;
        case "4":
            Console.Clear();
            Console.WriteLine("Ingrese el id del usuario a modificar");
            Usuario usuarioModificado = UsuarioData.ObtenerUsuario(Convert.ToInt32(Console.ReadLine()));
            menuDatosModificar(usuarioModificado);
            break;
        case "5":
            Console.Clear();
            Console.WriteLine("Ingrese el id del usuario a eliminar");
            int idUsuarioEliminar = Convert.ToInt32(Console.ReadLine());
            UsuarioData.EliminarUsuario(idUsuarioEliminar);
            Console.WriteLine("Usuario eliminado correctamente.");
            break;
        default:
            Console.WriteLine("Opción no válida. Por favor, ingrese una opción válida.");
            break;
    }

    Console.ReadLine();
    Console.Clear();
    opcion = menuUser();

}

string menuUser() 
{
    Console.WriteLine("Bievenidos a sistema de gestión de CATPUCCINO");
    Console.WriteLine("Menú:");
    Console.WriteLine("1. Mostrar Usuarios");
    Console.WriteLine("2. Obtener Usuario");
    Console.WriteLine("3. Crear Usuario");
    Console.WriteLine("4. Modificar Usuario");
    Console.WriteLine("5. Eliminar Usuario");
    Console.WriteLine("Ingrese la opción deseada: ");
    Console.WriteLine("6. Presione la opción 6 si desea Salir del sistema");

    return Convert.ToString(Console.ReadLine());
}

void menuDatosModificar(Usuario usuario) 
{

    int opcionModificar = subMenuModificarUser();

    while (opcionModificar != 6)
    {
        switch (opcionModificar)
        {
            case 1:
                Console.Clear();
                Console.WriteLine("Ingrese el nuevo nombre");
                string newUserName = Convert.ToString(Console.ReadLine());

                usuario.Nombre = newUserName;

                break;

            case 2:
                Console.Clear();
                Console.WriteLine("Ingrese el nuevo apellido");
                string newUserLastName = Convert.ToString(Console.ReadLine());

                usuario.Apellido = newUserLastName;

                break;

            case 3:
                Console.Clear();
                Console.WriteLine("Ingrese el nuevo apellido");
                string newUserNickName = Convert.ToString(Console.ReadLine());

                usuario.Nickname = newUserNickName;

                break;


            case 4:
                Console.Clear();
                Console.WriteLine("Ingrese el nuevo apellido");
                string newUserEmail = Convert.ToString(Console.ReadLine());

                usuario.Mail = newUserEmail;

                break;

            case 5:
                Console.Clear();
                Console.WriteLine("Ingrese el nuevo apellido");
                string newUserInfusion = Convert.ToString(Console.ReadLine());

                usuario.InfusionFavorita = newUserInfusion;

                break;

            default:
                Console.WriteLine("Valor ingresado incorecto");
                opcionModificar = subMenuModificarUser();
                break;    
        }

        UsuarioData.ModificarUsuario(usuario);
        
        Console.ReadLine();
        Console.Clear();
        opcionModificar = subMenuModificarUser();

    }


}

int subMenuModificarUser() 
{
    Console.WriteLine("1- ¿Desea modificar Nombre? Nombre Anterior: " );
    Console.WriteLine("2- Modificar Apellido");
    Console.WriteLine("3- Modificar Nickname");
    Console.WriteLine("4- Modificar Mail");
    Console.WriteLine("5- Modificar Infusion");
    Console.WriteLine("6- Atras");

    return Convert.ToInt32(Console.ReadLine());
}