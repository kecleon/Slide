using LibSlide;
using OpenTK.Windowing.Common;

namespace Slide.Scene;

public class Menu : Scene
{
	public override void Initialize()
	{
		Log.Debug("Initializing Menu");
		
		//checks? log setup? load assets?

		Log.Info($"Slidehop {Constants.Version} loading");

		//Assets.Load();
		//var home = await Loader.LoadHome();
		//parse home
		//render menu
		//?
		
		var delay = Task.Run(async () =>
		{
			await Task.Delay(1000);
			Transition?.Invoke(new Game());
		});
	}

	public override void OnLoad()
	{
	}
	
	public override void RenderFrame(FrameEventArgs e)
	{
	}
	
	public override void Dispose()
	{
	}
}