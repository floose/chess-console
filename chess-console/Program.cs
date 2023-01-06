
using board;
using chess_console;
using board.Enums;
using chess;
using exceptions;

ChessMatch match = new ChessMatch();

Screen.PrintBoard(match.getBoard());

match.makeMove(new Position(0, 0), new Position(2, 3));

Console.WriteLine();

Screen.PrintBoard(match.getBoard());
