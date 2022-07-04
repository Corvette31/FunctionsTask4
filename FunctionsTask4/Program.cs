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
                { '#', ' ', ' ', '#', ' ', 'X', ' ', ' ', 'E', '#'
                },
                { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#'
                },
            };
            int userPositionX = 2;
            int userPositionY = 2;
            char[] bag = { };
            bool isRun = true;

            map[userPositionX, userPositionY] = '$';

            while (isRun)
            {
                DrawMap(map);
                DrawBag(bag);
                ChangePosition(map, ref userPositionX, ref userPositionY);
                ChangeBag(map, ref bag, userPositionX, userPositionY);

                isRun = CheckExit(map,userPositionX,userPositionY) == false;
                map[userPositionX, userPositionY] = '$';
            }

            Console.WriteLine("GAME OVER");
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

        static void ChangePosition(char[,] map, ref int positionX, ref int positionY)
        {
            ConsoleKeyInfo key = Console.ReadKey();
            map[positionX, positionY] = ' ';

            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    if (CheckBorder(map, positionX - 1, positionY) == false) 
                    {
                        positionX--;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (CheckBorder(map, positionX + 1, positionY) == false) 
                    {
                        positionX++;
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    if (CheckBorder(map, positionX, positionY - 1) == false)
                    {
                        positionY--;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (CheckBorder(map, positionX, positionY + 1) == false)
                    {
                        positionY++;
                    }
                    break;
            }
        }

        static void DrawBag(char[] bag)
        {
            Console.Write("Сумка : ");

            for (int i = 0; i < bag.Length; i++)
            {
                Console.Write($"{bag[i]} ");
            }         
        }

        static void ExpandBag(ref char[] array, int size, char newItem)
        {
            char[] tempArray = new char[size];

            for (int i = 0; i < array.Length; i++)
            {
                tempArray[i] = array[i];
            }

            tempArray[tempArray.Length - 1] = newItem;
            array = tempArray;
        }

        static void ChangeBag(char[,] map, ref char[] bag, int userPositionX, int userPositionY)
        {
            if (map[userPositionX, userPositionY] == 'X')
            {
                ExpandBag(ref bag, bag.Length + 1, 'X');
            }
        }

        static bool CheckExit(char[,] map, int userPositionX, int userPositionY)
        {
            if (map[userPositionX, userPositionY] == 'E')
            {
                return true;
            }

            return false;
        }

        static bool CheckBorder(char[,] map, int userPositionX, int userPositionY)
        {
            if (map[userPositionX, userPositionY] == '#')
            {
                return true;
            }

            return false;
        }
    }
}
