namespace tl2_tp4_2023_RicardoRobinson1410;
using System.IO;
using System.Text.Json;
public class AccesoDatosPedidos
{
    public List<Pedido> Obtener()
    {
        var cargarPedidos=new AccesoADatosJSON();
        var listaPedidos=cargarPedidos.LeerPedidos("Pedidos.json");
        return(listaPedidos);
    }

    public void Guardar(string nombreArchivo, List<Pedido> listaPedidos)
    {
        string datos = JsonSerializer.Serialize<List<Pedido>>(listaPedidos);
            using (var archivo = new FileStream(nombreArchivo, FileMode.Create))
            {
                using (var strWriter = new StreamWriter(archivo))
                {
                    strWriter.WriteLine("{0}", datos);
                    strWriter.Close();
                }
            }
    }
}