using System;
using System.Collections.Generic;

namespace SistemaNomina
{
    class Program
    {
        static List<Empleado> empleados = new List<Empleado>();

        static void Main(string[] args)
        {
            bool salir = false;
            while (!salir)
            {
                Console.WriteLine("===== MENÚ PRINCIPAL =====");
                Console.WriteLine("1. Ingresar empleado");
                Console.WriteLine("2. Ver empleados");
                Console.WriteLine("3. Eliminar empleado");

                Console.Write("Seleccione una opción: ");
                int opcion = int.Parse(Console.ReadLine());
                Console.WriteLine();

                switch (opcion)
                {
                    case 1:
                        IngresarEmpleado();
                        break;
                    case 2:
                        VerEmpleados();
                        break;
                    case 3:
                        EliminarEmpleado();
                        break;
                    case 4:
                        salir = true;
                        Console.WriteLine("Saliendo del sistema...");
                        break;
                    default:
                        Console.WriteLine("Opción inválida. Intente nuevamente.");
                        break;
                }

                Console.WriteLine();
            }
        }

        static void IngresarEmpleado()
        {
            Console.WriteLine("===== INGRESAR EMPLEADO =====");

            Console.Write("Nombre: ");
            string nombre = Console.ReadLine();

            Console.Write("Apellido: ");
            string apellido = Console.ReadLine();

            Console.Write("Puesto: ");
            string puesto = Console.ReadLine();

            Console.Write("Edad: ");
            int edad = int.Parse(Console.ReadLine());

            Console.Write("Sexo (M/F): ");
            char sexo = char.Parse(Console.ReadLine());

            Console.Write("Fecha de Nacimiento (dd/mm/yyyy): ");
            DateTime fechaNacimiento = DateTime.Parse(Console.ReadLine());

            Console.Write("Posee Licencia (S/N): ");
            bool poseeLicencia = Console.ReadLine().ToUpper() == "S";

            Console.Write("Sueldo Bruto: ");
            decimal sueldoBruto = decimal.Parse(Console.ReadLine());

            Empleado empleado = new Empleado(nombre, apellido,puesto, edad, sexo, fechaNacimiento, poseeLicencia, sueldoBruto);
            empleados.Add(empleado);

            Console.WriteLine("Empleado ingresado correctamente.");
        }

        static void VerEmpleados()
        {
            Console.WriteLine("===== VER EMPLEADOS =====");
            if (empleados.Count == 0)
            {
                Console.WriteLine("No hay empleados registrados.");
            }
            else
            {
                foreach (Empleado empleado in empleados)
                {
                    Console.WriteLine(empleado.ToString());
                }
            }
        }

        static void EliminarEmpleado()
        {
            Console.WriteLine("===== ELIMINAR EMPLEADO =====");
            if (empleados.Count == 0)
            {
                Console.WriteLine("No hay empleados registrados.");
            }
            else
            {
                Console.Write("Ingrese el índice del empleado a eliminar: ");
                int indice = int.Parse(Console.ReadLine());

                if (indice >= 0 && indice < empleados.Count)
                {
                    empleados.RemoveAt(indice);
                    Console.WriteLine("Empleado eliminado correctamente.");
                }
                else
                {
                    Console.WriteLine("Índice inválido.");
                }
            }
        }


        class Empleado
        {
            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public string Puesto { get; set; }
            public int Edad { get; set; }
            public char Sexo { get; set; }
            public DateTime FechaNacimiento { get; set; }
            public bool PoseeLicencia { get; set; }
            public decimal SueldoBruto { get; set; }

            public Empleado(string nombre, string apellido, string puesto, int edad, char sexo, DateTime fechaNacimiento, bool poseeLicencia, decimal sueldoBruto)
            {
                Nombre = nombre;
                Apellido = apellido;
                Puesto = puesto;
                Edad = edad;
                Sexo = sexo;
                FechaNacimiento = fechaNacimiento;
                PoseeLicencia = poseeLicencia;
                SueldoBruto = sueldoBruto;
            }

            public override string ToString()
            {
                return $"Nombre: {Nombre} {Apellido}\n" +
                       $"Puesto: {Puesto}\n" +
                       $"Edad: {Edad}\n" +
                       $"Sexo: {Sexo}\n" +
                       $"Fecha de Nacimiento: {FechaNacimiento}\n" +
                       $"Posee Licencia: {PoseeLicencia}\n" +
                       $"Sueldo Bruto: {SueldoBruto}\n";
            }
        }
    }
}