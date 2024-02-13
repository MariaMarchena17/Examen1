// See https://aka.ms/new-console-template for more information

using System;

class Program

{
    //Definición de vectores
    static int[] factura = new int[15];
    static int[] placa = new int[15];
    static DateTime[] fecha = new DateTime[15];
    static string[] hora = new string[15];
    static int[] tipocarro = new int[15];
    static int[] caseta = new int[15];
    static int[] montopeaje = new int[15];
    static int[] paga = new int[15];
    static int[] vuelto = new int[15];
    static int i = 0;

    static void Main()
    {
        int opt = 0, cont = 0;

        while (cont != 4)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\t===MENÚ PRINCIPAL===");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("1. Inicializar Vectores");
            Console.WriteLine("2. Ingresar Paso Vehicular");
            Console.WriteLine("3. Consulta de vehículos por no.de placa");
            Console.WriteLine("4. Modificar Datos Vehículos por no. de placa");
            Console.WriteLine("5. Reporte Todos los Datos de los vectores");
            Console.WriteLine("6. Salir");
            Console.WriteLine("\n Digite la opción deseada: ");


            if (int.TryParse(Console.ReadLine(), out opt))
            {
                switch (opt)
                {
                    case 1:
                        InicializarVectores();
                        break;

                    case 2:
                        IngresoPaso();
                        break;

                    case 3:
                        ConsultarPlaca(); 
                        break;

                    case 4:
                        Modificar();
                        break;

                    case 5:
                        Reporte();
                        break;

                    case 6:
                        Console.WriteLine("Saliendo del programa...");
                        return;

                    default:
                        Console.WriteLine("Opción inválida");
                        break;

                }
            }
            else
            {
                Console.WriteLine("Digite una opción válida. Debe ser del 1 al 7");
                Console.ReadKey();
                cont++;
            }
        }
    }

    static void InicializarVectores()
    {
        for (int i = 0; i < 10; i++)
        {
            factura[i] = 0;
            placa[i] = 0;
            fecha[i] = DateTime.MinValue;
            hora[i] = "";
            tipocarro[i] = 0;
            caseta[i] = 0;
            montopeaje[i] = 0;
            paga[i] = 0;
            vuelto[i] = 0;
        }

        Console.WriteLine("\nVectores inicializados correctamente. Presione cualquier tecla para continuar.");
        Console.Clear(); 
    }
    static void IngresoPaso()
    {
        int vhcl = 0;

        if (i < 15)
        {
            Console.Clear();
            Console.WriteLine("Ingrese el número de factura: ");
            factura[i] = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el número de placa: ");
            placa[i] = int.Parse(Console.ReadLine());

            fecha[i] = ObtenerFecha("Ingrese la fecha(YYY - MM - DD): ");

            Console.WriteLine("Ingrese la hora (hh:mm):  ");
            hora[i] = Console.ReadLine();

            Console.WriteLine("Ingrese el tipo de vehículo: ");
            Console.WriteLine("[1= Moto - 2= Vehículo Liviano - 3= Camión o Pesado - 4= Autobús]");
            tipocarro[i] = int.Parse(Console.ReadLine());

            if (tipocarro[i] == 1)
            {
                montopeaje[i] = 500;
            }
            else
            {
                if (tipocarro[i] == 2)
                {
                    montopeaje[i] = 700;
                }
                else
                {
                    if (tipocarro[i] == 3)
                    {
                        montopeaje[i] = 2700;
                    }
                    else if (tipocarro[i] == 4)
                    {
                        montopeaje[i] = 3700;
                    }
                }
            }

            Console.WriteLine("Ingrese el número de caseta (1-3): ");
            caseta[i] = int.Parse(Console.ReadLine());

            Console.WriteLine("Paga con: ");
            int x = int.Parse(Console.ReadLine());

            while (x < montopeaje[i])
            {
                Console.WriteLine("\nIngrese un pago correcto ");
                x = int.Parse(Console.ReadLine());
            }
            paga[i] = x;

            vuelto[i] = paga[i] - montopeaje[i];

            ImprimirPago(i);
            Console.ReadKey(); Console.Clear();

        }
    } //Ingresa la información del paso vehicular

    static DateTime ObtenerFecha(string mensaje) //Valida que la fecha esté en el formato correcto
    {
        DateTime fecha;
        do
        {
            Console.Write(mensaje);
            if (!DateTime.TryParse(Console.ReadLine(), out fecha))
            {
                Console.WriteLine("Fecha inválida. Por favor, ingrese una fecha en formato YYYY-MM-DD.");
            }
            else
            {
                break;
            }
        } while (true);

        return fecha;
    }
    static void ImprimirPago(int x)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\n ===Datos del Paso de Peaje===");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine($"Número de placa: {placa[i]}");
        Console.WriteLine($"Fecha: {fecha[i]:yyyy-MM-dd}");
        Console.WriteLine($"Hora: {hora[i]}");
        Console.WriteLine($"Tipo de vehículo: {tipocarro[i]}");
        Console.WriteLine($"Número caseta: {caseta[i]}");
        Console.WriteLine($"Monto a pagar: {montopeaje[i]}");
        Console.WriteLine($"Pagó con: {paga[i]}");
        Console.WriteLine($"Vuelto: {vuelto[i]}");

        Console.WriteLine("Presione cualquier tecla para continuar");
        Console.ReadKey();

    } //Imprime la información de un paso 

    static void ConsultarPlaca() //Consulta los datos por placa
    {
        int c = 0;
        Console.Clear();
        Console.Write("Ingrese el número de placa que desea consultar: ");
        if (int.TryParse(Console.ReadLine(), out int consulta) && consulta >= 1 && consulta <= i)
        {
            c = Array.IndexOf(placa, consulta);


            if (c != -1)
            {
                // El pago se encuentra registrado, mostrar los datos
                ImprimirPago(c);
                Console.WriteLine("\n Presione cualquier tecla para volver al menú princial");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Placa no se encuentra registrada.");
                Console.ReadKey();

            }
        }
        else
        {
            Console.WriteLine(" Número de placa inválida, ingrese un número válido. Regresando el menú principal.");
            Console.ReadKey();

        }

    }

    static void Modificar()
    {
        int c = 0;
        Console.Clear();
        Console.Write("Ingrese el número de placa que desea consultar: ");
        if (int.TryParse(Console.ReadLine(), out int consulta) && consulta >= 1 && consulta <= i)
        {
            c = Array.IndexOf(placa, consulta);


            if (c != -1)
            {
                // El pago se encuentra registrado, mostrar los datos
                ImprimirPago(c);
                ModificarDatos(c);
            }
            else
            {
                Console.WriteLine("Placa no se encuentra registrada.");
                Console.ReadKey();

            }
        }
        else
        {
            Console.WriteLine(" Número de placa inválida, ingrese un número válido. Regresando el menú principal.");
            Console.ReadKey();

        }
    }

    static void ModificarDatos(int c)
    {
        // Ventana de modificación
        do
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n ===Menú de Modificación===");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("1. Modificar Fecha");
            Console.WriteLine("2. Modificar hora");
            Console.WriteLine("3. Modificar placa");
            Console.WriteLine("4. Modificar caseta");
            Console.WriteLine("5. Modificar factura");
            Console.WriteLine("6. Salir");


            Console.Write("\nIngrese la opción deseada: ");
            if (int.TryParse(Console.ReadLine(), out int opt))
            {
                switch (opt)
                {
                    case 1:
                        fecha[c] = ObtenerFecha("Nueva Fecha (YYYY-MM-DD): ");
                        Console.WriteLine("Fecha guardada satisfactoriamente"); Console.ReadKey();
                        break;
                    case 2:
                        Console.Write("\nNueva hora: ");
                        hora[c] = Console.ReadLine();
                        Console.WriteLine("Hora guardada satisfactoriamente"); Console.ReadKey();
                        break;
                    case 3:
                        Console.Write("\nNueva placa: ");
                        placa[c] = int.Parse(Console.ReadLine());
                        Console.WriteLine("Placa guardada satisfactoriamente"); Console.ReadKey();
                        break;
                    case 4:
                        Console.Write("\nNuevo caseta: ");
                        caseta[c] = int.Parse(Console.ReadLine());
                        Console.WriteLine("Caseta guardada satisfactoriamente"); Console.ReadKey();
                        break;
                    case 5:
                        Console.Write("\nNueva factura: ");
                        factura[c] = int.Parse(Console.ReadLine());
                        Console.WriteLine("Factura guardada satisfactoriamente"); Console.ReadKey();
                        break;
                    case 6:
                        Console.WriteLine("Regresando al Menú Principal..."); Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Por favor, ingrese un número del 1 al 6.");
                        break;
                }
                if (opt == 15)
                {
                    break;
                }
            }
            else
            {
                Console.WriteLine("\nPor favor, ingrese un número válido.");
            }
        } while (true);
    }

    static void Reporte()
    {
        Console.Clear(); // Limpiar la ventana

        Console.WriteLine("===Reporte de todos los Pasos===");

        // Mostrar todos los pagos
        for (int ii = 0; ii < i; ii++)
        {
            Console.ForegroundColor = ConsoleColor.White;
            ImprimirPago(ii);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("------------------------------");
        }

        Console.WriteLine("\nPresione Enter para regresar al menú...");
        Console.ReadLine();
        Console.Clear(); // Limpiar la ventana después de presionar Enter
    }

}




