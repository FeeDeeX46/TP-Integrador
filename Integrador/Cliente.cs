using System;

namespace Integrador
{	
	class Cliente : Persona
    {
		//Variables
		protected int id;
		protected int compras;
		
		//Constructor
		public Cliente(string nombre, string apellido, int dni, int id)
        {
			this.nombre = nombre;
			this.apellido = apellido;
			this.dni = dni;
			this.id = id;
			this.compras = 0;
		}
		
		//Propiedades GET para acceder a valores desde otras clases
		public int getClienteID
        {
			get{return this.id;}		
		}	
		
		public int getCompras
        {
			set{this.compras = value;}
			get{return this.compras;}
		}
	}
}
