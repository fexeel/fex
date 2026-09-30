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

        static string[] ReadFile(string fileName)
        {
            return File.ReadAllLines(fileName);
        }

        static List<Point> CreatePoints(string[] lines)
        {
            List<Point> points = new List<Point>();

            foreach (string line in lines)
            {
                points.Add(CreatePoint(line));
            }

            return points;
        }

        static void PrintPoint(Point point)
        {
            Console.WriteLine(
                $"X = {point.X}, Y = {point.Y}, Color = {point.color}");
        }

        static void PrintPoints(List<Point> points)
        {
            foreach (Point point in points)
            {
                PrintPoint(point);
            }
        }

        static void Main()
        {
            string[] lines = ReadFile("C:\\Users\\Валерия\\Desktop\\fex\\пис 1 лаба\\пис 1 лаба\\points.txt");

            List<Point> points = CreatePoints(lines);

            PrintPoints(points);
        }
    }
}
