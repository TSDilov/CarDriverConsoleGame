namespace CarDriver
{
    public struct Car
    {
        public Car(int row, int col, ConsoleColor color, char symbol)
        {
            this.Row = row;
            this.Col = col;
            this.Color = color;
            this.Symbol = symbol;
        }

        public int Row { get; set; }
        public int Col { get; set; }
        public ConsoleColor Color { get; set; }
        public char Symbol { get; set; }
    }
}
