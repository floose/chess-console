namespace board
{
    internal class Position
    {
        //referred as a line and a row description
        public int Column { get; set; }
        public int Row { get; set; }

        //constructor
        public Position(int row, int column)
        {
            Column = column;
            Row = row;
        }

        //shows in console the current position
        public override string ToString()
        {
            return Row + ", " + Column;
        }

        public void SetPosition(int row, int column)
        {
            this.Row = row;
            this.Column = column;
        }
    }
}
