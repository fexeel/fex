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

        static List<Point> ReadPoints(string fileName)
        {
            string[] lines = File.ReadAllLines(fileName);
            List<Point> points = new List<Point>();

            foreach (string line in lines)
            {
                points.Add(CreatePoint(line));
            }

            return points;
        }

        static void Main()
        {
            List<Point> points = ReadPoints("C:\\Users\\Валерия\\Desktop\\fex\\пис 1 лаба\\пис 1 лаба\\points.txt");

            foreach (Point point in points)
            {
                PrintPoint(point);
            }
        }
    }
}
