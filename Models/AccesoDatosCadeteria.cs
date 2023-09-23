using tl2_tp4_2023_RicardoRobinson1410;
public class AccoesoDatosCadeteria
{
    public Cadeteria? Obtener()
    {
        var leer=new AccesoADatosJSON();
        var cadeteria=leer.LeerCadeteria(@"C:\Users\USUARIO\tl2-tp4-2023-RicardoRobinson1410\Models\Cadeterias.json");
        return(cadeteria);
    }
}