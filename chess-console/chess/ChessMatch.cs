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

        public bool checkFlag { get; private set; }

        public ChessMatch()
        {
            Board = new Board(8, 8);
            Turn = 1;
            ActualPlayer = Color.White;
            MatchEnded = false;
            checkFlag = false;
            pieces = new HashSet<Piece>(); //this stores ALL the pieces of the board
            capturedPieces = new HashSet<Piece>(); //this stores the captures pieces
            StartBoard();
        }

        public Piece MakeMove(Position origin, Position destination)
        {

            Piece piece = Board.RemovePiece(origin); //stores the piece of the origin position
            piece.IncrementNumberOfMoves();               //increments number of move of such piece
            //Board.RemovePiece(destination);         //stores and removes the piece of destination
            Piece capturedPiece = Board.RemovePiece(destination); //takes the piece from destination
            Board.SetPiece(piece, destination);    //sets the piece at origin to its destination

            //if there's a piece in the destination, capture it then add to hashset of captured pieces
            if (capturedPiece != null)
            {
                //the captured piece is added to the captured pieces hashset
                capturedPieces.Add(capturedPiece);
            }
            return capturedPiece;
        }

        public void UndoMove(Position origin, Position destination, Piece capturedPiece)
        {
            Piece piece = this.Board.RemovePiece(destination);
            piece.DecrementNumberOfMoves();

            if (capturedPiece != null) //if there is a capture piece
            {
                this.Board.SetPiece(capturedPiece, destination); //sets captured piece back to position
                this.capturedPieces.Remove(capturedPiece); //removes it from the set of captured pieces
            }
            this.Board.SetPiece(piece, origin); //sets the piece back to the board
        }

        //returns the captured pieces of the given color
        public HashSet<Piece> CapturedPieces(Color color)
        {
            HashSet<Piece> auxiliarSet = new HashSet<Piece>();

            //for each piece in captured pieces, adds it to auxiliar hashSet
            foreach (Piece piece in capturedPieces)
            {
                if (piece.Color == color)
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
            Piece capturedPiece = MakeMove(origin, destination);

            if (IsKingInCheck(ActualPlayer))
            {
                UndoMove(origin, destination, capturedPiece);
                throw new BoardException("You cannot put yourself in check!");
            }

            if (IsKingInCheck(_OponentColor(ActualPlayer)))
            {
                checkFlag = true;
            }
            else
            {
                checkFlag = false;
            }

            if (TestCheckMate(_OponentColor(ActualPlayer)))
            {
                MatchEnded = true;
            }
            else
            {

                this.Turn++;
                _ChangePlayer();
            }

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

        private Piece _GetKing(Color color)
        {
            foreach (Piece x in PiecesAtPlay(color))
            {
                if (x is King) //peca eh uma superclasse. Rei eh subclasse
                {
                    return x;
                }
            }
            return null; //this is forbidden. But its there for a reason
        }

        public bool IsKingInCheck(Color color)
        {
            Piece king = _GetKing(color);

            if (king == null) //throws exception if there's no king
            {
                throw new BoardException("There is no king of color" + color + "in the board!");
            }

            foreach (Piece x in PiecesAtPlay(_OponentColor(color))) //for each piece at play of the opponent color
            {
                if (x.IsTherePossibleMoves()) //check all pieces with possible moves
                {
                    bool[,] mat = x.PossibleMoves(); //get matrix of possible moves
                    if (mat[king.Position.Row, king.Position.Column]) //if there is a possible move at the king's positions
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool TestCheckMate(Color color)
        {
            if (!IsKingInCheck(color))
            {
                return false;
            }
            foreach (Piece x in PiecesAtPlay(color))
            {
                //gets possible moves of the pieces at play
                bool[,] mat = x.PossibleMoves();
                { }

                //sweeps the matrix of possible moves
                for (int i = 0; i < this.Board.Rows; i++)
                {
                    for (int j = 0; j < this.Board.Columns; j++)
                    {

                        if (mat[i, j])
                        {
                            Position destination = new Position(i, j);
                            //tries to execute the movement of the piece
                            Piece capturedPiece = MakeMove(x.Position, destination);
                            bool checkFlag = IsKingInCheck(color);
                            UndoMove(x.Position, destination, capturedPiece);
                            if (!checkFlag)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }

        private Color _OponentColor(Color color)
        {
            if (color == Color.White)
            {
                return Color.Black;
            }
            else
            {
                return Color.White;
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
            PlaceNewPiece('b', 1, new Knight(Color.White, this.Board));
            PlaceNewPiece('c', 1, new Bishop(Color.White, this.Board));
            PlaceNewPiece('d', 1, new Queen(Color.White, this.Board));
            PlaceNewPiece('e', 1, new King(Color.White, this.Board));
            PlaceNewPiece('f', 1, new Bishop(Color.White, this.Board));
            PlaceNewPiece('g', 1, new Knight(Color.White, this.Board));
            PlaceNewPiece('h', 1, new Rook(Color.White, this.Board));
            //White Pawns
            PlaceNewPiece('a', 2, new Pawn(Color.White, this.Board));
            PlaceNewPiece('b', 2, new Pawn(Color.White, this.Board));
            PlaceNewPiece('c', 2, new Pawn(Color.White, this.Board));
            PlaceNewPiece('d', 2, new Pawn(Color.White, this.Board));
            PlaceNewPiece('e', 2, new Pawn(Color.White, this.Board));
            PlaceNewPiece('f', 2, new Pawn(Color.White, this.Board));
            PlaceNewPiece('g', 2, new Pawn(Color.White, this.Board));
            PlaceNewPiece('h', 2, new Pawn(Color.White, this.Board));


            //Back Pieces
            PlaceNewPiece('a', 8, new Rook(Color.Black, this.Board));
            PlaceNewPiece('b', 8, new Knight(Color.Black, this.Board));
            PlaceNewPiece('c', 8, new Bishop(Color.Black, this.Board));
            PlaceNewPiece('d', 8, new Queen(Color.Black, this.Board));
            PlaceNewPiece('e', 8, new King(Color.Black, this.Board));
            PlaceNewPiece('f', 8, new Bishop(Color.Black, this.Board));
            PlaceNewPiece('g', 8, new Knight(Color.Black, this.Board));
            PlaceNewPiece('h', 8, new Rook(Color.Black, this.Board));
            //Black Pawns
            PlaceNewPiece('a', 7, new Pawn(Color.Black, this.Board));
            PlaceNewPiece('b', 7, new Pawn(Color.Black, this.Board));
            PlaceNewPiece('c', 7, new Pawn(Color.Black, this.Board));
            PlaceNewPiece('d', 7, new Pawn(Color.Black, this.Board));
            PlaceNewPiece('e', 7, new Pawn(Color.Black, this.Board));
            PlaceNewPiece('f', 7, new Pawn(Color.Black, this.Board));
            PlaceNewPiece('g', 7, new Pawn(Color.Black, this.Board));
            PlaceNewPiece('h', 7, new Pawn(Color.Black, this.Board));




        }


    }
}
