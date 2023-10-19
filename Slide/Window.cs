using LibSlide;
using LibSlide.Assets;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using Slide.Net;
using Slide.Scene;

namespace Slide;

public class Window : GameWindow
{
	private static GameWindowSettings gameWindowSettings = new();
	private static NativeWindowSettings nativeWindowSettings = new();
	
	private Web Web;
	private Scene.Scene Scene;

	static Window()
	{
		gameWindowSettings.UpdateFrequency = 60;
		nativeWindowSettings.Title =  $"Slidehop {Constants.Version}";
		nativeWindowSettings.WindowBorder = WindowBorder.Resizable;
		nativeWindowSettings.Size = new Vector2i(1280, 720);
		
		//todo: launch in fullscreen, launch on monitor where the current focused window is present
		//var monitor = Monitors.GetPrimaryMonitor();
	}

	public static void Main()
	{
		using var app = new Window();
		app.Run();
	}
	
	private Window() : base(gameWindowSettings, nativeWindowSettings)
	{
		Title = $"Slidehop {Constants.Version}";
		
		Web = new();
		Scene = new Menu();
	}

	protected override async void OnLoad()
	{
		base.OnLoad();
		Assets.Load();
		
		Log.Debug($"Loading!");
		Scene.Initialize();
		Scene.OnLoad();
		Scene.Transition += Transition;
	}
	
	private void Transition(Scene.Scene obj)
	{
		//?
		Scene.Transition -= Transition;

		Log.Debug($"Switching from {Scene.GetType()} to {obj.GetType()}");
		Scene.Dispose();
		Scene = obj;
		Scene.Initialize();
		Scene.OnLoad();
		Scene.Transition += Transition;
	}

	protected override void OnRenderFrame(FrameEventArgs e)
	{
		base.OnRenderFrame(e);
		Scene.RenderFrame(e);

		// OpenTK windows are what's known as "double-buffered". In essence, the window manages two buffers.
		// One is rendered to while the other is currently displayed by the window.
		// This avoids screen tearing, a visual artifact that can happen if the buffer is modified while being displayed.
		// After drawing, call this function to swap the buffers. If you don't, it won't display what you've rendered.
		SwapBuffers();
	}

	protected override void OnUpdateFrame(FrameEventArgs e)
	{
		base.OnUpdateFrame(e);
	}

	protected override void OnResize(ResizeEventArgs e)
	{
		base.OnResize(e);
		GL.Viewport(0, 0, Size.X, Size.Y);
	}
	
}