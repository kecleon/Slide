namespace Slide;

public class Log
{
	private static string Now => DateTime.Now.ToString("HH:mm:ss");

	public static void Debug(string input)
	{
		Console.WriteLine($"[D|{Now}] {input}");
	}

	public static void Info(string input)
	{
		Console.WriteLine($"[I|{Now}] {input}");
	}

	public static void Error(string input)
	{
		Console.WriteLine($"[E|{Now}] {input}");
	}
}