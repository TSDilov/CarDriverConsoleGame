using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDriver
{   
    public class ConsolePrinter : IViewEngine
    {
        private const string GAME_RULES = "Avoid the cars and becom better racer!.";
        private const string WARNING = "Be careful the enemy cars become faster!";
        public void PrintSymbol(int row, int col, char symbol, ConsoleColor color = ConsoleColor.Gray)
        {
            Console.SetCursorPosition(col, row);
            Console.ForegroundColor = color;
            Console.Write(symbol);
        }

        public void PrintTheWall()
        {
            for (int i = 0; i < Console.WindowHeight; i++)
            {
                Console.SetCursorPosition((Console.WindowWidth / 2) - 1, i);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("||");
            }
        }

        public void PrintEnemyCars(List<Car> enemyCars)
        {
            foreach (var car in enemyCars)
            {
                Console.SetCursorPosition(car.Row, car.Col);
                Console.ForegroundColor = car.Color;
                Console.Write(car.Symbol);
            }
        }

        public void PrintTheGameInfo(int lifes, int score, bool loseLive = false)
        {
            this.PrintText((Console.WindowWidth / 2) + 3, 1, "Car Driver!!!", ConsoleColor.DarkBlue);
            this.PrintText((Console.WindowWidth / 2) + 3, 3, $"Lifes: {lifes}", ConsoleColor.DarkBlue);
            this.PrintText((Console.WindowWidth / 2) + 3, 5, $"Score: {score}", ConsoleColor.DarkBlue);
            this.PrintText((Console.WindowWidth / 2) + 3, 9, GAME_RULES, ConsoleColor.DarkBlue);
            this.PrintText((Console.WindowWidth / 2) + 3, 10, WARNING, ConsoleColor.DarkBlue);
            if (loseLive)
            {
                this.PrintText((Console.WindowWidth / 2) + 3, 12, "You lose a life", ConsoleColor.DarkBlue);
            }
        }

        private void PrintText(int row, int col, string text, ConsoleColor color = ConsoleColor.Gray)
        {
            Console.SetCursorPosition(row, col);
            Console.ForegroundColor = color;
            Console.WriteLine(text);
        }

        public void PrintGameOver()
        {
            Console.Clear();
            Console.SetCursorPosition((Console.WindowWidth / 2) - 5, Console.WindowHeight / 2);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Game over!");
        }
    }
}
