using exceptions;
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

        //### constructor: initiaties a board with a certain number of rows and columns
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

        //overload method, now receiving Position as argument to return a piece of the board
        public Piece GetPiece(Position position)
        {
            return _Pieces[position.Row, position.Column];
        }

        //check if there is a piece on a position
        public bool CheckPiece(Position position)
        {
            ValidatePosition(position); //checks if position is valid
            return GetPiece(position) != null;
        }

        //adds a Piece P to a given position of the board
        public void SetPiece(Piece piece, Position position)
        {
            if(CheckPiece(position)) //if CheckPiece returns true, throws the exception
            {
                throw new BoardException("There is already a piece in this position.");
            }

            _Pieces[position.Row, position.Column] = piece; 
            piece.Position = position; //updates piece position
        }

        //method to check if a position is valid on the board
        public bool PositionIsValid(Position position)
        {
            //if Rows & Columns are negative or greated than this.Rows and this.Columns, return false
            if(position.Row < 0 || position.Row>= this.Rows || position.Column < 0 || position.Column >= this.Columns)
            {
                return false;
            }
            else
                return true;
        }

        //throws an exception if position is invalid.
        public void ValidatePosition(Position position) 
        { 
            if(!PositionIsValid(position))
            {
                throw new BoardException("Invalid Position!");
            }
        }
    }
}
