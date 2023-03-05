using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDriver
{
    public class Controller
    {
        public static Car MovingTheCar(Car playerCar)
        {
            if (Console.KeyAvailable)
            {
                if (Console.ReadKey().Key == ConsoleKey.LeftArrow)
                {
                    if (playerCar.Col > 0)
                    {
                        playerCar.Col--;
                    }
                }
                else if (Console.ReadKey().Key == ConsoleKey.RightArrow)
                {
                    if (playerCar.Col < (Console.WindowWidth / 2) - 2)
                    {
                        playerCar.Col++;
                    }
                }
                else if (Console.ReadKey().Key == ConsoleKey.UpArrow)
                {
                    if (playerCar.Row > 0)
                    {
                        playerCar.Row--;
                    }
                }
                else if (Console.ReadKey().Key == ConsoleKey.DownArrow)
                {
                    if (playerCar.Row < Console.WindowHeight - 1)
                    {
                        playerCar.Row++;
                    }
                }
            }

            return playerCar;
        }
    }
}
