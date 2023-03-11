using System.Runtime.CompilerServices;

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
            var score = 0;
            var lives = 5;
            double sleepTime = 500;

            while (true)
            {
                Console.Clear();
                this.ConsoleSettings();
                this.viewEngine.PrintTheWall();
                this.viewEngine.PrintSymbol(playerCar.Row, playerCar.Col, playerCar.Symbol, playerCar.Color);
                playerCar = Controller.MovingTheCar(playerCar);
                enemyCars = Controller.GenerateEnemyCars(enemyCars);
                this.viewEngine.PrintEnemyCars(enemyCars);
                var newListOfEnemyCarsPlusPlayerLives = Controller.MoveEnemyCars(enemyCars, playerCar, lives);
                enemyCars = newListOfEnemyCarsPlusPlayerLives.Item1;
                lives = newListOfEnemyCarsPlusPlayerLives.Item2;
                if (lives == 0)
                {
                    this.viewEngine.PrintGameOver();
                    return;
                }

                this.viewEngine.PrintTheGameInfo(lives, score);
                sleepTime -= 0.01;
                score++;
                Thread.Sleep((int)sleepTime);
            }
        }       

        private void ConsoleSettings()
        {
            Console.WindowWidth = 100;
            Console.WindowHeight = 30;
            Console.SetBufferSize(Console.WindowWidth, Console.WindowHeight);
            Console.CursorVisible = false;
        }
    }
}
