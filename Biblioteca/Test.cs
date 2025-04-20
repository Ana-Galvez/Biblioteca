using System;

namespace Biblioteca
{
    internal class Test
    {
        static void Main(string[] args)
        {
            Biblioteca biblioteca = new Biblioteca();
            SolicitarYCargarLibros();
            SolicitarYCargarLectores();
            //biblioteca.eliminarLibro("Libro 3");
            //Console.WriteLine("---------------------");
            //biblioteca.listarLibros();
            //SolicitarYCargarLibros);
            //Console.WriteLine("---------------------");
            //biblioteca.listarLibros();
            Console.WriteLine("");
            Console.WriteLine("LISTA DE LIBROS");
            biblioteca.listarLibros();
            Console.WriteLine("");
            Console.WriteLine("LISTA DE LECTORES");
            biblioteca.listarLectores();
            Console.WriteLine("");
            SolicitarYPrestarLibro();
            if (HayMasDeUnLector())
            {
                Console.WriteLine("¿Desea realizar otro préstamo? (s/n)");
                string respuesta = Console.ReadLine().ToLower();

                if (respuesta == "s")
                {
                    SolicitarYPrestarLibro();
                }
            }
            Console.WriteLine("");
            Console.WriteLine("LISTA DE LIBROS:");
            biblioteca.listarLibros();
            Console.WriteLine("LISTA DE LECTORES");
            biblioteca.listarLectores();
            Console.WriteLine("\nPresione ENTER para salir...");
            Console.ReadLine();


            void cargarLibros(int cantidad)
            {
                bool pudeCargar;
                for (int i = 1; i <= cantidad ; i++)
                {
                    pudeCargar = biblioteca.agregarLibro("Libro " + i, "Autor " + i, "Editorial " + i);
                    if (pudeCargar) Console.WriteLine("Libro " + i + " agregado correctamente.");
                    else Console.WriteLine("Libro " + i + ". Ya existe en la biblioteca");

                }
            }
            void cargarLectores(int cantidad) // si se escribe 2 o más DNI iguales el segundo y/o más no se agrega
            {
                bool pudeCargar;
                for (int i = 1; i <= cantidad; i++)
                {
                    Console.WriteLine("Agregue el nombre del lector");
                    string nombre = Console.ReadLine();
                    int DNI = SolicitarDNI();//Método para validar que sea número entero positivo
                    pudeCargar = biblioteca.altaLector(nombre, DNI);
                    if (pudeCargar) Console.WriteLine("Lector " + nombre + " con DNI " + DNI + " agendado correctamente.");
                    else Console.WriteLine("Lector " + nombre + " con DNI " + DNI + " ya existe.");
                }
            }

            bool HayMasDeUnLector()
            {
                return biblioteca.CantidadLectores() > 1;
            }

            // Validaciones para ingresar números enteros para cantidad de libros y de lectores
            void SolicitarYCargarLibros()
            {
                while (true)
                {
                    Console.WriteLine("¿Cuántos libros desea agregar?");
                    string input = Console.ReadLine();

                    if (int.TryParse(input, out int cantidad) && cantidad > 0)
                    {
                        Console.WriteLine("Libros:");
                        cargarLibros(cantidad);
                        return;
                    }
                    else Console.WriteLine("Debe ingresar un número entero positivo. Intente nuevamente.");
                }
            }
            void SolicitarYCargarLectores()
            {
                while (true)
                {
                    Console.WriteLine("¿Cuántos lectores desea agregar?");
                    string input = Console.ReadLine();

                    if (int.TryParse(input, out int cantidad) && cantidad > 0)
                    {
                        Console.WriteLine("Lectores:");
                        cargarLectores(cantidad);
                        return;
                    }
                    else Console.WriteLine("Debe ingresar un número entero positivo. Intente nuevamente.");
                }
            }

            // Validación para el número de DNI
            int SolicitarDNI()
            {
                while (true)
                {
                    Console.WriteLine("Agregue el DNI del lector");
                    string input = Console.ReadLine();

                    if (int.TryParse(input, out int dni) && dni > 0)
                    {
                        return dni;
                    }
                    else Console.WriteLine("Error: Debe ingresar un número de DNI válido");
                }
            }

            void SolicitarYPrestarLibro()
            {
                Console.WriteLine("Ingrese el título del libro a prestar:");
                string titulo = Console.ReadLine();

                int dni = SolicitarDNI();

                string resultado = biblioteca.prestarLibro(titulo, dni);
                Console.WriteLine($"Resultado del préstamo: {resultado}");
            }

        }
    }
}
