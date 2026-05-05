using examen_bibliotech;
using System;
using System.IO;

static bool guardarLibros(List<Libro> lista, String ruta)
{
    try
    {
        StreamWriter salida = File.CreateText(ruta);
        {
            foreach (Libro libro in lista)
            {
                salida.WriteLine($"{libro.Titulo};{libro.Autor};{libro.Anyo};{libro.Disponible}");
            }
        }
        Console.WriteLine("Libros guardados correctamente.");
        salida.Close();
        return true;
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error al guardar los libros: {ex.Message}");
        return false;
    }
}
static void Main(string[] args)
{
    //crear una nueva lista de libros e insertar tres libros en la lista
    List<Libro> libros = new List<Libro>();
    libros.Add(new Libro("El Quijote", "Miguel de Cervantes", 1605, false));
    libros.Add(new Libro("Cien años de soledad", "Gabriel García Márquez", 1967, true));
    libros.Add(new Libro("1984", "George Orwell", 1949, true));

    //mostrar por consola los libros
    foreach (Libro libro in libros)
    {
        Console.WriteLine(libro.ToString());
    }

    //Recorre la lista y muestra solo los libros cuyo autor contenga el texto "Orwell"
    foreach (Libro libro in libros)
    {
        if (libro.Autor.Contains("Orwell"))
        {
            Console.WriteLine(libro.ToString());
        }
    }

    //Muestra por consola la fecha actual en formato corto. Usa DateTime.Now y ToShortDateString().
    string fecha = DateTime.Now.ToShortDateString();
    Console.WriteLine($"Fecha actual: {fecha}");

    //guardar los libros en un fichero
    guardarLibros(libros, "C:\\Users\\Usuario\\Desktop\\libros.txt");
}

Main(args);