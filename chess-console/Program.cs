﻿
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
        try
        {
            Console.Clear();

            Screen.PrintMatch(match);
            Console.Write("Origin: ");
            //reads origin position from the console and transforms into generic position object
            Position origin = Screen.ReadPosition().ToPosition();
            match.ValidateOriginPosition(origin);//validates the chosen position

            //matrix of possible moves if a piece is in origin position
            bool[,] possibleMoves = match.Board.GetPiece(origin).PossibleMoves();
            Console.Clear();
            //prints the board again highlighting possibe moves with the aid of the bool matrix
            Screen.PrintBoard(match.Board, possibleMoves);

            //writes the house of destination
            Console.Write("Destination: ");
            Position destination = Screen.ReadPosition().ToPosition();
            match.ValidateDestinationPosition(origin, destination);

            if (possibleMoves[destination.Row, destination.Column])
            {
                //assigns the play, moves the piece and changes the player who plays
                match.MakePlay(origin, destination);
            }
        }
        catch (BoardException e)
        {
            Console.WriteLine(e.Message); 
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
        }
    }
    Console.Clear();
    Screen.PrintMatch(match);

}
catch (BoardException exception)
{
    Console.WriteLine(exception.Message);
}