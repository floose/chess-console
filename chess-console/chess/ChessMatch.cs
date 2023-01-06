using board;
using board.Enums;

namespace chess
{
    internal class ChessMatch
    {
        private Board ChessBoard;
        private int Turn;
        private Color ActualPlayer;

        public ChessMatch()
        {
            ChessBoard = new Board(8, 8);
            Turn = 1;
            ActualPlayer = Color.White;
            StartBoard();
        }

        public void makeMove(Position origin, Position destination)
        {
            
            Piece piece = ChessBoard.RemovePiece(origin); //stores the piece of the origin position
            piece.IncrementNumberOfMoves();               //increments number of move of such piece
            ChessBoard.RemovePiece(destination);         //stores and removes the piece of destination
            ChessBoard.SetPiece(piece, destination);    //sets the piece at origin to its destination
        }

        private void StartBoard()
        {
            ChessBoard.SetPiece(new Rook(Color.White, ChessBoard), new Position(0, 0));
        }

        public Board getBoard()
        {
            return ChessBoard;
        }

    }
}
