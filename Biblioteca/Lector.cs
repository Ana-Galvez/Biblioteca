using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    

    class Lector
    {
        private string nombre;
        private int dni;
        private List<Libro> prestamos;

        public Lector(string nombre, int dni)
        {
            this.nombre = nombre;
            this.dni = dni;
            this.prestamos = new List<Libro>();
        }

        public int getDni()
        {
            return dni;
        }

        private bool puedeRealizarPrestamo()
        {
            return prestamos.Count < 3;
        }

        public void agregarPrestamo(Libro libro)
        {
            if (puedeRealizarPrestamo())
            {
                prestamos.Add(libro);
            }
        }

        public void listarPrestamos()
        {
            foreach (var libro in prestamos)
            {
                Console.WriteLine(libro);
            }
        }

        public override string ToString()
        {
            return "Nombre: "+nombre+", DNI: "+dni+", Libros en préstamo: "+prestamos.Count;
        }
    }

   

    }
