using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

using EspacioTarea;
internal class Program
{
    private static void Main(string[] args)
    {
        string? path = @"/System/Volumes/Data/Users/lucianocosentino/Desktop/Programación/2º Año/1º Cuatrimestre/Taller de Lenguajes I/Semana 7 - 8";
        // do
        // {
        //     Console.Write("Ingrese el path de una carpeta: ");
        //     path = Console.ReadLine();
        // } while (path == null);


        if (Directory.Exists(path))
        {
            List<string> ListadoDeArchivos = Directory.GetFiles(path).ToList();
            foreach (var archivo in ListadoDeArchivos)
            {
                Console.WriteLine(archivo);
            }

            using (StreamWriter index = new("index.csv"))
            {
                for (int i = 0; i < ListadoDeArchivos.Count; i++)
                {
                    var separarBarra = ListadoDeArchivos[i].Split(@"/");
                    var separarNombre = separarBarra[separarBarra.Length - 1].Split(".");
                    index.WriteLine(i + ";" + separarNombre[0] + ";" + separarNombre[1]);

                    // var nombreArchivo = Path.GetFileName(ListadoDeArchivos[i]);
                    // var extensionArchivo = Path.GetExtension(ListadoDeArchivos[i]);
                    // index.WriteLine($"{i+1};{nombreArchivo};{extensionArchivo}");
                }
            }
        }
        else
        {
            Console.WriteLine("La carpeta ingresada no existe.");
        }
    }
}