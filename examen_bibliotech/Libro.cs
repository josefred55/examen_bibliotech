using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace examen_bibliotech
{
    internal class Libro
    {
        //atributos
        private string titulo;
        private string autor;
        private int anyo;
        private bool disponible;

        //constructor
        public Libro(string titulo, string autor, int anyo, bool disponible)
        {
            this.titulo = titulo;
            this.autor = autor;
            this.anyo = anyo;
            this.disponible = disponible;
        }

        //getters y setters
        public string Titulo { get => titulo; set => titulo = value; }
        public string Autor { get => autor; set => autor = value; }
        public int Anyo { get => anyo; set => anyo = value; }
        public bool Disponible { get => disponible; set => disponible = value; }

        //metodo toString
        public override string ToString()
        {
            return $"{titulo} - {autor} ({anyo})";
        }
    }
}
