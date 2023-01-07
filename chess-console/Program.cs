
using board;
using chess_console;
using board.Enums;
using chess;
using exceptions;

try
{
    ChessMatch match = new ChessMatch();

    while(!match.MatchEnded)
    {
        Console.Clear();
        Screen.PrintBoard(match.Board);

        Console.Write("Origin: ");
        Position origin = Screen.ReadPosition().ToPosition();
        Console.Write("Destination: ");
        Position destination = Screen.ReadPosition().ToPosition();

        match.makeMove(origin, destination); 
    }

}
catch(BoardException exception)
{
    Console.WriteLine(exception.Message);
}