namespace CarDriver
{
    public class GameEngine
    {
        private readonly IViewEngine viewEngine;

        public GameEngine(IViewEngine viewEngine)
        {
            this.viewEngine = viewEngine;
        }
        public void Play()
        {
            var playerCar = new Car(Console.WindowHeight - 1, 7, ConsoleColor.Red, '@');
            var enemyCars = new List<Car>();

            while (true)
            {
                Console.Clear();
                this.ConsoleSettings();
                this.viewEngine.PrintTheWall();
                this.viewEngine.PrintSymbol(playerCar.Row, playerCar.Col, playerCar.Symbol, playerCar.Color);
                playerCar = Controller.MovingTheCar(playerCar);
                enemyCars = Controller.GenerateEnemyCars(enemyCars);
                this.viewEngine.PrintEnemyCars(enemyCars);
                var newList = Controller.MoveEnemyCars(enemyCars);
                enemyCars = newList;
                Thread.Sleep(500);
            }
        }       

        private void ConsoleSettings()
        {
            Console.WindowWidth = 30;
            Console.WindowHeight = 30;
            Console.SetBufferSize(Console.WindowWidth, Console.WindowHeight);
            Console.CursorVisible = false;
        }
    }
}
