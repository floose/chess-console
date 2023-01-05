using chess_console.board.Enums;

namespace board
{
    internal class Piece
    {
        //A piece has a position, a color, uses a board as reference and
        //also stores the number of moves it made
        public Position Position { get; set; }
        public Color Color { get; protected set; }

        public int NumberOfMoves { get; protected set; }

        public Board Board { get; protected set; }

        public Piece(Position position, Color color, Board board)
        {
            Position = position;
            Color = color;
            Board = board;
            NumberOfMoves = 0;
        }
    }
}
