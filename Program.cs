/*
Autor: Aaron David Guerrero Velazquez
Matricula: ES181000998
Fecha: Marzo de 2026

Descripcion:
Este programa en C# realiza una simulacion de ingresos petroleros a lo largo de un numero determinado de periodos, 
permitiendo analizar dos escenarios: uno sin intervencion solicita datos validados como ingreso inicial, tasa de 
crecimiento, numero de periodos y limite maximo. A traves de estructuras de control y funciones, calcula la evolucion 
de los ingresos en cada escenario, mostrando resultados por periodo. En el segundo caso, la tasa de crecimiento 
disminuye progresivamente hasta llegar a un posible estancamiento. Finalmente, el usuario puede decidir si desea 
ejecutar una nueva simulacion.
*/

using System;

class Program
{
    // UTILIDADES 

    static void MostrarEncabezado()
    {
        Console.Clear();
        Console.WriteLine("==========================================");
        Console.WriteLine(" SIMULACION DE INGRESOS PETROLEROS ");
        Console.WriteLine("==========================================\n");
    }

    static bool DeseaRepetir()
    {
        string respuesta;

        do
        {
            Console.Write("\nDesea realizar otra simulacion (S/N): ");
            respuesta = (Console.ReadLine() ?? "").Trim().ToUpper();

            if (respuesta != "S" && respuesta != "N")
            {
                Console.WriteLine("Error: solo ingrese S o N.");
            }

        } while (respuesta != "S" && respuesta != "N");

        return respuesta == "S";
    }

    //VALIDACIONES 

    static int SolicitarEntero(string mensaje)
    {
        int valor;
        string entrada;

        do
        {
            Console.Write(mensaje);
            entrada = Console.ReadLine() ?? "";

            if (!int.TryParse(entrada, out valor) || valor <= 0)
            {
                Console.WriteLine("Error: ingrese un numero entero positivo.");
            }

        } while (valor <= 0);

        return valor;
    }

    static double SolicitarDecimal(string mensaje)
    {
        double valor;
        string entrada;

        do
        {
            Console.Write(mensaje);
            entrada = Console.ReadLine() ?? "";

            if (!double.TryParse(entrada, out valor) || valor <= 1.0)
            {
                Console.WriteLine("Error: ingrese un numero decimal mayor a 1.0.");
            }

        } while (valor <= 1.0);

        return valor;
    }

    // SALIDA

    static void MostrarResultado(int periodo, double ingreso)
    {
        Console.WriteLine($"Periodo {periodo}: Ingresos = {Math.Round(ingreso):N0} millones de dolares");
    }

    // ESCENARIO A 

    static double SimularEscenarioSinIntervencion(double inicial, double tasa, int periodos, double limite)
    {
        double ingresoActual = inicial;

        for (int i = 1; i <= periodos; i++)
        {
            ingresoActual *= tasa;

            MostrarResultado(i, ingresoActual);

            if (ingresoActual >= limite)
            {
                Console.WriteLine($"Limite maximo alcanzado en el periodo {i}");
                break;
            }
        }

        return ingresoActual;
    }

    //ESCENARIO B 

    static double SimularEscenarioConIntervencion(double inicial, double tasa, int periodos, double limite)
    {
        double ingresoActual = inicial;
        double crecimientoBase = tasa - 1.0;
        double tasaActual = tasa;
        for (int i = 1; i <= periodos; i++)

        {

    // Calcula la reduccion progresiva del crecimiento (20% por periodo)

            double nuevoCrecimiento = crecimientoBase * Math.Pow(0.80, i - 1);
            tasaActual = 1.0 + nuevoCrecimiento;

            ingresoActual *= tasaActual;

            Console.WriteLine($"Periodo {i}: Ingresos = {Math.Round(ingresoActual):N0} millones de dolares (tasa: {tasaActual:F3})");

            if (ingresoActual >= limite)
            {
                Console.WriteLine($"Limite maximo alcanzado en el periodo {i}");
                break;
            }

            if (tasaActual <= 1.0)
            {
                Console.WriteLine("Estancamiento economico alcanzado");
                break;
            }
        }

        return ingresoActual;
    }

    // FLUJO PRINCIPAL

    static void EjecutarSimulacion()
    {
        int ingresoInicial = SolicitarEntero("Ingrese el ingreso inicial (millones USD): ");
        double tasa = SolicitarDecimal("Ingrese la tasa de crecimiento inicial: ");
        int periodos = SolicitarEntero("Ingrese el numero de periodos a simular: ");

        int limite;

        do

        {
            limite = SolicitarEntero("Ingrese el limite maximo de ingresos: ");

            if (limite <= ingresoInicial)
            {
                Console.WriteLine("Error: el limite debe ser mayor al ingreso inicial.");
            }

        } while (limite <= ingresoInicial);

        Console.WriteLine("\nESCENARIO A: SIN INTERVENCION EXTERNA\n");
        SimularEscenarioSinIntervencion(ingresoInicial, tasa, periodos, limite);

        Console.WriteLine("\nESCENARIO B: CON INTERVENCION INTERNACIONAL\n");
        SimularEscenarioConIntervencion(ingresoInicial, tasa, periodos, limite);
    }

    // MAIN

    static void Main()
    {
        bool repetir;

        do
        {
            MostrarEncabezado();
            EjecutarSimulacion();
            repetir = DeseaRepetir();

        } while (repetir);

        Console.WriteLine("\nPrograma finalizado.");
    }
}
