
using board;
using chess_console;
using chess_console.board.Enums;
using chess;
using exceptions;

PositionChess pos = new PositionChess('b', 5);

Console.WriteLine(pos.ToString());  
Console.WriteLine(pos.ToPosition().ToString());