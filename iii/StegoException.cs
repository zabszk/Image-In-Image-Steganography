namespace iii;

public class StegoException : Exception
{
	public StegoException() { }

	public StegoException(string message)
		: base(message) { }

	public StegoException(string message, Exception inner)
		: base(message, inner) { }
}