namespace Assessment13.Exception
{
    public class DestinationNotFoundException : IOException
    {
        public DestinationNotFoundException(string message) : base(message) { }
    }
}