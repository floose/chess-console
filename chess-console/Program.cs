
using board;
using chess_console;
using board.Enums;
using chess;
using exceptions;

try
{
    ChessMatch match = new ChessMatch();

    while (!match.MatchEnded)
    {
        Console.Clear();
        //prints initial board
        Screen.PrintBoard(match.Board);
        Console.WriteLine();
        Console.Write("Origin: ");
        //reads origin position from the console and transforms into generic position object
        Position origin = Screen.ReadPosition().ToPosition();

        //matrix of possible moves if a piece is in origin position
        bool[,] possibleMoves = match.Board.GetPiece(origin).PossibleMoves();
        Console.Clear();
        //prints the board again highlighting possibe moves with the aid of the bool matrix
        Screen.PrintBoard(match.Board, possibleMoves);

        //writes the house of destination
        Console.Write("Destination: ");
        Position destination = Screen.ReadPosition().ToPosition();
        if (possibleMoves[destination.Row,destination.Column])
        {
            match.MakeMove(origin, destination);
        }
    }

}
catch (BoardException exception)
{
    Console.WriteLine(exception.Message);
}