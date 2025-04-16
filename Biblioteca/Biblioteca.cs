﻿using System;
using System.Collections.Generic;

namespace Biblioteca
{
    class Biblioteca
    {
        private List<Libro> libros;

        public Biblioteca()
        {
            this.libros = new List<Libro>();
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
    }
}
