using System;
//HOLA

class Program
{
    static string[] nombres = new string[20];
    static string[] ids = new string[20];
    static string[] areas = new string[20];
    static double[] sueldos = new double[20];
    static int contador = 5;

    static void Main(string[] args)
    {
        nombres[0] = "Juan";
        ids[0] = "E1";
        areas[0] = "IT";
        sueldos[0] = 800;

        nombres[1] = "Maria";
        ids[1] = "E2";
        areas[1] = "RRHH";
        sueldos[1] = 700;

        nombres[2] = "Carlos";
        ids[2] = "E3";
        areas[2] = "Ventas";
        sueldos[2] = 650;

        nombres[3] = "Ana";
        ids[3] = "E4";
        areas[3] = "IT";
        sueldos[3] = 900;

        nombres[4] = "Luis";
        ids[4] = "E5";
        areas[4] = "Soporte";
        sueldos[4] = 600;

        if (!Login()) return;

        int opcion;

        do
        {
            Console.Clear();
            Console.WriteLine("=== SISTEMA EMPLEADOS ===");
            Console.WriteLine("1. Mostrar empleados");
            Console.WriteLine("2. Agregar empleado");
            Console.WriteLine("3. Buscar por area");
            Console.WriteLine("4. Ver detalle de empleado");
            Console.WriteLine("5. Salir");
            Console.Write("Opcion: ");

            opcion = int.Parse(Console.ReadLine());
            Console.Clear();

            switch (opcion)
            {
                case 1: Mostrar(); Pausa(); break;
                case 2: Agregar(); Pausa(); break;
                case 3: BuscarArea(); Pausa(); break;
                case 4: Detalle(); Pausa(); break;
            }

        } while (opcion != 5);
    }

    static bool Login()
    {
        int intentos = 3;
        while (intentos > 0)
        {
            Console.Clear();
            Console.WriteLine("=== LOGIN ===");
            Console.Write("Usuario: ");
            string u = Console.ReadLine();
            Console.Write("Clave: ");
            string c = Console.ReadLine();

            if (u == "user" && c == "1234")
                return true;

            intentos--;
            Console.WriteLine("Incorrecto");
            Pausa();
        }
        return false;
    }

    static void Agregar()
    {
        if (contador < 20)
        {
            Console.Write("Nombre: ");
            nombres[contador] = Console.ReadLine();
            Console.Write("ID: ");
            ids[contador] = Console.ReadLine();
            Console.Write("Area: ");
            areas[contador] = Console.ReadLine();
            Console.Write("Sueldo: ");
            sueldos[contador] = double.Parse(Console.ReadLine());
            contador++;
            Console.WriteLine("Agregado");
        }
        else
        {
            Console.WriteLine("Limite alcanzado");
        }
    }

    static void Mostrar()
    {
        for (int i = 0; i < contador; i++)
        {
            Console.WriteLine(nombres[i] + " | " + ids[i] + " | " + areas[i] + " | $" + sueldos[i]);
        }
    }

    static void BuscarArea()
    {
        Console.Write("Area: ");
        string a = Console.ReadLine();
        bool encontrado = false;

        for (int i = 0; i < contador; i++)
        {
            if (areas[i] == a)
            {
                Console.WriteLine(nombres[i] + " | " + ids[i] + " | $" + sueldos[i]);
                encontrado = true;
            }
        }

        if (!encontrado)
            Console.WriteLine("No encontrado");
    }

    static void Detalle()
    {
        Console.Write("Ingrese ID: ");
        string dato = Console.ReadLine();
        bool encontrado = false;

        for (int i = 0; i < contador; i++)
        {
            if (ids[i] == dato)
            {
                double bruto = sueldos[i];
                double afp = bruto * 0.0725;
                double isss = bruto * 0.03;
                double renta = 0;

                if (bruto > 472)
                    renta = (bruto - 472) * 0.1;

                double neto = bruto - afp - isss - renta;

                Console.WriteLine("Nombre: " + nombres[i]);
                Console.WriteLine("Area: " + areas[i]);
                Console.WriteLine("Salario bruto: $" + bruto);
                Console.WriteLine("AFP: $" + afp);
                Console.WriteLine("ISSS: $" + isss);
                Console.WriteLine("Renta: $" + renta);
                Console.WriteLine("Salario neto: $" + neto);

                encontrado = true;
            }
        }

        if (!encontrado)
            Console.WriteLine("No encontrado");
    }

    static void Pausa()
    {
        Console.WriteLine("Presione una tecla...");
        Console.ReadKey();
    }
}