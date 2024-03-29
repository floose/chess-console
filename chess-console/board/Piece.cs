﻿using board.Enums;
using exceptions;

namespace board
{
    internal abstract class Piece
    {
        //A piece has a position, a color, uses a board as reference and
        //also stores the number of moves it made
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public int NumberOfMoves { get; protected set; }
        public Board Board { get; protected set; }
        public Piece(Color color, Board board)
        {
            Position = null;
            Color = color;
            Board = board;
            NumberOfMoves = 0;
        }

        public void IncrementNumberOfMoves()
        {
            this.NumberOfMoves++;
        }

        public void DecrementNumberOfMoves()
        {
            int temp = this.NumberOfMoves - 1;
            if(temp < 0)
            {
                throw new BoardException("You cannot decrement moves from a piece that never moved before!");
            }

            this.NumberOfMoves--;
        }

        //verifies possible moves
        public bool IsTherePossibleMoves()
        {
            //receives the possible moves matrix from the piece
            bool[,] matrix = this.PossibleMoves();
            //searches the matrix for the true squares;
            for (int i = 0; i < this.Board.Rows; i++)
            {
                for (int j = 0; j < this.Board.Columns; j++)
                {
                    if (matrix[i, j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        //returns true or false to the position of possible moves in the following position
        //for the abstract method matrix
        public bool CanMove(Position position)
        {
            return this.PossibleMoves()[position.Row, position.Column];
        }
        /*
         * Method that moves a piece. It is abstract, so ChessPiece can implement it.
         * Since we don't know how a generic piece might move, we implement in this way.
         */
        public abstract bool[,] PossibleMoves();
    }
}
