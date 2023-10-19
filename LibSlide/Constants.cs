namespace LibSlide;

public class Constants
{
	public const int MainPort = 25971;
	
	private const string VersionNumber = "0.0.0";
#if DEBUG
	public const string Version = $"{VersionNumber}-debug";
	public const string EnvUrl = "127.0.0.1";
#else
	public const string Version = $"{VersionNumber}-release";
	public const string EnvUrl = "slidehop.gg";
#endif
}