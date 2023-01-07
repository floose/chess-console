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
            //creates a matrix of possible moves
            bool[,] moveMatrix = new bool[this.Board.Rows, this.Board.Columns];

            //defines a position
            Position position = new Position(0, 0);

            //defines the rule for moving the king piece
            /*
             * this.Board.PositionIsValid - Check if the position is valid in the board
             * _CanMove - check if there is no piece of the same color in the possible movements
             */
            //north
            position.SetPosition(this.Position.Row - 1, this.Position.Column);
            if(this.Board.PositionIsValid(position) && _CanMove(position))
            {
                moveMatrix[position.Row, position.Column] = true;
            }
            //northeast
            position.SetPosition(this.Position.Row - 1, this.Position.Column + 1);
            if (this.Board.PositionIsValid(position) && _CanMove(position))
            {
                moveMatrix[position.Row, position.Column] = true;
            }
            //east
            position.SetPosition(this.Position.Row, this.Position.Column + 1);
            if (this.Board.PositionIsValid(position) && _CanMove(position))
            {
                moveMatrix[position.Row, position.Column] = true;
            }
            //south-easth
            position.SetPosition(this.Position.Row + 1, this.Position.Column + 1);
            if (this.Board.PositionIsValid(position) && _CanMove(position))
            {
                moveMatrix[position.Row, position.Column] = true;
            }
            //south
            position.SetPosition(this.Position.Row + 1, this.Position.Column);
            if (this.Board.PositionIsValid(position) && _CanMove(position))
            {
                moveMatrix[position.Row, position.Column] = true;
            }
            //south-west
            position.SetPosition(this.Position.Row + 1, this.Position.Column - 1);
            if (this.Board.PositionIsValid(position) && _CanMove(position))
            {
                moveMatrix[position.Row, position.Column] = true;
            }
            //west
            position.SetPosition(this.Position.Row, this.Position.Column - 1);
            if (this.Board.PositionIsValid(position) && _CanMove(position))
            {
                moveMatrix[position.Row, position.Column] = true;
            }
            //north-west
            position.SetPosition(this.Position.Row - 1, this.Position.Column - 1);
            if (this.Board.PositionIsValid(position) && _CanMove(position))
            {
                moveMatrix[position.Row, position.Column] = true;
            }
            //returns the moveMatrix of possible moves
            return moveMatrix;
        }
    }
}
