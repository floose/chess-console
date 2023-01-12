using board;
using board.Enums;
using exceptions;
using System.Net.Http.Headers;

namespace chess
{
    internal class ChessMatch
    {
        public Board Board { get; private set; }
        public int Turn { get; private set; }
        public Color ActualPlayer { get; private set; }
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

        //updated method to make a move of a piece, incrementing the turn and changing the player
        public void MakePlay(Position origin, Position destination)
        {
            MakeMove(origin, destination);
            this.Turn++;
            _ChangePlayer();
        }

        //validates the chosen square to move a piece
        public void ValidateOriginPosition(Position position)
        {
            if (this.Board.GetPiece(position) == null) //throws exception if there is no piece
            {
                throw new BoardException("There is no piece at the chosen square.");
            }
            if (this.ActualPlayer != this.Board.GetPiece(position).Color) //throws exception if the piece if the enemy's
            {
                throw new BoardException("Can't move opponent's pieces!");
            }
            if (!this.Board.GetPiece(position).IsTherePossibleMoves()) //throws exception if the piece can't move
            {
                throw new BoardException("Can't move the piece. No possible moves.");
            }
        }

        //valitades the destination square w.r.t to origin
        //if invalid, will throw an exception on the BoardException
        public void ValidateDestinationPosition(Position origin, Position destination)
        {
            //if the CANNOT move to the destination, throws an exception
            if (!this.Board.GetPiece(origin).CanMove(destination))
            {
                throw new BoardException("Invalid Destination!");
            }
        }


        //changes the player who plays
        private void _ChangePlayer()
        {
            if (ActualPlayer == Color.White)
            {
                this.ActualPlayer = Color.Black;
            }
            else
            {
                this.ActualPlayer = Color.White;
            }

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
