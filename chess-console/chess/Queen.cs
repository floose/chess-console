using board;
using board.Enums;

namespace chess
{
    internal class Queen : Piece
    {

        //constructor gives the board and color to inherited attributes
        public Queen(Color color, Board board) : base(color, board)
        {

        }

        
        public override string ToString()
        {
            return "Q";
        }

        public override bool[,] PossibleMoves()
        {
            return new bool[1, 1];
        }
    }
}
