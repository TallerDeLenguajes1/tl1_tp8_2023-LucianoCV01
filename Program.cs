using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

using EspacioTarea;
internal class Program
{
    private static void Main(string[] args)
    {
        //1. Cree aleatoriamente N tareas pendientes.
        Random rand = new();
        int nTareas = rand.Next(1,6);
        List<Tarea> TareasPendientes = new();
        for (int i = 0; i < nTareas; i++)
        {
            Tarea aux = new(i, "Hola "+i, rand.Next(10, 101));
            TareasPendientes.Add(aux);
        }
        Console.WriteLine("Tareas Pendientes");
        mostrarLista(TareasPendientes);

        //2. Desarrolle una interfaz para mover las tareas pendientes a realizadas.
        List<Tarea> TareasRealizadas = new();
        string? respuesta;
        Console.WriteLine("Tareas Pendientes");
        for (int i = 0; i < nTareas; i++)
        {
            Console.Write(TareasPendientes[i].mostrarTareas());
            Console.WriteLine("Tarea realizada?(1=si, 0=no)");
            respuesta = Console.ReadLine();
            if (respuesta == "1")
            {
                TareasRealizadas.Add(TareasPendientes[i]);
            }
        }
        foreach (var tarea in TareasRealizadas)
        {
            TareasPendientes.Remove(tarea);
        }
        Console.WriteLine("Tareas Pendientes");
        mostrarLista(TareasPendientes);
        Console.WriteLine("Tareas Realizadas");
        mostrarLista(TareasRealizadas);

        //3. Desarrolle una interfaz para buscar tareas pendientes por descripción.
        string? descrip;
        Console.WriteLine("Ingrese la descripcion de la tarea: ");
        descrip = Console.ReadLine();
        foreach (var tarea in TareasPendientes)
        {
            if (tarea.Descripcion == descrip)
            {
                Console.WriteLine("Tareas Pendientes");
                Console.Write(tarea.mostrarTareas());
            }
        }
        foreach (var tarea in TareasRealizadas)
        {
            if (tarea.Descripcion == descrip)
            {
                Console.WriteLine("Tareas Realizadas");
                Console.Write(tarea.mostrarTareas());
            }
        }

        //4. Guarde en un archivo de texto un sumario de las horas trabajadas 
        //por el empleado (sumatoria de la duración de las tareas).
        string nombreArchivo = "horasTrabajadas.txt";
        using (StreamWriter archivo = new(nombreArchivo, true))
        {
            int horasTrabajadas = 0;
            foreach (var tarea in TareasRealizadas)
            {
                horasTrabajadas += tarea.Duracion;
            }
            archivo.WriteLine($"Horas trabajadas: {horasTrabajadas}");
        }

    }
    public static void mostrarLista(List<Tarea> lista)
    {
        foreach (var tarea in lista)
        {
            Console.Write(tarea.mostrarTareas());
        }
    }
}