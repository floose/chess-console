using board;
using board.Enums;
using System.Numerics;

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

        //private method Can Move returns true in the positions the king can move
        private bool _CanMove(Position position)
        {
            Piece piece = this.Board.GetPiece(position);
            return piece == null || piece.Color != this.Color; //returns true if space is empty or when there's an oponent piece
        }

        public override bool[,] PossibleMoves()
        {
            bool[,] moveMatrix = new bool[this.Board.Rows, this.Board.Columns];

            Position position = new Position(0, 0);

            //position above
            position.SetPosition(this.Position.Row - 1, this.Position.Column);
            if(this.Board.PositionIsValid(position) && _CanMove(position))
            {
                moveMatrix[position.Row, position.Column] = true;
            }
        }
    }
}
