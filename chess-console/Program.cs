
using board;
using chess_console;
using board.Enums;
using chess;
using exceptions;

Board b = new Board(8, 8);

b.SetPiece(new Rook(Color.White, b), new Position(3, 5));
Screen.PrintBoard(b);

Console.WriteLine();

Piece aux = b.RemovePiece(new Position(3, 5));

Console.WriteLine("Removed Piece is " + aux.ToString());
Screen.PrintBoard(b);