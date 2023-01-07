using board;
using board.Enums;
using chess;
using System.Runtime.CompilerServices;

namespace chess_console
{
    internal class Screen
    {
        //displays the board at the console via matrix methods
        public static void PrintBoard(Board board)
        {
            //drives the rows and lines of the board
            for (int i = 0; i < board.Rows; i++)
            {
                Console.Write(8 - i + " ");

                for (int j = 0; j < board.Columns; j++)
                {

                    PrintPiece(board.GetPiece(i, j));
                }
                Console.WriteLine(); //makes a new line at the console for another row
            }
            Console.WriteLine("  a b c d e f g h");
        }

        //print board method that shows possible movements of a piece
        public static void PrintBoard(Board board, bool[,] possibleMoves)
        {
            ConsoleColor originalBackground = Console.BackgroundColor;
            ConsoleColor alteredBackground = ConsoleColor.DarkGray;

            //drives the rows and lines of the board
            for (int i = 0; i < board.Rows; i++)
            {
                Console.Write(8 - i + " ");

                for (int j = 0; j < board.Columns; j++)
                {
                    if (possibleMoves[i, j])
                    {
                        Console.BackgroundColor = alteredBackground;
                    }
                    else
                    {
                        Console.BackgroundColor = originalBackground;
                    }
                    PrintPiece(board.GetPiece(i, j));
                    board.GetPiece(i, j);
                } 

                Console.WriteLine(); //makes a new line at the console for another row
            }
            Console.WriteLine("  a b c d e f g h");
            Console.BackgroundColor = originalBackground;
        }

        public static void PrintPiece(Piece piece)
        {
            if (piece == null)
            {
                Console.Write("- ");
            }
            else
            {
                if (piece.Color == Color.White) // White pieces are displayed as Yellow, so the white spots are null spots 
                {
                    ConsoleColor aux = Console.ForegroundColor; //gets the standar color of console
                    Console.ForegroundColor = ConsoleColor.Yellow; //changes foreground to yellow
                    Console.Write(piece);  // prints the piece
                    Console.ForegroundColor = aux; //changes console back to original color
                }
                else
                if (piece.Color == Color.Red || piece.Color == Color.Black) //if Red or Black, I choose Red to display black pieces
                {

                    ConsoleColor aux = Console.ForegroundColor; //gets the standar color of console
                    Console.ForegroundColor = ConsoleColor.Red; //changes foreground to yellow
                    Console.Write(piece);  // prints the piece
                    Console.ForegroundColor = aux; //changes console back to original color
                }
                else
                {
                    Console.Write(piece);
                }
                Console.Write(" ");
            }
        }

        public static PositionChess ReadPosition()
        {
            String s = Console.ReadLine();
            char column = s[0];
            int row = int.Parse(s[1] + "");
            return new PositionChess(column, row);

        }

    }
}
