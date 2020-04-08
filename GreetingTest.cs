using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using Xunit;

namespace api_testing
{
    public class GreetingTest
    {
        string URL = "https://zoomworld.azurewebsites.net/api/zoomworld20?code=ake7hRhu8e4hGNKzIQmJ45q6PA5E3kL520QKRD4PZamTQRYhktYK9w==&name=Bob";
        HttpClient apiClient = new HttpClient();
        [Fact]
        public async Task TestGreetingApi()
        {
            try
            {
                HttpResponseMessage response = await apiClient.GetAsync(URL);
                string responseBody = await response.Content.ReadAsStringAsync();
                Greeting greeting = JsonSerializer.Deserialize<Greeting>(responseBody);
                Assert.Equal("Bob", greeting.name);
                Assert.Equal("Hello there", greeting.message);
            }
            catch (HttpRequestException ex)
            {
                Assert.True(false, ex.Message);
            }

        }
    }
}
