using OpenTK.Windowing.Common;

namespace Slide.Scene;

public abstract class Scene
{
	public Action<Scene>? Transition;
	public abstract void Initialize();
	public abstract void RenderFrame(FrameEventArgs e);
	public abstract void Dispose();
}