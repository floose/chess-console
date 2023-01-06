using board;
using board.Enums;

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
                    //if the piece is NULL prints a dashed line
                    if (board.GetPiece(i, j) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        //prints the piece present at a certain table
                        //Console.Write(board.GetPiece(i, j) + " ");
                        PrintPiece(board.GetPiece(i, j));
                        Console.Write(" ");
                    }

                }
                Console.WriteLine(); //makes a new line at the console for another row
            }
            Console.WriteLine("  a b c d e f g h");
        }
    
        public static void PrintPiece(Piece piece) 
        {
            if(piece.Color == Color.White) // White pieces are displayed as Yellow, so the white spots are null spots 
            {
                ConsoleColor aux = Console.ForegroundColor; //gets the standar color of console
                Console.ForegroundColor = ConsoleColor.Yellow; //changes foreground to yellow
                Console.Write(piece);  // prints the piece
                Console.ForegroundColor = aux; //changes console back to original color
            }
            else
            if(piece.Color == Color.Red || piece.Color == Color.Black) //if Red or Black, I choose Red to display black pieces
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
        }
    }
}
