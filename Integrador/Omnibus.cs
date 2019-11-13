using System;
using System.Collections;

namespace Integrador
{	
	public class Omnibus
	{
		//Variables
		private string marca, modelo, tipo;
		private int capacidad;
		private int id;
		
		//Constructor
		public Omnibus(string marca, string modelo, int capacidad, string tipo, int id)
        {	
			this.marca = marca;
			this.modelo = modelo;
			this.capacidad = capacidad;
			this.tipo = tipo;
			this.id = id;
		}
		//Variable privada GET
		
		public int getOmnibusID
        {
			get{return this.id;}
		}
			
		//Metodo
		public string mostrarOmnibus()
        {
			return "Numero de unidad: " + getOmnibusID + "- Marca: " + marca + "- Modelo: " + modelo + "- Capacidad: " + capacidad + "- Tipo: " + tipo;
        }
	}
}
