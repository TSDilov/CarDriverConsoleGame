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
            var lifes = 5;
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
                var newListOfEnemyCarsPlusPlayerLives = Controller.MoveEnemyCars(enemyCars, playerCar, lifes);
                enemyCars = newListOfEnemyCarsPlusPlayerLives.Item1;
                var currentLifes = newListOfEnemyCarsPlusPlayerLives.Item2;
                if (currentLifes == 0)
                {
                    this.viewEngine.PrintGameOver();
                    return;
                }
                else
                {
                    if (lifes != currentLifes)
                    {
                        lifes = currentLifes;
                        this.viewEngine.PrintTheGameInfo(lifes, score, true);
                    }
                    else
                    {
                        this.viewEngine.PrintTheGameInfo(lifes, score);
                    }
                }
                
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
