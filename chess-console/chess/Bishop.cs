using board;
using chess_console.board.Enums;

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
    }
}
