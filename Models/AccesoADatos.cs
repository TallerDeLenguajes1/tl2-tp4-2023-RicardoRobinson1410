using System;
using System.IO;
using System.Collections;
using System.Linq;
using System.Text.Json;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
namespace tl2_tp4_2023_RicardoRobinson1410;
public abstract class AccesoADatos
{
    public virtual List<Cadete>? LeerArchivoCadetes(string nombreArchivo)
    {
        return null;
    }

    public virtual Cadeteria? LeerCadeteria(string nombreArchivo)
    {
        return null;
    }
}

public class AccesoADatosCSV : AccesoADatos
{
    private List<string[]>? LeerCsv(string nombreArchivo)
    {
        var LecturaDelArchivo = new List<string[]>();
        if (File.Exists(nombreArchivo))
        {
            var archivo = new FileStream(nombreArchivo, FileMode.Open);
            var strReader = new StreamReader(archivo);
            var linea = "";
            while ((linea = strReader.ReadLine()) != null)
            {
                string[] arregloLinea = linea.Split(',');
                LecturaDelArchivo.Add(arregloLinea);
            }
            strReader.Close();
        }
        else
        {
            return null;
        }
        return LecturaDelArchivo;
    }

    public override List<Cadete>? LeerArchivoCadetes(string nombreArchivo)
    {
        var listaCsv = this.LeerCsv(nombreArchivo);
        var nuevaLista = new List<Cadete>();
        if (listaCsv != null && listaCsv.Any())
        {
            int id = 0;
            foreach (var cadete in listaCsv)
            {
                if (cadete == null)
                    break;
                var nuevoCadete = new Cadete(id, cadete[0], cadete[1], cadete[2]);
                nuevaLista.Add(nuevoCadete);
                id += 1;
            }
        }
        return nuevaLista;
    }

    public override Cadeteria? LeerCadeteria(string nombreArchivo)
    {
        var ListaCadeterias = new List<Cadeteria>();
        var datos = HelperDeArchivo.LeerCsv(nombreArchivo);
        if (datos != null && datos.Any())
        {
            foreach (var Cadeteria in datos)
            {
                if (Cadeteria == null)
                {
                    break;
                }
                var nuevacadeteria = new Cadeteria(Cadeteria[0], Cadeteria[1]);
                ListaCadeterias.Add(nuevacadeteria);
            }
            var random = new Random();
            var cad = ListaCadeterias[random.Next(0, ListaCadeterias.Count())]; ;
            return cad;
        }
        return null;
    }
}
    public class AccesoADatosJSON : AccesoADatos
    {
        public override Cadeteria? LeerCadeteria(string rutaDeArchivo)
        {
            List<Cadeteria>? listaCadeterias;
            string documento;
            using (var archivoOpen = new FileStream(rutaDeArchivo, FileMode.Open))
            {
                using (var strReader = new StreamReader(archivoOpen))
                {
                    documento = strReader.ReadToEnd();
                    archivoOpen.Close();
                }
                listaCadeterias = JsonSerializer.Deserialize<List<Cadeteria>>(documento);

                if (listaCadeterias != null)
                {
                    var random = new Random();
                    var cadeteria = listaCadeterias[random.Next(0, listaCadeterias.Count)];
                    return (cadeteria);
                }


            }
            return (null);
        }

        public override List<Cadete>? LeerArchivoCadetes(string rutaDeArchivo)
        {
            List<Cadete>? listaProductos;
            string documento;
            using (var archivoOpen = new FileStream(rutaDeArchivo, FileMode.Open))
            {
                using (var strReader = new StreamReader(archivoOpen))
                {
                    documento = strReader.ReadToEnd();
                    archivoOpen.Close();
                }
                listaProductos = JsonSerializer.Deserialize<List<Cadete>>(documento);
            }
            return (listaProductos);
        }

        public List<Pedido> LeerPedidos(string rutaArchivo)
        {
            List<Pedido> listaPedidos;
            string documento;
            using (var archivoOpen = new FileStream(rutaArchivo, FileMode.Open))
            {
                using (var strReader = new StreamReader(archivoOpen))
                {
                    documento = strReader.ReadToEnd();
                    archivoOpen.Close();
                }
                listaPedidos = JsonSerializer.Deserialize<List<Pedido>>(documento);
            }
            return (listaPedidos);
        }
    }