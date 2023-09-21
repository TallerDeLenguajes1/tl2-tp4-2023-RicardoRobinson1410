using System;
using System.IO;
using System.Collections;
using System.Linq;

namespace tl2_tp4_2023_RicardoRobinson1410;
    public enum EstadoPedidos{
        aceptado=1,
        pendiente=2,
        rechazado=3
    }
    public class Pedido
    {
        private int nro;
        private string nombre;
        private Cliente nombreCliente;
        private EstadoPedidos estado;
        private Cadete? cadeteAsignado;

        public int Nro { get => nro; set => nro = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public Cliente NombreCliente { get => nombreCliente; set => nombreCliente = value; }
        public EstadoPedidos Estado { get => estado; set => estado = value; }
        public Cadete? CadeteAsignado { get => cadeteAsignado; set => cadeteAsignado = value; }

        public Pedido(int nro, string nombre, Cliente cliente)
        {
            this.nro=nro;
            this.nombre=nombre;
            this.nombreCliente=cliente;
            this.estado=EstadoPedidos.pendiente;
            this.CadeteAsignado=null;
        }

        public Pedido()
        {
            this.nro=0;
            this.nombre="";
            this.nombreCliente=new Cliente();
            this.estado=EstadoPedidos.pendiente;
            this.cadeteAsignado=null;
        }

        public string Mostrar()
        {
           var cadena=(@$"nro: {this.nro}
            Nombre: {this.nombre}
            ---------------Datos del cliente----------------
            Direccion: {this.nombreCliente.Direccion}
            Telefono: {this.nombreCliente.Telefono}
            Estado: {this.estado}
                    DATOS CADETE");
            cadena+=this.cadeteAsignado.Mostrar();
           return(cadena);
        }

        public void AsignarCadeteAPedido(Cadete cadete)
        {
            this.CadeteAsignado=cadete;
        }

        public void AceptarPedido()
        {
            if(this.estado==EstadoPedidos.pendiente)
            {
                this.estado=EstadoPedidos.aceptado;
            }
            
        }

        public void RechazarPedido()
        {
            if(this.estado==EstadoPedidos.pendiente)
            {
                this.estado=EstadoPedidos.rechazado;
                this.cadeteAsignado=null;
            }
    
        }
    }
