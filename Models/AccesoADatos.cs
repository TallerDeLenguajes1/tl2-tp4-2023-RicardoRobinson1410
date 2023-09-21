using System;
using System.IO;
using System.Collections;
using System.Linq;
using System.Text.Json;
namespace tl2_tp4_2023_RicardoRobinson1410;
    public abstract class AccesoADatos
    {
        public virtual List<Cadete>? LeerArchivoCadetes(string nombreArchivo)
        {
            return null;
        }

        public virtual List<Cadeteria>? LeerArchivoCadeteriaYCargarCadetes(string nombreArchivo, string nombreArchivo2)
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

        public override List<Cadeteria>? LeerArchivoCadeteriaYCargarCadetes(string nombreArchivo, string nombreArchivo2)
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
                    List<Cadete> ListaDeCadetes = this.LeerArchivoCadetes(nombreArchivo2);
                    nuevacadeteria.ListadoCadetes=ListaDeCadetes;
                    ListaCadeterias.Add(nuevacadeteria);
                }
            }
            return ListaCadeterias;
        }

    }
    public class AccesoADatosJSON : AccesoADatos
    {
                public override List<Cadeteria>? LeerArchivoCadeteriaYCargarCadetes(string rutaDeArchivo, string nombreArchivo2){
            List<Cadeteria>? listaProductos;
            string documento;
            var listaCadetes=this.LeerArchivoCadetes(nombreArchivo2);
            using (var archivoOpen = new FileStream(rutaDeArchivo, FileMode.Open))
            {
                using (var strReader = new StreamReader(archivoOpen))
                {
                    documento = strReader.ReadToEnd();
                    archivoOpen.Close();
                }
                listaProductos = JsonSerializer.Deserialize<List<Cadeteria>>(documento);
                if(listaProductos!=null)
                {
                    foreach (var item in listaProductos)
                {
                    item.ListadoCadetes.AddRange(listaCadetes);
                }
                }
                
            }
            return (listaProductos);
        }
        public override List<Cadete>? LeerArchivoCadetes(string rutaDeArchivo){
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
    }