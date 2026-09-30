using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Diagnostics;

namespace пис_1_лаба
{
    class Program
    {
        static Point CreatePoint(string s)
        {
            string[] parts = s.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            Point point = new Point();

            point.X = double.Parse(parts[1]);
            point.Y = double.Parse(parts[2]);
            point.color = parts[3].Trim('"');

            return point;
        }

        static void Main()
        {

            int qatityone(int[] qatity)
            {
                int counter = 0;
                for (int i = 0; i < qatity.Length-2; i++)
                {
                    if (qatity[i + 1] == 1)
                    {
                        if (qatity[i] == 0 && qatity[i + 2] == 0)
                        {
                            counter++;
                        }
                    }
                }
                return counter;
            }

            Console.WriteLine("Введите точку:");
            string s = Console.ReadLine();

            Point point = CreatePoint(s);

            Console.WriteLine("X = " + point.X);
            Console.WriteLine("Y = " + point.Y);
            Console.WriteLine("Цвет = " + point.color);
            int[] array = { 0, 1, 0, 1, 1, 0, 1, 0, 1, 0, 1, 1, 0 };
            Console.WriteLine($"количество {qatityone(array)}");

            string[] vertices = File.ReadAllLines("vertices.txt");
            Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();

        }
        
        
        
                     
    }   
}
