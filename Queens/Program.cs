using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queens
{
    class Program
    {
        public static string Queen = " ♕";
        public static string WhiteSpace = "  ";
        public static int ColumnCounter = 0;
        public static int RowCounter = 0;
        public static int Counter = 1;
        public static ConsoleColor SecondColor = ConsoleColor.Black;
        public static ConsoleColor FirstColor = ConsoleColor.White;
        public static int n = 8;//int.Parse(Console.ReadLine()) + 1;
        public static string[] QueensStatus = new string[n * n];
        public static string[] QueensPlaces = new string[n * n];

        public static void PossibleFields()
        {
            int temp = 0;
            for (int row = 1; row <= n; row++)
            {
                for (int column = 1; column <= n; column++)
                {
                    QueensStatus[temp] = $"{row}{column}";
                    temp++;
                }
            }
        }

        public static void PlaceQueens()
        {
            QueensPlaces[0]=QueensStatus[0];
        }
        public static void Write()
        {
            PossibleFields();
            Console.Write(Queen);
        }
        public static void test(ConsoleColor color1, ConsoleColor color2)
        {
            if (RowCounter < n)
            {
                if (ColumnCounter < n - 1 && Counter < 2)
                {
                    if (ColumnCounter % 2 == 0)
                    {
                        Console.BackgroundColor = color1;
                        Write();
                        ColumnCounter++;
                    }
                    else
                    {
                        Console.BackgroundColor = color2;
                        Write();
                        ColumnCounter++;
                    }
                    test(color1, color2);
                }
                else
                {
                    if (Counter == 2)
                    {
                        if (Console.BackgroundColor == ConsoleColor.White)
                        {
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.Write($"  {RowCounter}");
                        }
                        else
                        {
                            Console.Write($"  {RowCounter}");
                        }
                        Console.WriteLine();
                    }

                    ColumnCounter = 0;
                    Counter++;
                    if (Counter == 4)
                    {
                        if (color1 == ConsoleColor.White)
                        {
                            color1 = ConsoleColor.Black;
                            color2 = ConsoleColor.White;
                        }
                        else
                        {
                            color1 = ConsoleColor.White;
                            color2 = ConsoleColor.Black;
                        }
                        RowCounter++;
                        Counter = 1;
                    }
                    test(color1, color2);
                }
            }
        }
        public static void InsertFieldsNumber()
        {
            Console.Write($"{RowCounter + 1}".PadRight(2, ' '));
            RowCounter++;
            if (RowCounter < n - 1)
                InsertFieldsNumber();
            else
                Console.WriteLine();
        }
        static void Main(string[] args)
        {

            InsertFieldsNumber();
            RowCounter = 1;
            test(FirstColor, SecondColor);

            Console.ReadKey();
        }
    }
}
