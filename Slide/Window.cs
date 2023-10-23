using System.Collections.Concurrent;
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

	private ConcurrentQueue<Action> MainThreadQueue = new();

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
		Log.Info($"Slidehop {Constants.Version} loading");
		Assets.Load();
		
		Log.Debug($"Loading window!");
		Web = new();
		Scene = new Menu();
		
		Scene.Transition += QueueTransition;
		Scene.Initialize();
	}

	private void QueueTransition(Scene.Scene obj)
	{
		EnqueueForMainThread(() =>
		{
			Log.Debug($"Switching from {Scene.GetType()} to {obj.GetType()}");
			Scene.Transition -= QueueTransition;
			Scene.Dispose();
			obj.Initialize();
			obj.Transition += QueueTransition;
			Scene = obj;
		});
	}
	
	private void EnqueueForMainThread(Action action)
	{
		MainThreadQueue.Enqueue(action);
	}

	protected override void OnRenderFrame(FrameEventArgs e)
	{
		base.OnRenderFrame(e);
		Scene.RenderFrame(e);
		SwapBuffers();
	}

	protected override void OnUpdateFrame(FrameEventArgs e)
	{
		base.OnUpdateFrame(e);
		while (MainThreadQueue.TryDequeue(out var action))
		{
			action.Invoke();
		}
    }

	protected override void OnResize(ResizeEventArgs e)
	{
		base.OnResize(e);
		GL.Viewport(0, 0, Size.X, Size.Y);
	}
	
}