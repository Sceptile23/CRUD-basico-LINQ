using System;
using System.Runtime.Serialization;

namespace Prueba
{
    public class UsuarioService
    {
        public void AgregarUsuario(List<Usuario> usuarios, string nombre, int edad)
        {
            int id;

            if (usuarios.Any(u => u.ID >= 1))
            {
                id = usuarios.Max(u => u.ID) + 1;
            }
            else
            {
                id = 1;
            }
            usuarios.Add(new Usuario {ID = id, Nombre = nombre, Edad = edad});
            Console.WriteLine("Usuario agregado...");
        }

        public void VerUsuario(List<Usuario> usuarios)
        {
            foreach (var usuario in usuarios)
            {
                Console.WriteLine($"ID = {usuario.ID}, Nombre = {usuario.Nombre}, Edad = {usuario.Edad}");
            }
        }

        public void BuscarUsuario(List<Usuario> usuarios, int idTemp)
        {
            if (usuarios.Any())
            {
                var usuario = usuarios.Where(u => u.ID == idTemp);

                foreach(var u in usuario)
                {
                    Console.WriteLine($"ID = {u.ID}, Nombre = {u.Nombre}, Edad = {u.Edad}");
                }
                
            }
            else
            {
                Console.WriteLine("La tabla esta vacia.");
            }
        }

        public void EliminarUsuario(List<Usuario> usuarios, int idTemp)
        {
            if (usuarios.Any())
            {
                //BUSCAMOS EL OBJETO 
                var usuario = usuarios.FirstOrDefault(u => u.ID == idTemp);

                if(usuario != null)
                {
                    usuarios.Remove(usuario);
                    Console.WriteLine("El usuario se ha eliminado.");
                }
                else
                {
                    Console.WriteLine("No se ha encontrado el usuario a eliminar.");
                }
            }
            else
            {
                Console.WriteLine("No se han encontrado datos en la lista.");
            }
        }

        public void ActualizaraUsuario(List<Usuario> usuarios, int idTemp)
        {
            if (usuarios.Any())
            {
                //BUSCAR EL USUARIO A ACTUALIZAR 
                var usuario = usuarios.FirstOrDefault(u => u.ID == idTemp);

                //CAMPO A ACTUALIZAR
                string nombre;
                int edad; 

                //ACTUALIZAMOS LOS CAMPOS
                Console.WriteLine($"Escriba el nombre a actualizar de {usuario.Nombre}");
                nombre = Console.ReadLine();
                Console.WriteLine($"Escriba la edad a actualizar, edad actual {usuario.Edad}: ");
                int.TryParse(Console.ReadLine(), out edad);

                //ACTUALIZAR DATOS
                usuario.Nombre = nombre;
                usuario.Edad = edad; 

                //MENSAJE EXITOSO
                Console.WriteLine("Se ha actualizado los datos.");
            }
            else
            {
                Console.WriteLine("Lista vacia, sin datos.");
            }
        }
    }
}