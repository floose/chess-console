using board;
using board.Enums;

namespace chess
{
    internal class Rook : Piece
    {

        //constructor gives the board and color to inherited attributes
        public Rook(Color color, Board board) : base(color, board)
        {

        }
        public override string ToString()
        {
            return "R";
        }

        //private method Can Move returns true in the positions the piece can move
        private bool _CanMove(Position position)
        {
            Piece piece = this.Board.GetPiece(position);
            return piece == null || piece.Color != this.Color; //returns true if space is empty or when there's an oponent piece
        }

        public override bool[,] PossibleMoves()
        {
            //creates a matrix of possible moves
            bool[,] moveMatrix = new bool[this.Board.Rows, this.Board.Columns];

            //defines an auxiliary position
            Position position = new Position(0, 0);

            //defines the rule for moving the rook piece
            /*
             * this.Board.PositionIsValid - Check if the position is valid in the board
             * _CanMove - check if there is no piece of the same color in the possible movements
             */

            //north
            position.SetPosition(this.Position.Row - 1, this.Position.Column );
            //loop for the rook movement.
            //while the position of the board is valid AND the piece can move (there's no piece of the same color)
            while(this.Board.PositionIsValid(position) && _CanMove(position))
            {
                //assings true o moveMatrix
                moveMatrix[position.Row, position.Column] = true;
                //if there is no piece at the position AND theres is an enemy piece, breaks the loop
                if(this.Board.GetPiece(position) != null && this.Board.GetPiece(position).Color != this.Color)
                {
                    break;
                }
                //loop variable
                position.Row = position.Row - 1;
            }

            //south
            position.SetPosition(this.Position.Row + 1, this.Position.Column);
            //loop for the rook movement.
            //while the position of the board is valid AND the piece can move (there's no piece of the same color)
            while (this.Board.PositionIsValid(position) && _CanMove(position))
            {
                //assings true o moveMatrix
                moveMatrix[position.Row, position.Column] = true;
                //if there is no piece at the position AND theres is an enemy piece, breaks the loop
                if (this.Board.GetPiece(position) != null && this.Board.GetPiece(position).Color != this.Color)
                {
                    break;
                }
                //loop variable
                position.Row = position.Row + 1;
            }

            //east
            position.SetPosition(this.Position.Row, this.Position.Column+1);
            //loop for the rook movement.
            //while the position of the board is valid AND the piece can move (there's no piece of the same color)
            while (this.Board.PositionIsValid(position) && _CanMove(position))
            {
                //assings true o moveMatrix
                moveMatrix[position.Row, position.Column] = true;
                //if there is no piece at the position AND theres is an enemy piece, breaks the loop
                if (this.Board.GetPiece(position) != null && this.Board.GetPiece(position).Color != this.Color)
                {
                    break;
                }
                //loop variable
                position.Column = position.Column + 1;
            }

            //west
            position.SetPosition(this.Position.Row, this.Position.Column - 1);
            //loop for the rook movement.
            //while the position of the board is valid AND the piece can move (there's no piece of the same color)
            while (this.Board.PositionIsValid(position) && _CanMove(position))
            {
                //assings true o moveMatrix
                moveMatrix[position.Row, position.Column] = true;
                //if there is no piece at the position AND theres is an enemy piece, breaks the loop
                if (this.Board.GetPiece(position) != null && this.Board.GetPiece(position).Color != this.Color)
                {
                    break;
                }
                //loop variable
                position.Column = position.Column - 1;
            }
            return moveMatrix;
        }
    }
}
