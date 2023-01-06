using board;
using chess_console.board.Enums;

namespace chess
{
    internal class Rook : Piece
    {

        //constructor gives the board and color to inherited attributes
        public Rook(Color color, Board board) : base(color, board)
        {

        }

        //Override ToString for King. The Notation is "K"
        public override string ToString()
        {
            return "R";
        }
    }
}
