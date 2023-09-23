namespace tl2_tp4_2023_RicardoRobinson1410;

public class AccesoDatosCadetes
{
    public List<Cadete> Obtener()
    {
        var leerCadetes=new AccesoADatosJSON();
        var cadetes=leerCadetes.LeerArchivoCadetes(@"C:\Users\USUARIO\tl2-tp4-2023-RicardoRobinson1410\Models\Cadetes .json");
        return(cadetes);
    }
}