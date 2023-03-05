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

            while (true)
            {
                Console.Clear();
                this.ConsoleSettings();
                this.viewEngine.PrintTheWall();
                this.viewEngine.PrintSymbol(playerCar.Row, playerCar.Col, playerCar.Symbol, playerCar.Color);
                playerCar = Controller.MovingTheCar(playerCar);

                Thread.Sleep(50);
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
