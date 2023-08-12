using System.Collections.Generic;
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

            //NE
            pos.SetPosition(this.Position.Row+1,this.Position.Column+1);
            /* Sweeps the entire board in northeast
                While the positions is valid and the piece can move,
                will set true to the moveMatrix.
            */
            while (this.Board.PositionIsValid(pos) && _CanMove(pos))
            {
                moveMatrix[pos.Row, pos.Column] = true;
                if (this.Board.GetPiece(pos) != null
                    && this.Board.GetPiece(pos).Color != this.Color)
                {
                    break;
                }
                pos.SetPosition(pos.Row + 1, pos.Column + 1);

            }

            //NE
            pos.SetPosition(this.Position.Row-1,this.Position.Column+1);
            while (this.Board.PositionIsValid(pos) && _CanMove(pos))
            {
                moveMatrix[pos.Row, pos.Column] = true;
                if (this.Board.GetPiece(pos) != null
                    && this.Board.GetPiece(pos).Color != this.Color)
                {
                    break;
                }
                pos.SetPosition(pos.Row-1,pos.Column+1);
            }

            //SW
            pos.SetPosition(this.Position.Row-1,this.Position.Column-1);
            while (this.Board.PositionIsValid(pos) && _CanMove(pos))
            {
                moveMatrix[pos.Row, pos.Column] = true;
                if (this.Board.GetPiece(pos) != null
                    && this.Board.GetPiece(pos).Color != this.Color)
                {
                    break;
                }
                pos.SetPosition(pos.Row-1,pos.Column-1);
            }

            //SE
            pos.SetPosition(this.Position.Row+1,this.Position.Column-1);
            while (this.Board.PositionIsValid(pos) && _CanMove(pos))
            {
                moveMatrix[pos.Row, pos.Column] = true;
                if (this.Board.GetPiece(pos) != null
                    && this.Board.GetPiece(pos).Color != this.Color)
                {
                    break;
                }
                pos.SetPosition(pos.Row+1,pos.Column-1);
            }


            return moveMatrix;
        }
    }
}
