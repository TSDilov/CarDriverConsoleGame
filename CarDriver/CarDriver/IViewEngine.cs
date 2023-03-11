namespace CarDriver
{
    public interface IViewEngine
    {
        void PrintSymbol(int row, int col, char symbol, ConsoleColor color);

        void PrintTheWall();

        void PrintEnemyCars(List<Car> enemyCars);

        void PrintTheGameInfo(int lives);
    }
}
