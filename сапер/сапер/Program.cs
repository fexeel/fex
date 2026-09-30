using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace сапер
{
    class Program
    {
        static void Main()
        {
            const int SIZE = 5;
            const int MINES = 5;

            char[,] field = new char[SIZE, SIZE];
            bool[,] mines = new bool[SIZE, SIZE];
            bool[,] opened = new bool[SIZE, SIZE];

            Random random = new Random();

            // Заполняем поле закрытыми клетками
            for (int i = 0; i < SIZE; i++)
            {
                for (int j = 0; j < SIZE; j++)
                {
                    field[i, j] = '#';
                }
            }

            // Расставляем мины
            int minesPlaced = 0;

            while (minesPlaced < MINES)
            {
                int x = random.Next(SIZE);
                int y = random.Next(SIZE);

                if (!mines[x, y])
                {
                    mines[x, y] = true;
                    minesPlaced++;
                }
            }

            // Игра
            int openedCells = 0;
            bool gameOver = false;

            while (!gameOver)
            {
                Console.Clear();

                // Вывод поля
                Console.WriteLine("  0 1 2 3 4");

                for (int i = 0; i < SIZE; i++)
                {
                    Console.Write(i + " ");

                    for (int j = 0; j < SIZE; j++)
                    {
                        Console.Write(field[i, j] + " ");
                    }

                    Console.WriteLine();
                }

                Console.WriteLine();
                Console.WriteLine("Введите строку и столбец (например: 2 3):");

                string[] input = Console.ReadLine().Split(' ');

                int row = int.Parse(input[0]);
                int column = int.Parse(input[1]);

                // Проверяем координаты
                if (row < 0 || row >= SIZE || column < 0 || column >= SIZE)
                {
                    Console.WriteLine("Такой клетки нет!");
                    Console.ReadKey();
                    continue;
                }

                // Если клетка уже открыта
                if (opened[row, column])
                {
                    Console.WriteLine("Эта клетка уже открыта!");
                    Console.ReadKey();
                    continue;
                }

                // Проверяем мину
                if (mines[row, column])
                {
                    Console.Clear();

                    // Показываем все мины
                    for (int i = 0; i < SIZE; i++)
                    {
                        for (int j = 0; j < SIZE; j++)
                        {
                            if (mines[i, j])
                                field[i, j] = '*';
                        }
                    }

                    Console.WriteLine("Ты попал на мину!");
                    Console.WriteLine("Игра окончена.");

                    // Вывод поля
                    Console.WriteLine();

                    for (int i = 0; i < SIZE; i++)
                    {
                        for (int j = 0; j < SIZE; j++)
                        {
                            Console.Write(field[i, j] + " ");
                        }

                        Console.WriteLine();
                    }

                    gameOver = true;
                }
                else
                {
                    // Считаем мины вокруг клетки
                    int mineCount = 0;

                    for (int i = row - 1; i <= row + 1; i++)
                    {
                        for (int j = column - 1; j <= column + 1; j++)
                        {
                            if (i >= 0 && i < SIZE &&
                                j >= 0 && j < SIZE &&
                                mines[i, j])
                            {
                                mineCount++;
                            }
                        }
                    }

                    field[row, column] = (char)('0' + mineCount);
                    opened[row, column] = true;
                    openedCells++;

                    // Проверяем победу
                    if (openedCells == SIZE * SIZE - MINES)
                    {
                        Console.Clear();

                        Console.WriteLine("Ты победил!");

                        for (int i = 0; i < SIZE; i++)
                        {
                            for (int j = 0; j < SIZE; j++)
                            {
                                Console.Write(field[i, j] + " ");
                            }

                            Console.WriteLine();
                        }

                        gameOver = true;
                    }
                }
            }

            Console.WriteLine();
            Console.WriteLine("Нажмите любую клавишу...");
            Console.ReadKey();
        }
    }
}
