using System;

namespace Biblioteca
{
    internal class Test
    {
        static void Main(string[] args)
        {
            Biblioteca biblioteca = new Biblioteca();
            cargarLibros(10);
            cargarLibros(2);
            biblioteca.listarLibros();
            biblioteca.eliminarLibro("Libro 3");
            Console.WriteLine("---------------------");
            biblioteca.listarLibros();
            cargarLibros(3);
            Console.WriteLine("---------------------");
            biblioteca.listarLibros();
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
        }
    }
}
