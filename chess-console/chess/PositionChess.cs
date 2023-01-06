
using board;

namespace chess
{
    internal class PositionChess
    {
        public char Column { get; set; }
        public int Row { get; set; }    
    
        //constructor
        //receives the position according to chess board rules
        public PositionChess(char column, int row)
        {
            Column = column;
            Row = row;
        }

        //converts position chess to generic position to use in Board class
        public Position ToPosition()
        {
            //Description: Offsets the positon with both char and int variables
            //arithmetics works with char since the alfabet is internally an int number that increments by 1
            return new Position(8 - Row, Column - 'a');
        }

        //overrides toString
        public override string ToString()
        {
            return Column.ToString() + Row.ToString();
        }

    }
}
