using System;
using System.IO;
using System.Collections;
namespace tl2_tp4_2023_RicardoRobinson1410;
    public class Cliente
    {
        private string nombre;
        private string direccion;
        private string telefono;
        private string datosReferenciaDireccion;

        public string Nombre { get => nombre; set => nombre = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string DatosReferenciaDireccion { get => datosReferenciaDireccion; set => datosReferenciaDireccion = value; }

        public Cliente(string name, string adress, string phone, string adressReferences){
            this.nombre=name;
            this.direccion=adress;
            this.telefono=phone;
            this.datosReferenciaDireccion=adressReferences;
        }

        public Cliente()
        {
            this.nombre="";
            this.direccion="";
            this.telefono="";
            this.datosReferenciaDireccion="";
        }
        public string Mostrar()
        {
            var cadena=(@$"Nombre: {this.nombre}
            Direccion: {this.direccion}
            telefono: {this.telefono}
            datosReferenciaDireccion: {this.datosReferenciaDireccion}");
            return(cadena);
        }
    }