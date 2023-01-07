using board;
using board.Enums;
using System.Runtime;

namespace chess
{
    internal class ChessMatch
    {
        public Board Board { get; private set; }
        private int Turn;
        private Color ActualPlayer;
        public bool MatchEnded { get; private set; }

        public ChessMatch()
        {
            Board = new Board(8, 8);
            Turn = 1;
            ActualPlayer = Color.White;
            MatchEnded = false;
            StartBoard();
        }

        public void MakeMove(Position origin, Position destination)
        {

            Piece piece = Board.RemovePiece(origin); //stores the piece of the origin position
            piece.IncrementNumberOfMoves();               //increments number of move of such piece
            Board.RemovePiece(destination);         //stores and removes the piece of destination
            Piece capturedPiece = Board.RemovePiece(destination); //takes the piece from destination
            Board.SetPiece(piece, destination);    //sets the piece at origin to its destination
        }

        //puts the chess pieces into the board (manually)
        private void StartBoard()
        {
            //White Pieces
            Board.SetPiece(new Rook(Color.White, Board), new PositionChess('a', 1).ToPosition());
            Board.SetPiece(new Knight(Color.White, Board), new PositionChess('b', 1).ToPosition());
            Board.SetPiece(new Bishop(Color.White, Board), new PositionChess('c', 1).ToPosition());
            Board.SetPiece(new Queen(Color.White, Board), new PositionChess('d', 1).ToPosition());
            Board.SetPiece(new King(Color.White, Board), new PositionChess('e', 1).ToPosition());
            Board.SetPiece(new Bishop(Color.White, Board), new PositionChess('f', 1).ToPosition());
            Board.SetPiece(new Knight(Color.White, Board), new PositionChess('g', 1).ToPosition());
            Board.SetPiece(new Rook(Color.White, Board), new PositionChess('h', 1).ToPosition());

            //black pieces
            Board.SetPiece(new Rook(Color.Black, Board), new PositionChess('a', 8).ToPosition());
            Board.SetPiece(new Knight(Color.Black, Board), new PositionChess('b', 8).ToPosition());
            Board.SetPiece(new Bishop(Color.Black, Board), new PositionChess('c', 8).ToPosition());
            Board.SetPiece(new Queen(Color.Black, Board), new PositionChess('d', 8).ToPosition());
            Board.SetPiece(new King(Color.Black, Board), new PositionChess('e', 8).ToPosition());
            Board.SetPiece(new Bishop(Color.Black, Board), new PositionChess('f', 8).ToPosition());
            Board.SetPiece(new Knight(Color.Black, Board), new PositionChess('g', 8).ToPosition());
            Board.SetPiece(new Rook(Color.Black, Board), new PositionChess('h', 8).ToPosition());


        }



    }
}
