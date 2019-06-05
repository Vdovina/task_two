using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace task_two
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader("INPUT.txt");
            string lineN = null, lineP = null;
            try
            {
                lineN = reader.ReadLine();
                lineP = reader.ReadLine();
            }
            catch (Exception) { Console.WriteLine("Файл не был найден!"); }
            reader.Close();

            int n = 0;
            try { n = Convert.ToInt32(lineN); } catch(FormatException) { Console.WriteLine("Неверный формат!"); }

            double[] probs = DevideIntoDoubleArray(lineP);
            double p = 1;
            for (int i = 0; i < n; i++)
            {
                p = p * probs[i] + (1 - p) * (1 - probs[i]);
            }

            p = Math.Round(p, 6);
            string answer = p.ToString().Replace(',', '.');
            StreamWriter writer = new StreamWriter("OUTPUT.txt");
            writer.Write(answer);
            writer.Close();

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"Вероятность того, что Владимир Алексеевич сказал мальчикам о жизни на Марсе равна {p}.");
            Console.ResetColor();

            Console.ReadLine();
        }

        static double[] DevideIntoDoubleArray(string l)
        {
            l = l.Replace('.', ',');
            string[] numbers = l.Split(' ');
            double[] probabilities = new double[numbers.Length];
            int i = 0;
            foreach (string str in numbers)
            {
                try
                {
                    probabilities[i] = double.Parse(str);
                    i++;
                }
                catch (FormatException) { Console.WriteLine("Неверный формат!"); }
            }
            return probabilities;
        }
    }
}
