﻿using board;
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
    }
}