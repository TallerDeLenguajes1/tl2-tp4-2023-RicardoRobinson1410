using System;
using System.IO;
using System.Collections;
using System.Linq;
using System.Runtime.CompilerServices;

namespace tl2_tp4_2023_RicardoRobinson1410;
    public class Informe
    {
        private double montoGanado;
        private double montoPromXCad;
        private int totalEnvios;

    public double MontoGanado { get => montoGanado; set => montoGanado = value; }
    public double MontoPromXCad { get => montoPromXCad; set => montoPromXCad = value; }
    public int TotalEnvios { get => totalEnvios; set => totalEnvios = value; }

    private string mostrarMontoGanadoYEnviosPorCadete(List<Cadete> listadoCadetes)
        {
            string cadena="";
            foreach (var item in listadoCadetes)
            {
                cadena+=@$"CADETE {item.Nombre}:";

            }
            return(cadena);
        }

        private void calcularMontoGanadoYTotalEnvios(List<Pedido> listadoPedidos)
        {

            int envios=0;
            foreach (var item in listadoPedidos)
            {
                if(item.Estado==EstadoPedidos.aceptado)
                {
                    envios++;
                }
            }
            this.MontoGanado=(double)envios*500;
            this.TotalEnvios=envios;
        }

        private void calcularMontoPromXCadete(List<Cadete> listadoCadetes)
        {
            this.MontoPromXCad=this.MontoGanado/listadoCadetes.Count();
        }

        

        public Informe(List<Pedido> listadoPedidos, List<Cadete> listadoCadetes)
        {
            calcularMontoGanadoYTotalEnvios(listadoPedidos);
            calcularMontoPromXCadete(listadoCadetes);
            
        }

        public string MostrarInforme()
        {
            var cadena=(@$"           INFORME
            CANT ENVIOS: {this.TotalEnvios}
            MONTO GANADO: {this.MontoGanado}
            CANTIDAD PROMEDIO GANADA POR CADETE: {this.MontoPromXCad}
            ====================================================");
            return(cadena);
        }
    }