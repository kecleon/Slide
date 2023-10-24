using OpenTK.Graphics.OpenGL;

namespace Slide.Shader;

public class ShaderUtility
{
	public static int CreateShaderProgram(string vertexShaderSource, string fragmentShaderSource)
	{
		int vertexShader = CompileShader(ShaderType.VertexShader, vertexShaderSource);
		int fragmentShader = CompileShader(ShaderType.FragmentShader, fragmentShaderSource);

		int program = GL.CreateProgram();
		GL.AttachShader(program, vertexShader);
		GL.AttachShader(program, fragmentShader);
		GL.LinkProgram(program);

		GL.DeleteShader(vertexShader);
		GL.DeleteShader(fragmentShader);

		return program;
	}

	private static int CompileShader(ShaderType type, string source)
	{
		int shader = GL.CreateShader(type);
		GL.ShaderSource(shader, source);
		GL.CompileShader(shader);

		return shader;
	}
}