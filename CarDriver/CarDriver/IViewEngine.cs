namespace CarDriver
{
    public interface IViewEngine
    {
        void PrintSymbol(int row, int col, char symbol, ConsoleColor color);

        void PrintTheWall();
    }
}
