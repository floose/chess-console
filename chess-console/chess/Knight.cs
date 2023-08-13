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

        //private method Can Move returns true in the positions the piece can move
        private bool _CanMove(Position position)
        {
            Piece piece = this.Board.GetPiece(position);
            return piece == null || piece.Color != this.Color; //returns true if space is empty or when there's an oponent piece
        }

        public override bool[,] PossibleMoves()
        {
            //creates a matrix of Possible Moves 
            bool[,] moveMatrix = new bool[this.Board.Rows, this.Board.Columns];

            //define auxiliar position
            Position pos = new Position(0, 0);

            //Rows changing - 1
            pos.SetPosition(this.Position.Row - 1, this.Position.Column + 2);
            if (this.Board.PositionIsValid(pos)
                && _CanMove(pos))
            {
                moveMatrix[pos.Row, pos.Column] = true;
            }

            pos.SetPosition(this.Position.Row - 1, this.Position.Column - 2);
            if (this.Board.PositionIsValid(pos)
                && _CanMove(pos))
            {
                moveMatrix[pos.Row, pos.Column] = true;
            }

            //Rows changing -2
            pos.SetPosition(this.Position.Row - 2, this.Position.Column - 1);
            if (this.Board.PositionIsValid(pos)
                && _CanMove(pos))
            {
                moveMatrix[pos.Row, pos.Column] = true;
            }

            pos.SetPosition(this.Position.Row - 2, this.Position.Column + 1);
            if (this.Board.PositionIsValid(pos)
                && _CanMove(pos))
            {
                moveMatrix[pos.Row, pos.Column] = true;
            }

            //Rows changing +1
            pos.SetPosition(this.Position.Row +1, this.Position.Column - 2);
            if (this.Board.PositionIsValid(pos)
                && _CanMove(pos))
            {
                moveMatrix[pos.Row, pos.Column] = true;
            }

            pos.SetPosition(this.Position.Row +1, this.Position.Column +2);
            if (this.Board.PositionIsValid(pos)
                && _CanMove(pos))
            {
                moveMatrix[pos.Row, pos.Column] = true;
            }
            
            //Rows changing +2
            pos.SetPosition(this.Position.Row + 2, this.Position.Column + 1);
            if (this.Board.PositionIsValid(pos)
                && _CanMove(pos))
            {
                moveMatrix[pos.Row, pos.Column] = true;
            }

            pos.SetPosition(this.Position.Row + 2, this.Position.Column - 1);
            if (this.Board.PositionIsValid(pos)
                && _CanMove(pos))
            {
                moveMatrix[pos.Row, pos.Column] = true;
            }

            return moveMatrix;
        }
    }
}
