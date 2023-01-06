namespace board
{
    //class that creates a board in the console 
    // with a defined size given by Rows and Columns
    internal class Board
    {
        //the board also has a number of columns and a number of lines
        public int Columns { get; set; }
        public int Rows { get; set; }

        //matrix of pieces
        //it is private, only the board can access the matrix
        private Piece[,] _Pieces;

        //constructor: initiaties a board with a certain number of rows and columns
        //Initiates the matrix of pieces accordingly.
        //C# automatically initiates all positions with NULL
        public Board(int rows,int columns)
        {
            Columns = columns;
            Rows = rows;
            _Pieces = new Piece[Rows, Columns];
        }

        //get a certain piece at the board
        public Piece GetPiece(int row, int column)
        {
            return _Pieces[row, column];
        }

        //adds a Piece P to a given position of the board
        public void SetPiece(Piece piece, Position position)
        {
            _Pieces[position.Row, position.Column] = piece; 
            piece.Position = position; //updates piece position
        }

    }
}
