namespace exceptions
{
    internal class BoardException : Exception
    {
        //constructor only delivers the message to the Exception class of C#
        public BoardException(string message) : base(message) 
        { 
        }

    }
}
