using System;
using System.Collections.Generic;

namespace SistemaNomina
{
    class Empleado
    {
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public int Edad { get; set; }
        public char Sexo { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public bool PoseeLicencia { get; set; }
        public decimal SueldoBruto { get; set; }
        public decimal SueldoNeto { get; set; }
        public decimal TSS { get; set; }
        public decimal ImpuestoRenta { get; set; }
    }

    class Program
    {
        static List<Empleado> empleados = new List<Empleado>();

        static void Main(string[] args)
        {
            bool salir = false;

            while (!salir)
            {
                Console.WriteLine("=== Sistema de Nómina ===");
                Console.WriteLine("1. Agregar empleado");
                Console.WriteLine("2. Ver empleados");
                Console.WriteLine("3. Eliminar empleado");
                Console.WriteLine("4. Ver nómina");
                Console.WriteLine("5. Reporte de empleados mujeres");
                Console.WriteLine("6. Reporte de empleados con licencia");
                Console.WriteLine("7. Reporte de empleados con sueldo por encima de $50,000");
                Console.WriteLine("8. Salir");
                Console.Write("Seleccione una opción: ");
                string? opcionStr = Console.ReadLine();

                if (int.TryParse(opcionStr, out int opcion))
                {
                    switch (opcion)
                    {
                        case 1:
                            AgregarEmpleado();
                            break;
                        case 2:
                            VerEmpleados();
                            break;
                        case 3:
                            EliminarEmpleado();
                            break;
                        case 4:
                            VerNomina();
                            break;
                        case 5:
                            ReporteEmpleadosMujeres();
                            break;
                        case 6:
                            ReporteEmpleadosLicencia();
                            break;
                        case 7:
                            ReporteSueldoMayor50000();
                            break;
                        case 8:
                            salir = true;
                            break;
                        default:
                            Console.WriteLine("Opción inválida.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Opción inválida. Debe ingresar un número.");
                }

                Console.WriteLine();
            }
        }

        static void AgregarEmpleado()
        {
            Console.WriteLine("=== Agregar Empleado ===");
            Console.Write("Nombre: ");
            string? nombre = Console.ReadLine();
            Console.Write("Apellido: ");
            string? apellido = Console.ReadLine();
            Console.Write("Edad: ");
            if (int.TryParse(Console.ReadLine(), out int edad))
            {
                Console.Write("Sexo (M/F): ");
                char sexo = char.ToUpper(Console.ReadKey().KeyChar);
                Console.WriteLine();
                Console.Write("Fecha de Nacimiento (dd/mm/yyyy): ");
                if (DateTime.TryParse(Console.ReadLine(), out DateTime fechaNacimiento))
                {
                    Console.Write("Posee Licencia (S/N): ");
                    char poseeLicenciaChar = char.ToUpper(Console.ReadKey().KeyChar);
                    bool poseeLicencia = poseeLicenciaChar == 'S';
                    Console.WriteLine();
                    Console.Write("Sueldo Bruto: ");
                    if (decimal.TryParse(Console.ReadLine(), out decimal sueldoBruto))
                    {
                        Empleado empleado = new Empleado
                        {
                            Nombre = nombre,
                            Apellido = apellido,
                            Edad = edad,
                            Sexo = sexo,
                            FechaNacimiento = fechaNacimiento,
                            PoseeLicencia = poseeLicencia,
                            SueldoBruto = sueldoBruto
                        };

                        empleados.Add(empleado);
                        Console.WriteLine("Empleado agregado exitosamente.");
                    }
                    else
                    {
                        Console.WriteLine("Error: Sueldo Bruto inválido.");
                    }
                }
                else
                {
                    Console.WriteLine("Error: Fecha de Nacimiento inválida.");
                }
            }
            else
            {
                Console.WriteLine("Error: Edad inválida.");
            }
        }

        static void VerEmpleados()
        {
            Console.WriteLine("=== Lista de Empleados ===");
            foreach (var empleado in empleados)
            {
                Console.WriteLine($"Nombre: {empleado.Nombre} {empleado.Apellido}");
                Console.WriteLine($"Edad: {empleado.Edad}");
                Console.WriteLine($"Sexo: {empleado.Sexo}");
                Console.WriteLine($"Fecha de Nacimiento: {empleado.FechaNacimiento.ToShortDateString()}");
                Console.WriteLine($"Posee Licencia: {(empleado.PoseeLicencia ? "Sí" : "No")}");
                Console.WriteLine($"Sueldo Bruto: {empleado.SueldoBruto:C}");
                Console.WriteLine();
            }
        }

        static void EliminarEmpleado()
        {
            Console.WriteLine("=== Eliminar Empleado ===");
            Console.Write("Ingrese el nombre del empleado a eliminar: ");
            string? nombre = Console.ReadLine();
            bool empleadoEncontrado = false;

            for (int i = 0; i < empleados.Count; i++)
            {
                if (empleados[i].Nombre!.Equals(nombre, StringComparison.OrdinalIgnoreCase))
                {
                    empleados.RemoveAt(i);
                    empleadoEncontrado = true;
                    Console.WriteLine("Empleado eliminado exitosamente.");
                    break;
                }
            }

            if (!empleadoEncontrado)
            {
                Console.WriteLine("Error: No se encontró un empleado con ese nombre.");
            }
        }

        static void VerNomina()
        {
            Console.WriteLine("=== Nómina de Empleados ===");
            foreach (var empleado in empleados)
            {
                empleado.SueldoNeto = empleado.SueldoBruto - empleado.TSS - empleado.ImpuestoRenta;

                Console.WriteLine($"Nombre: {empleado.Nombre} {empleado.Apellido}");
                Console.WriteLine($"Sueldo Bruto: {empleado.SueldoBruto:C}");
                Console.WriteLine($"TSS: {empleado.TSS:C}");
                Console.WriteLine($"Impuesto sobre la Renta: {empleado.ImpuestoRenta:C}");
                Console.WriteLine($"Sueldo Neto: {empleado.SueldoNeto:C}");
                Console.WriteLine();
            }
        }

        static void ReporteEmpleadosMujeres()
        {
            Console.WriteLine("=== Empleados Mujeres ===");
            foreach (var empleado in empleados)
            {
                if (empleado.Sexo == 'F')
                {
                    Console.WriteLine($"Nombre: {empleado.Nombre} {empleado.Apellido}");
                    Console.WriteLine();
                }
            }
        }

        static void ReporteEmpleadosLicencia()
        {
            Console.WriteLine("=== Empleados con Licencia ===");
            foreach (var empleado in empleados)
            {
                if (empleado.PoseeLicencia)
                {
                    Console.WriteLine($"Nombre: {empleado.Nombre} {empleado.Apellido}");
                    Console.WriteLine();
                }
            }
        }

        static void ReporteSueldoMayor50000()
        {
            Console.WriteLine("=== Empleados con Sueldo Mayor a $50,000 ===");
            foreach (var empleado in empleados)
            {
                if (empleado.SueldoBruto > 50000)
                {
                    Console.WriteLine($"Nombre: {empleado.Nombre} {empleado.Apellido}");
                    Console.WriteLine($"Sueldo Bruto: {empleado.SueldoBruto:C}");
                    Console.WriteLine();
                }
            }
        }
    }
}

