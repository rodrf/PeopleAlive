using System;
using System.IO;

namespace PeoopleAlive
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                AliveCount aliveCount = new AliveCount();
                Console.WriteLine("\t\t***** Programa para calcular el número de personas vivas por anio *****");
                Console.Write("\nPresione una tecla para continuar... ");
                Console.ReadKey();
                Console.WriteLine("\nPor favor espere ...\n\n");
                aliveCount.countPeopleAlive(File.ReadAllText("data.json"));
                Console.ReadKey();
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message.ToString());
            }
        }
    }
}
