
using board;
using chess_console;
using chess_console.board.Enums;
using chess;

Board board = new Board(8, 8);
board.SetPiece(new Rook(Color.Black,board) , new Position(4, 4));

Screen.PrintBoard(board);