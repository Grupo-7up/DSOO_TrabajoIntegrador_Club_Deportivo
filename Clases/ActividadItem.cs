public class ActividadItem
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public decimal Costo { get; set; }

    public ActividadItem(int id, string nombre, decimal costo)
    {
        Id = id;
        Nombre = nombre;
        Costo = costo;
    }
}