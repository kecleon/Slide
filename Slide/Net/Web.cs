namespace Slide.Net;

public class Web
{
	private const string ApiUrl = "http://your-web-server-endpoint/api/data";

	public async Task<string> LoadHome()
	{
		using var httpClient = new HttpClient();
		var response = await httpClient.GetAsync(ApiUrl);
		response.EnsureSuccessStatusCode();

		var data = await response.Content.ReadAsStringAsync();
		return data;
	}
}