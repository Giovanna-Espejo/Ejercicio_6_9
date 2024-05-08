using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.Distributions;

namespace Ejercicio_6_9
{
    internal class Program
    {
        static void Main()
        {
            double med = 110;
            double valSup = 135;
            double des = (valSup - med) / 2.575;

            double m = 1.036;
            double limInf = med - des * m;
            double limSup = med + des * m;

            Console.WriteLine("calcular la desviación típica de dicha población normal y los límites del intervalo que comprende al 70% de los \r\nvalores de la misma, así como el porcentaje de población que tiene:");
            Console.WriteLine("");
            Console.WriteLine("Desviación : " + des);
            Console.WriteLine("Intervalo del 70% de los valores es de " + limInf + "en el limite inferior y " + limSup + " en el limite superior");
            Console.WriteLine("");

            char respuesta;
            do
            {
                Console.WriteLine("Si desea calcular un valor superior presione a, si desea uno inferior b y si es entre valores c");
                respuesta = Console.ReadKey().KeyChar;
                Console.WriteLine();
            } while (respuesta != 'a' && respuesta != 'b' && respuesta != 'c');

            if (respuesta=='a')
            {
                Console.WriteLine("");
                Console.WriteLine("Escriba la cantidad de microgramos por mililitro de la que sea desea calcular el porcentaje");
                int micXmil = Convert.ToInt32(Console.ReadLine());
                double superior = 1 - Normal.CDF(med, des, micXmil);
                Console.WriteLine("El porcentaje de población superior a "+micXmil+"microgramos por mililitro: " + superior * 100 + "%");

            }
            else if (respuesta == 'b')
            {
                Console.WriteLine("");
                Console.WriteLine("Escriba la cantidad de microgramos por mililitro de la que sea desea calcular el porcentaje");
                int micXmil = Convert.ToInt32(Console.ReadLine());
                double inferior = Normal.CDF(med, des, micXmil);
                Console.WriteLine("El porcentaje de población inferior a "+micXmil+ "microgramos por mililitro: " + inferior * 100 + "%");
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine("Escriba la cantidad de microgramos inferior y superior por mililitro de la que sea desea calcular el porcentaje");
                int infmicXmil = Convert.ToInt32(Console.ReadLine());
                int supmicXmil = Convert.ToInt32(Console.ReadLine());
                double concEntre = Normal.CDF(med, des, supmicXmil) - Normal.CDF(med, des, infmicXmil);
                Console.WriteLine("El porcentaje de población con concentración comprendida entre "+infmicXmil+" y "+supmicXmil+ " microgramos por mililitro: " + concEntre * 100 + "%");
            }
            Console.ReadKey();
        }
    }
}