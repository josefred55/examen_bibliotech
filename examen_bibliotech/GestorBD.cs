using MySql.Data.MySqlClient;  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace examen_bibliotech
{
    internal class GestorBD
    {
        private MySqlConnection conexion;
        public GestorBD()
        {
            MySqlConnectionStringBuilder conexion = new MySqlConnectionStringBuilder();
            conexion.Server = "localhost";
            conexion.UserID = "root";
            conexion.Password = "";
            conexion.Database = "bibliotech";
        }

        //Escribe el metodo Insertar(Libro l) inserte el libro en la tabla usando ExecuteNonQuery() y
        //AddWithValue para los parametros.
        public bool Insertar(Libro libro)
        {
            try
            {
                conexion.Open();
                MySqlCommand comando = new MySqlCommand("INSERT INTO libros (titulo, autor, anyo, disponible) VALUES (@titulo, @autor, @anyo, @disponible)", conexion);
                
                comando.Parameters.AddWithValue("@titulo", libro.Titulo);
                comando.Parameters.AddWithValue("@autor", libro.Autor);
                comando.Parameters.AddWithValue("@anyo", libro.Anyo);
                comando.Parameters.AddWithValue("@disponible", libro.Disponible);
                
                comando.ExecuteNonQuery();
                conexion.Close();

                Console.WriteLine("Libro insertado correctamente.");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al insertar el libro: {ex.Message}");
                return false;
            }
        }

        //Escribe el metodo ObtenerTodos() que lea todos los registros con SELECT * y ExecuteReader(),
        //cree un Libro por fila y los devuelva en una List<Libro>.


        public List<Libro> ObtenerTodos() {
            List<Libro> libros = new List<Libro>();
            try
            {
                conexion.Open();
                String query = "SELECT * FROM libros";
                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.Prepare();
                MySqlDataReader registros = cmd.ExecuteReader();
                while (registros.Read())
                {
                    libros.Add(new Libro(registros["titulo"].ToString(), registros["autor"].ToString(), Convert.ToInt32(registros["anyo"]), Convert.ToBoolean(registros["disponible"])));
                }
                registros.Close();
                conexion.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener los libros: {ex.Message}");
            }
            return libros;
        }
    }
}
