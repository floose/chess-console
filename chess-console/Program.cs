
using board;
using chess_console;
using board.Enums;
using chess;
using exceptions;

try
{
    ChessMatch match = new ChessMatch();
    Screen.PrintBoard(match.Board);

}
catch(BoardException exception)
{
    Console.WriteLine(exception.Message);
}