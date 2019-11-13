using System;

namespace Integrador
{
	class Empleado: Persona
    {
		//Variables
		protected int legajo;
		protected int ventas;
		
		//Constructor
		public Empleado(string nombre, string apellido, int dni, int legajo)
        {
			this.nombre = nombre;
			this.apellido = apellido;
			this.dni = dni;
			this.legajo = legajo;
			this.ventas = 0;
		}
		
		//Propiedad GET
		public int getLegajo
        {
			get{return this.legajo;}
		}
		
		public int getVentas
        {
			set{this.ventas = value;}
			get{return this.ventas;}
		}

		//Metodo
		public string mostrarEmpleado()
        {
			return nombre + " " + apellido + "- DNI: " + dni + "- Legajo: " + legajo;
		}
	}
}
