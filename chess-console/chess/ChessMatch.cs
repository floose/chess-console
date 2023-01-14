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
        private HashSet<Piece> pieces;
        private HashSet<Piece> capturedPieces;
        
        public ChessMatch()
        {
            Board = new Board(8, 8);
            Turn = 1;
            ActualPlayer = Color.White;
            MatchEnded = false;
            pieces = new HashSet<Piece>(); //this stores ALL the pieces of the board
            capturedPieces = new HashSet<Piece>(); //this stores the captures pieces
            StartBoard();
        }

        public void MakeMove(Position origin, Position destination)
        {

            Piece piece = Board.RemovePiece(origin); //stores the piece of the origin position
            piece.IncrementNumberOfMoves();               //increments number of move of such piece
            //Board.RemovePiece(destination);         //stores and removes the piece of destination
            Piece capturedPiece = Board.RemovePiece(destination); //takes the piece from destination
            Board.SetPiece(piece, destination);    //sets the piece at origin to its destination

            //if there's a piece in the destination, capture it then add to hashset of captured pieces
            if( capturedPiece != null ) 
            { 
                //the captured pieces are mixed
                capturedPieces.Add(capturedPiece);
            }
        }

        //returns the captured pieces of the given color
        public HashSet<Piece> CapturedPieces(Color color) {
            HashSet<Piece> auxiliarSet = new HashSet<Piece>();
            
            //for each piece in captured pieces, adds it to auxiliar hashSet
            foreach(Piece piece in capturedPieces)
            {
                if( piece.Color == color)
                {
                    auxiliarSet.Add(piece);
                }
            }
            return auxiliarSet; 
        }

        public HashSet<Piece> PiecesAtPlay(Color color)
        {
            HashSet<Piece> auxiliarSet = new HashSet<Piece>();

            //for each piece in captured pieces, adds it to auxiliar hashSet
            foreach (Piece piece in pieces)
            {
                if (piece.Color == color)
                {
                    auxiliarSet.Add(piece);
                }
            }

            auxiliarSet.ExceptWith(CapturedPieces(color)); //removes the captures pieces
            return auxiliarSet; //returns the set without the captured pieces
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

        //method to place a new piece in the board and populate the hashset
        public void PlaceNewPiece(char column, int row, Piece piece)
        {
            this.Board.SetPiece(piece, new PositionChess(column, row).ToPosition());
            pieces.Add(piece);
        }
        private void StartBoard()
        {
            //White Pieces
            PlaceNewPiece('a', 1, new Rook(Color.White, this.Board));
            PlaceNewPiece('c', 1, new Rook(Color.White, this.Board));
            PlaceNewPiece('d', 1, new Rook(Color.White, this.Board));
            PlaceNewPiece('e', 1, new Rook(Color.White, this.Board));
            PlaceNewPiece('a', 2, new Rook(Color.White, this.Board));
            PlaceNewPiece('c', 2, new Rook(Color.White, this.Board));
            PlaceNewPiece('d', 2, new Rook(Color.White, this.Board));
            PlaceNewPiece('e', 2, new Rook(Color.White, this.Board));
            PlaceNewPiece('e', 3, new Rook(Color.White, this.Board));
            PlaceNewPiece('e', 4, new King(Color.White, this.Board));

            //Back Pieces
            PlaceNewPiece('a', 8, new Rook(Color.Black, this.Board));
            PlaceNewPiece('c', 8, new Rook(Color.Black, this.Board));
            PlaceNewPiece('d', 8, new Rook(Color.Black, this.Board));
            PlaceNewPiece('e', 8, new Rook(Color.Black, this.Board));



        }



    }
}
