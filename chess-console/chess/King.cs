using board;
using board.Enums;

namespace chess
{
    internal class King : Piece 
    {

        //constructor gives the board and color to inherited attributes
        public King(Color color, Board board) : base(color, board)
        {
            
        }

        //Override ToString for King. The Notation is "K"
        public override string ToString()
        {
            return "K";
        }
    }
}
