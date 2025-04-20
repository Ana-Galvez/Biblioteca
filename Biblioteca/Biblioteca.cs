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

        /* Métodos relacionados con lectores */

        private Lector buscarLector(int DNI)
        {
            Lector lectorBuscado = null;
            int i = 0;
            while (i < lectores.Count && !lectores[i].getDni().Equals(DNI))
                i++;
            if (i != lectores.Count)
                lectorBuscado = lectores[i];
            return lectorBuscado;
        }
        public bool altaLector(string nombre, int DNI)
        {
            bool resultado = false;
            Lector lector;
            lector = buscarLector(DNI);
            if (lector == null)
            {
                lector = new Lector(nombre, DNI);
                lectores.Add(lector);
                resultado = true;
            }
            return resultado;
        }

        public int CantidadLectores()
        {
            return lectores.Count;
        }

        public void listarLectores()
        {
            foreach (var lector in lectores)
            {
                Console.WriteLine(lector);
            }
        }

        
        public string prestarLibro(string titulo, int DNI)
        {
            Libro libro = buscarLibro(titulo);
            if (libro == null)
            {
                return "LIBRO INEXISTENTE";
            }

            if (!libro.estaDisponible())
            {
                return "LIBRO NO DISPONIBLE";
            }

            Lector lector = buscarLector(DNI);
            if (lector == null)
            {
                return "LECTOR INEXISTENTE";
            }
        
            if (lector.getPrestamos() >= 3)
            {
                return "TOPE DE PRÉSTAMO ALCANZADO";
            }
        
            lector.agregarPrestamo(libro);
            libro.marcarComoPrestado(); // No se elimina el libro lo marca no disponible ya que si se elimina se tendria que volver a cargar
            return "PRÉSTAMO EXITOSO";
        }
    }
}
