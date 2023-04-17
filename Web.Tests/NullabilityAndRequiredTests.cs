using System.Text;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit.Abstractions;

namespace Web.Tests;

public class NullabilityAndRequiredTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;
    private readonly ITestOutputHelper _helper;

    public NullabilityAndRequiredTests(WebApplicationFactory<Program> factory, ITestOutputHelper helper)
    {
        _factory = factory;
        _helper = helper;
    }

    [Theory]
    [InlineData("/someclass")]
    [InlineData("/someotherclass")]
    public async Task SomeClass(string route)
    {
        var client = _factory.CreateClient();
        var json =
        """
        {
          "thing": {
            "name" : "Hello, World!"
          }
        } 
        """;
        
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await client.PostAsync(route, content);
        var res = await response.Content.ReadAsStringAsync();
        _helper.WriteLine(res);

        Assert.True(res.Contains("Hello, World!"));
    }
}
