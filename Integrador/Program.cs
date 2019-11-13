using System;

namespace Integrador
{
	class Program
    {
		public static void Main(string[] args)
        {
			int opcion = 0;
			
			//Bucle DO-WHILE del menu principal
			do
            {
				Console.Clear();
				Console.WriteLine("*******************************************************************************");
				Console.WriteLine("*****                      SISTEMA DE EXCURSIONES                        ******");
				Console.WriteLine("*******************************************************************************");
				Console.WriteLine("\nSeleccione una opción del menu:\n\n");
				Console.WriteLine("1) Armado de Excursiones\n2) Gestión de Empleados\n3) Venta de Excursiones\n4) Estadisticas\n5) Salir del Programa");
			
				try
                {
					opcion = int.Parse(Console.ReadLine());	
				} //fin try

                catch (FormatException)
                {
                    Console.WriteLine("ERROR: Ingrese una opción numérica entre (1-5)\nPresione una tecla para continuar...");
                    Console.ReadKey(true);
                    continue;
                } 

                catch
                {
                    Console.WriteLine("ERROR: Ingrese una opción numérica entre (1-5)\nPresione una tecla para continuar...");
                    Console.ReadKey(true);
                }	//fin catch	
                
				switch (opcion)
                {
					case 1:
						Excursiones();
						break;
					case 2:
						Empleados();
						break;
					case 3:
						Ventas();
						break;
					case 4:
						Estadisticas();
						break;						
					case 6:
						Salir();
						break;
				}
			}
			while(opcion != 5);
		} //fin Main()
		
		public static void Salir()
        {
			Console.WriteLine("Saliendo del programa...");
		}
		
		public static void Excursiones()
        {
			int opcion = 0;

			do
            {
				Console.Clear();
                Console.WriteLine("*******************************************************************************");
                Console.WriteLine("******                    SUBMODULO DE EXCURSIONES                       ******");
                Console.WriteLine("*******************************************************************************");
                Console.WriteLine("\nSeleccione una opción del menu:\n\n");
                Console.WriteLine("1) Alta de Excursión\n2) Baja de Excursión\n3) Alta de Omnibus\n4) Baja de Omnibus\n5) Listado de Excursiones Disponibles\n6) Volver\n");
			
				try
                {
					opcion = int.Parse(Console.ReadLine());	
				}

                catch (FormatException)
                {
                    Console.WriteLine("ERROR: Ingrese una opción numérica entre (1-5)\nPresione una tecla para continuar...");
                    Console.ReadKey(true);
                    continue;
                }

				switch (opcion)
                {
					case 1: 
						Sistema.nuevaExcursion();
						Console.ReadKey(true);
						break;
					case 2: 
						Sistema.eliminarExcursion();
						Console.ReadKey(true);
						break;
					case 3:
						Sistema.nuevoOmnibus();
						Console.ReadKey(true);						
						break;
					case 4:
						Sistema.eliminarOmnibus();
						Console.ReadKey(true);
						break;
					case 5:
						Sistema.listarExcursiones();
						Console.ReadKey(true);						
						break;
					case 6:
						Volver();
						break;						
				}
			}
			while(opcion != 6);
		} //fin Excursiones()
		
		public static void Volver()
        {
			Console.WriteLine("Regresando al menu anterior...");
		} // fin Volver()
		
		public static void Empleados()
        {
			int opcion = 0;

			do
            {
				Console.Clear();
                Console.WriteLine("*******************************************************************************");
                Console.WriteLine("******                    MODULO GESTIÓN DE EMPLEADOS                    ******");
                Console.WriteLine("*******************************************************************************");
                Console.WriteLine("\nSeleccione una opción del menu:\n\n");
				Console.WriteLine("1) Alta de Empleado\n2) Baja de Empleado\n3) Listado de Empleados\n4) Volver\n");
			
				try
                {
					opcion = int.Parse(Console.ReadLine());	
				}

                catch (FormatException)
                {
                    Console.WriteLine("ERROR: Ingrese una opción numérica entre (1-4)\nPresione una tecla para continuar...");
                    Console.ReadKey(true);
                    continue;
                }

				switch (opcion)
                {
					case 1:
						Sistema.nuevoEmpleado();
						Console.ReadKey(true);
						break;
					case 2:
						Sistema.eliminarEmpleado();
						Console.ReadKey(true);
						break;
					case 3:
						Sistema.listarEmpleados();
						Console.ReadKey(true);
						break;
					case 4:
						Volver();
						break;
				}
			}
			while(opcion != 4);
		} //fin Empleados()
		
		public static void Ventas()
        {
			int opcion = 0;

			do
            {
				Console.Clear();
                Console.WriteLine("*******************************************************************************");
                Console.WriteLine("******                    MODULO VENTA DE EXCURSIONES                    ******");
                Console.WriteLine("*******************************************************************************");
				Console.WriteLine("\nSeleccione una opción del menu:\n\n1) Alta de Cliente\n2) Compra de Pasajes para una Excursion\n3) Devolucion de Pasajes\n4) Volver\n");
	
				try
                {
					opcion = int.Parse(Console.ReadLine());	
				}

                catch (FormatException)
                {
                    Console.WriteLine("ERROR: Ingrese una opción numérica entre (1-4)\nPresione una tecla para continuar...");
                    Console.ReadKey(true);
                    continue;
                }

				switch (opcion)
                {
					case 1:
						Sistema.nuevoCliente();
						Console.ReadKey(true);
						break;
					case 2:
						Sistema.comprarPasaje();
						Console.ReadKey(true);
						break;
					case 3:
						Sistema.devolverPasaje();
						Console.ReadKey(true);
						break;					
					case 4:
						Volver();
						break;
				}
			}
			while(opcion != 4);
		} //fin Ventas()
		
		public static void Estadisticas()
        {
			int opcion = 0;

			do
            {
				Console.Clear();
                Console.WriteLine("*******************************************************************************");
                Console.WriteLine("******                    MODULO ESTADISTICAS                            ******");
                Console.WriteLine("*******************************************************************************");
                Console.WriteLine("\nSeleccione una opción:\n\n");
				Console.WriteLine ("1) Consultar la cantidad de excursiones vendidas\n2) Consultar los clientes que mas viajan\n3) Consultar la excursion mas solicitada\n4) " +
				                  "Consultar el operador que mas excursiones vende\n5) Volver\n");
			
				try
                {
                    opcion = int.Parse(Console.ReadLine());
                }

                catch (FormatException)
                {
                    Console.WriteLine("ERROR: Ingrese una opción numérica entre (1-5)\nPresione una tecla para continuar...");
                    Console.ReadKey(true);
                    continue;
                }

				switch (opcion)
                {
					case 1:
                		Console.WriteLine(Sistema.cantidadVentas());
                		Console.WriteLine("Presione una tecla para continuar");
                		Console.ReadKey(true);
						break;
					case 2:
						Sistema.comprasClientes();
                		Console.WriteLine("Presione una tecla para continuar");
                		Console.ReadKey(true);
						break;
					case 3:
						Sistema.ventasExcursiones();
						Console.WriteLine("Presione una tecla para continuar");
                		Console.ReadKey(true);
						break;
					case 4:
						Sistema.ventasEmpleados();
                		Console.WriteLine("Presione una tecla para continuar");
                		Console.ReadKey(true);
						break;						
					case 5:
						Volver();
						break;
				}
			}
			while(opcion != 5);
		}	//fin Estadisticas()	
	}
}