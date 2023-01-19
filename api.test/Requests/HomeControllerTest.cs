using System.Text.Json;
using api.ModelViews;
using Microsoft.AspNetCore.Mvc.Testing;
using api;
using Microsoft.AspNetCore.Hosting;

namespace api.test;

[TestClass]
public class HomeControllerTest
{
    [TestMethod]
    public async Task TestandoIndexDaHome()
    {
        HttpClient client = startApp();
        
        var response = await client.GetAsync("http://localhost:5000");

        var body = await response.Content.ReadAsStringAsync();

        var home = JsonSerializer.Deserialize<Home>(body, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });

        Assert.AreEqual(home.Mensagem, "Bem vindo a minha API");

        closeApp();

    }

    private void closeApp()
    {
       http.Dispose();
    }

    private WebApplicationFactory<Startup> http = default!;

    private HttpClient startApp()
    {
        http = new WebApplicationFactory<Startup>();

        http = http.WithWebHostBuilder(builder =>
        {
            builder.UseSetting("https_port", "5000").UseEnvironment("Testing");
        });

        return http.CreateClient();
    }
}