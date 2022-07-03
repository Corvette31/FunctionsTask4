using System;

namespace FunctionsTask4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            char[,] map =
            {
                { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#'
                },
                { '#', ' ', 'X', '#', ' ', ' ', ' ', ' ', ' ', '#'
                },
                { '#', ' ', ' ', '#', ' ', ' ', ' ', 'X', ' ', '#'
                },
                { '#', ' ', ' ', '#', ' ', ' ', 'X', ' ', ' ', '#'
                },
                { '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'
                },
                { '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'
                },
                { '#', '#', '#', ' ', ' ', '#', '#', '#', '#', '#'
                },
                { '#', ' ', ' ', ' ', ' ', ' ', ' ', 'X', ' ', '#'
                },
                { '#', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ', '#'
                },
                { '#', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ', '#'
                },
                { '#', ' ', ' ', '#', ' ', 'X', ' ', ' ', ' ', '#'
                },
                { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#'
                },
            };
            int userX = 2;
            int userY = 2;
            char[] bag = { }; 

            map[userX, userY] = '$';

            while (true)
            {
                DrawMap(map);
                DrawBag(bag);
                ChangePosition(map, ref userX, ref userY, ref bag);
            }
        }

        static void DrawMap(char[,] map)
        {
            Console.Clear();

            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write(map[i, j]);
                }
                Console.WriteLine();
            }           
        }

        static void ChangePosition(char[,] map, ref int userX, ref int userY, ref char[] bag)
        {
            ConsoleKeyInfo key = Console.ReadKey();
            map[userX, userY] = ' ';

            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    if (map[userX - 1, userY] != '#')
                    {
                        userX--;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (map[userX + 1, userY] != '#')
                    {
                        userX++;
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    if (map[userX, userY - 1] != '#')
                    {
                        userY--;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (map[userX, userY + 1] != '#')
                    {
                        userY++;
                    }
                    break;
                default:
                    break;
            }

            if (map[userX, userY] == 'X')
            {
                ResizeArray(ref bag, bag.Length + 1);
                bag[bag.Length - 1] = 'X';
            }

            map[userX, userY] = '$';
        }

        static void DrawBag(char[] bag)
        {
            Console.Write("Сумка : ");

            for (int i = 0; i < bag.Length; i++)
            {
                Console.Write($"{bag[i]} ");
            }         
        }

        static void ResizeArray(ref char[] array, int size)
        {
            char[] tempArray = new char[size];

            for (int i = 0; i < array.Length; i++)
            {
                tempArray[i] = array[i];
            }

            array = tempArray;
        }
    }
}
