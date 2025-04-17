using System;
using System.Collections.Generic;

namespace Biblioteca
{
    class Biblioteca
    {
        private List<Libro> libros;
        private List<Lector> lectores; // Nuevo atributo para las colecciones de lectores

        public Biblioteca()
        {
            this.libros = new List<Libro>();
            this.lectores = new List<Lector>(); //Se crea la lista de lectores vacia
        }

        private Libro buscarLibro(string titulo)
        {
            Libro libroBuscado = null;
            int i = 0;
            while (i < libros.Count && !libros[i].getTitulo().Equals(titulo))
                i++;
            if (i != libros.Count) 
                libroBuscado=libros[i];
            return libroBuscado;
        }

        public bool agregarLibro(string titulo,string autor,string editorial)
        {
            bool resultado = false;
            Libro libro;
            libro = buscarLibro(titulo);
            if (libro == null)
            {
                libro = new Libro(titulo, autor, editorial);
                libros.Add(libro);
                resultado = true;
            }
            return resultado;
        }

        public bool eliminarLibro(string titulo)
        {
            bool resultado = false;
            Libro libro;
            libro = buscarLibro(titulo);
            if(libro != null)
            {
                libros.Remove(libro);
                resultado=true;
            }
            return resultado;
        }

        public void listarLibros()
        {
            foreach (var libro in libros)
            {
                Console.WriteLine(libro);
            }
        }

        // metodos que faltan implementar

        /*
        private Lector buscarLector(int dni)
        {

        }
        */

        /*
        public bool altaLector(string nombre, int dni)
        {

        }
        */

        /*
        public void listarLectores()
        {

        }
        */

        /*
        public string prestarLibro(string titulo, int dni)
        {

        }
        */

    }
}
