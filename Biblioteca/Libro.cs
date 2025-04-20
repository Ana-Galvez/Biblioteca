namespace Biblioteca
{
    class Libro
    {
        private string titulo;
        private string autor;
        private string editorial;
        private bool disponible = true;

        public Libro(string titulo, string autor, string editorial)
        {
            this.titulo = titulo;
            this.autor = autor;
            this.editorial = editorial;
        }

        public string getTitulo()
        {
            return titulo;
        }

        public bool estaDisponible()
        {
            return disponible;
        }

        public void marcarComoPrestado()
        {
            disponible = false;
        }

        public void marcarComoDisponible()
        {
            disponible = true;
        }

        public override string ToString()
        {
            string estado = disponible ? "Disponible" : "Prestado";
            return "Título: " + titulo + " Autor: " + autor + " Editorial: " + editorial + " | Estado: " + estado;
        }
    }
}
