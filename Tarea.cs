namespace EspacioTarea;

public class Tarea
{
    int tareaID; 
    string? descripcion; 
    int duracion; 

    public Tarea(int tareaID, string? descripcion, int duracion)
    {
        this.tareaID = tareaID;
        this.descripcion = descripcion;
        this.duracion = duracion;
    }

    public int TareaID { get => tareaID; set => tareaID = value; }
    public string? Descripcion { get => descripcion; set => descripcion = value; }
    public int Duracion { get => duracion; set => duracion = value; }

    public string mostrarTarea(){
        return ($" TareaID: {TareaID}\n Descripcion: {Descripcion}\n Duracion: {Duracion}\n");
    }
}