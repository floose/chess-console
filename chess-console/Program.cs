
using board;
using chess_console;
using board.Enums;
using chess;
using exceptions;

Board b = new Board(8, 8);

b.SetPiece(new Rook(Color.White, b), new Position(3, 5));
b.SetPiece(new King(Color.Black,b), new Position(5, 5));

Screen.PrintBoard(b);