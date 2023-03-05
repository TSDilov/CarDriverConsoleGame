using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDriver
{
    public class ConsolePrinter : IViewEngine
    {
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
    }
}
