namespace board
{
    internal class Board
    {
        //the board also has a number of columns and a number of lines
        public int Columns { get; set; }
        public int Rows { get; set; }

        //matrix of pieces
        //it is private, only the board can access the matrix
        private Piece[,] _Pieces;

        //constructor: initiaties a board with a certain number of rows and columns
        //Initiates the matrix of pieces accordingly
        public Board(int rows,int columns)
        {
            Columns = columns;
            Rows = rows;
            _Pieces = new Piece[Rows, Columns];
        }

    }
}
