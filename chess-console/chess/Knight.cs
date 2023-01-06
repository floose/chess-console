using board;
using board.Enums;

namespace chess
{
    internal class Knight : Piece
    {

        //constructor gives the board and color to inherited attributes
        public Knight(Color color, Board board) : base(color, board)
        {

        }


        public override string ToString()
        {
            return "N";
        }
    }
}
