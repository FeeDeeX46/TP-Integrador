using System;
using System.Collections;

namespace Integrador
{	
	public class Excursion
    {
		//Variables
		protected string nombre, recorrido, horarioSalida,diaSalida;
		protected int duracion, omnibusID, excursionID, ventaExcursion;
		
		//Constructor
		public Excursion(string nombre, string recorrido, string horarioSalida, int duracion, string diaSalida, int omnibusID,int excursionID)
        {
			this.nombre = nombre;
			this.recorrido = recorrido;
			this.horarioSalida = horarioSalida;
			this.duracion = duracion;
			this.diaSalida = diaSalida;
			this.omnibusID = omnibusID;
			this.excursionID = excursionID;		
			this.ventaExcursion = 0;
		}
		
		//Variables privadas GET para acceder a valores desde otras clases
		public string getExcursionNombre
        {
			get{return this.nombre;}
		}
		
		public int getExcursionID
        {
			get{return this.excursionID;}
		}
		
		public string getDiaSalida
        {
			get{return this.diaSalida;}
		}
		
		public int getVentasExcursion
        {
			set{this.ventaExcursion = value;}
			get{return this.ventaExcursion;}
		}
		
		//Metodo
		public string mostrarExcursion()
        {
			return "\nID: " + excursionID + "\nExcursion: " + nombre + "\nRecorrido: " + recorrido + "\nHorario de salida: " + horarioSalida + "\nDuracion: " + duracion + "\nDía de salida: " + diaSalida + "\nNumero de Omnibus: "+ omnibusID + "\n";
        }
	}
}
