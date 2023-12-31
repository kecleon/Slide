﻿using LibSlide;
using OpenTK.Graphics.OpenGL4;
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

		var delay = Task.Run(async () =>
		{
			await Task.Delay(1000);
			var game = new Game();
			Transition?.Invoke(game);
		});
	}

	public override void RenderFrame(FrameEventArgs e)
	{
		GL.Clear(ClearBufferMask.ColorBufferBit);
	}

	public override void Dispose()
	{
	}
}