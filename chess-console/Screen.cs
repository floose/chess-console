using board;

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
                        Console.Write(board.GetPiece(i, j) + " ");
                    }

                }
                Console.WriteLine(); //makes a new line at the console for another row
            }
        }
    }
}
