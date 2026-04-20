using System;
using System.Globalization;

namespace Prueba
{
    public class Program
    {
        enum Menu
        {
            Agregar = 1,
            Ver = 2,
            Buscar = 3,
            ELiminar = 4,
            Actualizar = 5,
            Salir = 6
        }
        public static void Main(string[] args)
        {
            //DECLARACION DE VARIABLE
            int decision = 0;
            string nombre;
            int edad;

            //INICIALIZADOR DE CLASES
            /* var usuario = new Usuario(); */
            var service = new UsuarioService();
            List<Usuario> usuarios = new List<Usuario> ();

            //BLOQUE DE EJECUCION DEL MENU
            do
            {
                Console.WriteLine("Escriba que desea realizar (1. Agregar, 2. Ver, 3. Buscar, 4. Eliminar, 5. Actualizar, 6. Salir)");
                int.TryParse(Console.ReadLine(), out decision);

                switch ((Menu)decision)
                {
                    case Menu.Agregar:
                        Console.WriteLine("Escriba el nombre del usuario: ");
                        nombre = Console.ReadLine();
                        Console.WriteLine("Escriba su edad: ");
                        int.TryParse(Console.ReadLine(), out edad);

                        service.AgregarUsuario(usuarios, nombre, edad);
                    break;

                    case Menu.Ver:
                        service.VerUsuario(usuarios);
                    break;

                    case Menu.Buscar:
                        Console.WriteLine("Escriba el ID del usuario a buscar: ");
                        int.TryParse(Console.ReadLine(), out int idTemp);

                        service.BuscarUsuario(usuarios, idTemp);
                    break;

                    case Menu.ELiminar:
                        Console.WriteLine("Escriba el ID del usuario a eliminar: ");
                        int.TryParse(Console.ReadLine(), out idTemp);

                        service.EliminarUsuario(usuarios, idTemp);
                    break;

                    case Menu.Actualizar:
                        Console.WriteLine("Escriba el ID a actualizar: ");
                        int.TryParse(Console.ReadLine(), out idTemp);

                        service.ActualizaraUsuario(usuarios, idTemp);
                    break;

                    default:
                        Console.WriteLine("Ha elegido una opcion incorrecta.");
                    break;
                }

            } while (decision != (int)Menu.Salir);
        }
    }
}