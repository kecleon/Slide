using LibSlide;
using LibSlide.Assets;
using Slide.Net;

namespace Slide;

public class Menu
{
	private static readonly Web Loader = new();
	
	public static void Create()
	{
		//checks? log setup? load assets?

		Log.Info($"Slidehop {Constants.Version} loading");

		//Assets.Load();
		//var home = await Loader.LoadHome();
		//parse home
		//render menu
		//?
	}
}