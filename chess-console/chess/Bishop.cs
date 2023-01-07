using board;
using board.Enums;

namespace chess
{
    internal class Bishop : Piece
    {

        //constructor gives the board and color to inherited attributes
        public Bishop(Color color, Board board) : base(color, board)
        {

        }
        public override string ToString()
        {
            return "B";
        }

        public override bool[,] PossibleMoves()
        {
            return new bool[1, 1];
        }
    }
}
