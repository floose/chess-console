using board;
using board.Enums;

namespace chess
{
    internal class Pawn : Piece
    {

        //constructor gives the board and color to inherited attributes
        public Pawn(Color color, Board board) : base(color, board)
        {

        }

        
        public override string ToString()
        {
            return "P";
        }

        public override bool[,] PossibleMoves()
        {
            return new bool[1, 1];
        }
    }
}
