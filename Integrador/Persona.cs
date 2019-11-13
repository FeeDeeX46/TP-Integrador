using System;

namespace Integrador
{
	class Persona
    {
		//Variables
		protected string nombre;
		protected string apellido;
		protected int dni;
		
		//Variables privadas GET para acceder a valores desde otras clases
		public string getNombre
        {
			get{return this.nombre;}
		}

		public string getApellido
        {
			get{return this.apellido;}
		}
		
		public int getDNI
        {
			get{return this.dni;}
		}

		//Metodo
		public string mostrarPersona()
        {
			return nombre + " " + apellido + "DNI: " + dni;
		}
	}
}
