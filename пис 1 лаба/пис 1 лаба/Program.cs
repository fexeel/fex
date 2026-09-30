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
        static Point CreatePoint(string line)
        {
            string[] parts = line.Split(
                new char[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries);

            Point point = new Point();

            point.X = double.Parse(parts[0]);
            point.Y = double.Parse(parts[1]);
            point.color = parts[2].Trim('"');

            return point;
        }

        static void PrintPoint(Point point)
        {
            Console.WriteLine(
                $"X = {point.X}, Y = {point.Y}, Color = {point.color}");
        }

        static void Main()
        {
            Console.WriteLine("Введите точку:");

            string line = Console.ReadLine();

            Point point = CreatePoint(line);

            PrintPoint(point);
        }
    }
}
