using System;
using System.Collections;
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
                var pressedKey = Console.ReadKey();
                while (Console.KeyAvailable) Console.ReadKey();
                if (pressedKey.Key == ConsoleKey.LeftArrow)
                {
                    if (playerCar.Col > 0)
                    {
                        playerCar.Col--;
                    }
                }
                else if (pressedKey.Key == ConsoleKey.RightArrow)
                {
                    if (playerCar.Col < (Console.WindowWidth / 2) - 2)
                    {
                        playerCar.Col++;
                    }
                }
                else if (pressedKey.Key == ConsoleKey.UpArrow)
                {
                    if (playerCar.Row > 0)
                    {
                        playerCar.Row--;
                    }
                }
                else if (pressedKey.Key == ConsoleKey.DownArrow)
                {
                    if (playerCar.Row < Console.WindowHeight - 1)
                    {
                        playerCar.Row++;
                    }
                }
            }

            return playerCar;
        }

        public static List<Car> GenerateEnemyCars(List<Car> enemyCars)
        {
            var randomGenerator = new Random();
            var newCarRow = randomGenerator.Next(0, (Console.WindowWidth / 2) - 1);
            var car = new Car(newCarRow, 0, ConsoleColor.Green, '#');
            enemyCars.Add(car);
            return enemyCars;
        }



        public static List<Car> MoveEnemyCars(List<Car> enemyCars)
        {
            var newList = new List<Car>();
            for (int i = 0; i < enemyCars.Count; i++)
            {
                var oldCar = enemyCars[i];
                var newCar = new Car(oldCar.Row, oldCar.Col + 1, oldCar.Color, oldCar.Symbol);
                newList.Add(newCar);
            }

            return newList;
        }
    }
}
