using System;
using System.Collections;

namespace Integrador
{
	class Sistema
    {
		//ArrayLists estaticos para usar en la clase
		static ArrayList excursiones = new ArrayList();
		static ArrayList empleados = new ArrayList();
		static ArrayList clientes = new ArrayList();
		static ArrayList omnibus = new ArrayList();
		static ArrayList dias = new ArrayList {"Lunes", "Martes", "Miercoles", "Jueves", "Viernes", "Sabado", "Domingo"};
		
		//Variables estaticas para usar en la clase
		static int idCliente = 0;
		static int legajo = 0;
		static int excursionID = 0;
		static int omnibusID = 0;
		static int totalVentas = 0; //Usada para contabilizar cada venta/compra que se realiza

		
		//////////////////////////////////////////////////////////////////////////////////////////
		//									MODULO EXCURSION								   //
		
		public static void nuevaExcursion()
        {
			//Inicializo variables de recorrido que me van a servir para almacenar los destinos que hara el viaje
			try
            {									//Inicio un try para toda la funcion	
				string recorridoactual = "";		//Variable que lee el recorrido actual ingresado
				string recorridos = "";				//Variable que concatena cada recorrido
				
				Console.WriteLine("Ingrese nombre de la excursión: ");
				string nombre = Console.ReadLine();
			
				Console.WriteLine("Ingrese nombre de la ciudad del recorrido: (Espacio en blanco para finalizar)");
				do
                {									//DO que pide al usuario que ingrese un recorrido hasta que se ingrese una linea vacia
					recorridoactual = Console.ReadLine();
					recorridos += recorridoactual + "  ";
				}
				while (recorridoactual != "");		//Condicion de salida del DO-WHILE

				Console.WriteLine("Ingrese horario de salida: ");
				string horarioSalida = Console.ReadLine();
			
				Console.WriteLine("Ingrese duración en horas: ");
				int duracion = int.Parse(Console.ReadLine());

				Console.WriteLine("Ingrese día de salida de la excursión (Lunes, Martes, Miercoles, Jueves, Viernes, Sabado, Domingo):\n Presione ENTER para terminar ");			
				
				string diasdesalida = "";			//Variable que almacena el dia de salida ingresado
				string dia = "";					//Variable que concatena cada dia de salida
				do
                {									//DO que pide al usuario que ingrese un dia de salida hasta que se ingrese una linea vacia
					dia = Console.ReadLine();
					
					foreach(string x in dias)
                    {
                        if (dia == x)
                        {                           //Si el dia ingresado esta dentro del ArrayList de dias, concatena "dia" con "diasdesalida"
                            diasdesalida += dia + " ";
                        }
					}
					
				}
				while (dia != "");					
			
				Console.WriteLine("Ingrese número de Omnibus asignado: ");
				int omnibusid = int.Parse(Console.ReadLine());
				
				excursionID++;
			
				Excursion e = new Excursion(nombre,recorridos,horarioSalida,duracion,diasdesalida,omnibusid,excursionID);
				excursiones.Add(e);
				Console.WriteLine("La excursion fue registrada exitosamente!");
				
			}							//Fin Try
			catch (FormatException)
            {		                    //Manejo de excepcion
				Console.WriteLine("ERROR: Hubo un error con los datos ingresados. Ingrese un valor numerico");
			}
		}
		
		public static void listarExcursiones()
        {		                       //funcion que muestra una lista con todas las instancias de Excursion
			if(excursiones.Count == 0)
            {
				Console.WriteLine("No hay excursiones registradas!");
			}

            else
            {
				Console.WriteLine("Lista de excursiones:");
				foreach (Excursion e in excursiones)
                {
					Console.WriteLine(e.mostrarExcursion());
				}
			}
		}
		
		public static void eliminarExcursion()
        {		//funcion que muestra la lista y elimina una excursion
			if (excursiones.Count == 0)
			{
				Console.WriteLine("No hay excursiones registradas!");
			}
            else
            {
				listarExcursiones();
				try
                {		//inicio de try
					Console.WriteLine("Ingrese el nombre de la excursion a borrar:");
					string nombre = Console.ReadLine();
					int valor = Sistema.existeExcursion(nombre);
				
					//Si el nombre ingresado no se encuentra en el arreglo de excursiones				
					if((Sistema.existeExcursion(nombre) == 0))
                    {
                        Console.WriteLine("Excursion inexistente en el sistema!");
                    }

                    else
                    {
						
						excursionID--;
						int id = getExcursion(valor).getExcursionID;				
						excursiones.RemoveAt(valor-1);
						Console.WriteLine("Excursion eliminada satisfactoriamente! Modificando datos....");
						listarExcursiones();
					}
					
				}

                catch (ArgumentOutOfRangeException){  //manejo de excepcion
					Console.WriteLine("ERROR: ha ocurrido un error en los datos ingresados");
				}
			}
		}
		
		public static void nuevoOmnibus()
        {
			try
            {
				Console.WriteLine("Ingrese marca del Omnibus: ");
				string marca = Console.ReadLine();
			
				Console.WriteLine("Ingrese modelo del Omnibus: ");
				string modelo = Console.ReadLine();
			
				Console.WriteLine("Ingrese capacidad del Omnibus:");
				int capacidad = int.Parse(Console.ReadLine());
			
				Console.WriteLine("Ingrese tipo del Omnibus\nOpciones (Basico, Semi-cama, Coche-cama, Suite");
				string tipo = Console.ReadLine();
				
				omnibusID++;
				
				Omnibus o = new Omnibus(marca,modelo,capacidad,tipo,omnibusID);
				omnibus.Add(o);	
				
				Console.WriteLine("Omnibus registrado correctamete!");
			}

            catch
            {
				Console.WriteLine("ERROR: Hubo un error en los datos ingresados, no se pudo realizar la operacion");
			}
		}
		
		public static void listarOmnibus()
        {
			if(omnibus.Count == 0)
            {
				Console.WriteLine("No hay Omnibus registrados");
			}

            else
            {
				Console.WriteLine("Lista de Omnibus registrados: ");		
				foreach (Omnibus o in omnibus)
                {
					Console.WriteLine(o.mostrarOmnibus());
				}
			}
		}
		
		public static void eliminarOmnibus()
        {
			if(omnibus.Count == 0)
            {
				Console.WriteLine("No hay omnibus todavia");
            }

            else
            {
				listarOmnibus();
				try
				{
					Console.WriteLine("Ingrese el numero de unidad a dar de baja:");
					int unidad = int.Parse(Console.ReadLine());	
					
					if ((Sistema.existeOmnibusID(unidad) == false))
                    {
						Console.WriteLine("Cliente inexistente en el sistema!");					
					}

                    else
                    {
						omnibusID--;
						int id = getOmnibus(unidad).getOmnibusID;
						omnibus.RemoveAt(id-1);
						Console.WriteLine("Omninus removido correctamente!");
					}
				}
				catch
                {
					Console.WriteLine("ERROR: Hubo un error en el dato ingresado, ingrese un valor numerico");
				}
			}
		}		
		//////////////////////////////////////////////////////////////////////////////////////////
		//									MODULO EMPLEADO									    //

		public static void nuevoEmpleado()
        {
			int dni;
			Console.WriteLine("Ingrese nombre del empleado:");
			string nombre = Console.ReadLine();
						
			Console.WriteLine("Ingrese apellido del empleado:");
			string apellido = Console.ReadLine();
			try
            {
				Console.WriteLine("Ingrese DNI del cliente:");
				dni = int.Parse(Console.ReadLine());
				if (Sistema.existeCliente(dni) == false)
                {
					legajo++;
					Empleado e = new Empleado(nombre, apellido, dni, legajo);
					empleados.Add(e);
				}

				Console.WriteLine("El empleado fue dado de alta satisfactoriamente! Su numero de legajo es " + legajo);
				Console.ReadKey(true);
			}

            catch
            {
				Console.WriteLine("Ha ocurrido un error con los datos ingresados");
				Console.ReadKey(true);
			}		
		}

		public static void listarEmpleados()
        {
			if (empleados.Count == 0)
            {
				Console.WriteLine("No hay empleados registrados!");
			}

            else
            {
				Console.WriteLine("Listado de empleados: ");
				foreach (Empleado e in empleados)
                {
					Console.WriteLine(e.mostrarEmpleado());
				}
			}
		}
		
		public static void eliminarEmpleado()
        {
			if(empleados.Count == 0)
            {
				Console.WriteLine("No hay empleados registrados!");
			}

            else
            {
				listarEmpleados();
				try
                {
					Console.WriteLine("Ingrese el numero de legajo del empleado a dar de baja: ");
					int opcion = int.Parse(Console.ReadLine());
					legajo--;
					int id = getEmpleado(opcion).getLegajo;
					empleados.RemoveAt(id-1);
					Console.WriteLine("Operacion realizada exitosamente! Actualizando lista...\n\n");
					listarEmpleados();
				}
                catch (FormatException)
                {
					Console.WriteLine("ERROR: Hubo un error en los datos ingresados. Ingrese un valor numerico");
				}

                catch (ArgumentOutOfRangeException)
                {
					Console.WriteLine("ERROR: Hubo un error en los datos ingresados. Valor fuera de rango");
				}
			}
		}
		//////////////////////////////////////////////////////////////////////////////////////////
		//									MODULO CLIENTE									    //
		
		public static void nuevoCliente()
        {
			int dni;
			Console.WriteLine("Ingrese nombre del cliente:");
			string nombre = Console.ReadLine();
						
			Console.WriteLine("Ingrese apellido del cliente:");
			string apellido = Console.ReadLine();

			try
            {
				Console.WriteLine("Ingrese DNI del cliente:");
				dni = int.Parse(Console.ReadLine());
                if (Sistema.existeCliente(dni) == false)
                {
                    idCliente++;
                    clientes.Add(new Cliente(nombre, apellido, dni, idCliente));
                }

			    Console.WriteLine("El cliente fue dado de alta satisfactoriamente! Su numero de cliente es " + idCliente);
			}

            catch
            {
				Console.WriteLine("Ha ocurrido un error con los datos ingresados");
			}			

		}

		public static void comprarPasaje()
        {
			if (clientes.Count == 0)
            {
                if (excursiones.Count == 0)
                {
                    Console.WriteLine("No hay excursiones registradas!");
                }

                else
                {
                    Console.WriteLine("No hay clientes registrados!");
                }
			}

            else
            {
				try
                {
					Console.WriteLine("Ingrese el numero de cliente: ");
					int id = int.Parse(Console.ReadLine());
			
					Console.WriteLine("Ingrese el DNI del cliente: ");
					int dni = int.Parse(Console.ReadLine());
			
					if ((Sistema.existeCliente(dni) == false) || Sistema.existeClienteID(id) == false)
                    {
						Console.WriteLine("Cliente inexistente en el sistema!");
					}

                    else
                    {
                        if (excursiones.Count == 0)
                        {
                            Console.WriteLine("No hay excursiones registradas!");
                        }

                        else
                        {
                            listarExcursiones();
                            Console.WriteLine("Ingrese el numero de la excursion a comprar:");
                            int opcion = int.Parse(Console.ReadLine());
                            Console.WriteLine("Ingrese cantidad de pasajes:");
                            int pasajes = int.Parse(Console.ReadLine());
                            getCliente(id).getCompras++;
                            getExcursion(id).getVentasExcursion++;
                            Console.WriteLine("Venta exitosa!");
                            totalVentas++;
                        }
					}
				}
				catch
                {
					Console.WriteLine("ERROR: Hubo un error en los datos ingresados, no se pudo realizar la operacion");
				}
			}
		}
		
		public static void devolverPasaje()
        {
			if (clientes.Count == 0)
            {
                if (excursiones.Count == 0)
                {
                    Console.WriteLine("No hay excursiones registradas!");
                }

                else
                {
                    Console.WriteLine("No hay clientes registrados!");
                }
			}
            else
            {
				try
                {
					Console.WriteLine("Ingrese el numero de cliente: ");
					int id = int.Parse(Console.ReadLine());
			
					Console.WriteLine("Ingrese el DNI del cliente: ");
					int dni = int.Parse(Console.ReadLine());

                    if ((Sistema.existeCliente(dni) == false) || Sistema.existeClienteID(id) == false)
                    {
                        Console.WriteLine("Cliente inexistente en el sistema!");
                    }

                    else
                    {
                        if (excursiones.Count == 0)
                        {
                            Console.WriteLine("No hay excursiones registradas!");
                        }

                        else
                        {
							listarExcursiones();
							Console.WriteLine("Ingrese el numero de la excursion a devolver:");
							int opcion = int.Parse(Console.ReadLine());
							
							string salida = getExcursion(opcion).getDiaSalida;
							int porcentaje = 0;
							int total = 100;
							
							if (salida == "Sabado " || salida == "Viernes " || salida == "Jueves " || salida == "Miercoles ")
                            {
								porcentaje = 10;
								total -= porcentaje;
								Console.WriteLine("Se le devolvera el %" + total + " del valor abonado.");
							}

							if (salida == "Domingo ")
                            {
								porcentaje = 50;
								total -= porcentaje;
								Console.WriteLine("Se le devolvera el %" + total + " del valor abonado.");
							}

							Console.WriteLine("Transaccion exitosa!");
							getCliente(id).getCompras--;
							getExcursion(id).getVentasExcursion--;
							totalVentas--;
						}
					}
				}

                catch
                {
					Console.WriteLine("ERROR: Hubo un error en los datos ingresados, no se pudo realizar la operacion");
				}
			}
		}
		//////////////////////////////////////////////////////////////////////////////////////////
		//									MODULO ESTADISTICAS								    //		
		
		public static string cantidadVentas()
        {			                                   
			return "Cantidad de ventas de excursiones: " + totalVentas + "\n";
		}
		
		public static void comprasClientes()
        {	
			Console.WriteLine("Listado de clientes y compras:\n");
			foreach (Cliente c in clientes)
            {
				Console.WriteLine(c.getNombre + " " + c.getApellido + " (" + c.getCompras + ")");
			}
		}
		
		public static void ventasExcursiones()
        {
			Console.WriteLine("Listado de excursiones mas vendidas:\n");
			foreach (Excursion e in excursiones)
            {
				Console.WriteLine(e.getExcursionNombre + " " + "(" + e.getVentasExcursion + ")");
			}
		}
		
		public static void ventasEmpleados()
        {			                    
			Console.WriteLine("Listado de empleados y ventas:\n");
			foreach (Cliente c in clientes)
            {
				Console.WriteLine(c.getNombre + " " + c.getApellido + " (" + c.getCompras + ")");
			}
		}

		/////////////////////////////////////////////////////////////////////////////////////
		//Funciones de comprobacion
		
		public static bool existeEmpleado(int dni)	//funcion que devuelve true si en el ArrayList empleados existe un empleado que coincida con el dni del parametro
		{
			foreach(Empleado e in empleados)
            {
				if (e.getDNI == dni)
                {
					return true;
				}
			}
			return false;
		}
		
		public static bool existeOmnibusID(int id) //funcion que devuelve truesi en el ArrayList omnibus existe un omnibus con el mismo id del parametro
		{
			foreach (Omnibus o in omnibus)
            {
				if (o.getOmnibusID == id)
                {
					return true;
				}
			}
			return false;
		}
		
		public static bool existeCliente(int dni)
        {                                        //Funcion que devuelve true si en el ArrayList clientes existe un cliente que coincida con el dni del parametro
			foreach (Cliente a in clientes)
            {
				if (a.getDNI == dni)
                {
					return true;
				}
			}
			return false;
		}
		
		
		public static bool existeClienteID(int id)
        {                                        //Funcion que devuelve true si en el ArrayList clientes existe un cliente que coincida con el clienteID del parametro
			foreach (Cliente c in clientes)
            {
				if (c.getClienteID == id)
                {
					return true;
				}
			}
			return false;
		}
		
		public static int existeExcursion(string nombre)
        {                                        //Funcion que devuelve el valor del ID de excursion si en el ArrayList excursiones existe una excursion que se llame igual que el parametro
			foreach (Excursion e in excursiones)
            {
				if (e.getExcursionNombre == nombre)
                {
					int valor = e.getExcursionID;
					return valor;
				}
			}
			return 0;
		}
		
		public static Cliente getCliente(int opcion)//funcion que devuelve "Cliente" desde el arraylist de clientes
        {
                return (Cliente)clientes[opcion-1];
		}
		
		public static Excursion getExcursion(int opcion) //funcion que devuelve "Excursion" desde el arraylist de excursiones
		{
			return (Excursion)excursiones[opcion-1];
		}	
		
		public static Omnibus getOmnibus(int opcion)
		{
			return (Omnibus)omnibus[opcion-1];
		}
		public static Empleado getEmpleado(int opcion)
		{
			return (Empleado)empleados[opcion-1];
		}
	}
}






