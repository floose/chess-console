using board.Enums;

namespace board
{
    internal abstract class Piece
    {
        //A piece has a position, a color, uses a board as reference and
        //also stores the number of moves it made
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public int NumberOfMoves { get; protected set; }
        public Board Board { get; protected set; }
        public Piece(Color color, Board board)
        {
            Position = null;
            Color = color;
            Board = board;
            NumberOfMoves = 0;
        }

        public void IncrementNumberOfMoves()
        {
            NumberOfMoves++;
        }

        public bool IsTherePossibleMoves()
        {
            //receives the possible moves matrix from the piece
            bool[,] matrix = this.PossibleMoves();
            //searches the matrix for the true squares;
            for (int i = 0; i < this.Board.Rows; i++)
            {
                for (int j = 0; i < this.Board.Columns; i++)
                {
                    if (matrix[i, j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /*
         * Method that moves a piece. It is abstract, so ChessPiece can implement it.
         * Since we don't know how a generic piece might move, we implement in this way.
         */
        public abstract bool[,] PossibleMoves();
    }
}
