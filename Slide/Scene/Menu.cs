using LibSlide;
using OpenTK.Windowing.Common;

namespace Slide.Scene;

public class Menu : Scene
{
	public override void Initialize()
	{
		Log.Debug("Initializing Menu");

		//Assets.Load();
		//var home = await Loader.LoadHome();
		//parse home
		//render menu
		//?
		
		//var delay = Task.Run(async () =>
		//{
		//	await Task.Delay(1000);
		//	var game = new Game();
		//	Transition?.Invoke(game);
		//});
		new Thread(() =>
		{
			Thread.Sleep(1000);
			var game = new Game();
			Transition?.Invoke(game);
		}).Start();
		//Transition?.Invoke(new Game());
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