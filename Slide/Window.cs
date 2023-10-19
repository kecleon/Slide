using LibSlide;
using LibSlide.Assets;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using Slide.Net;

namespace Slide;

public class Window : GameWindow
{
	private static GameWindowSettings gameWindowSettings = new();
	private static NativeWindowSettings nativeWindowSettings = new();
	
	private static Web Client = new();
	private static Menu Menu = new();

	static Window()
	{
		gameWindowSettings.UpdateFrequency = 60;
		nativeWindowSettings.Title =  $"Slidehop {Constants.Version}";
		nativeWindowSettings.WindowBorder = WindowBorder.Hidden;
	}

	public static void Main()
	{
		using (var app = new Window())
		{
			app.Run();
		}
	}
	
	//public Window(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings) : base(gameWindowSettings, nativeWindowSettings)
	public Window() : base(new GameWindowSettings(), new NativeWindowSettings())
	{
		Title = $"Slidehop {Constants.Version}";
	}

	protected override async void OnLoad()
	{
		base.OnLoad();

		//var client = new Client();
		//var colorFromWeb = await client.LoadWebDataAsync();
        //
		//_gameScene = new GameScene(colorFromWeb);
	}

	protected override void OnRenderFrame(FrameEventArgs e)
	{
		base.OnRenderFrame(e);

		GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
        
		GL.Begin(PrimitiveType.Triangles);

		GL.Color3(_triangleColor);
		GL.Vertex2(0, 0.5f);
		GL.Vertex2(-0.5f, -0.5f);
		GL.Vertex2(0.5f, -0.5f);

		GL.End();

		SwapBuffers();
	}
	
}