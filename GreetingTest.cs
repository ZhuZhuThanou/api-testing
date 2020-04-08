using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using Xunit;

namespace api_testing
{
    public class GreetingTest
    {
        TestEndpoints testEndpoints = new TestEndpoints();

   
        HttpClient apiClient = new HttpClient();
        [Fact]
        public async Task TestGreetingApi_withBob()
        {
            try
            {
                string URL = testEndpoints.baseUrl + "?code=" + testEndpoints.apiKey + "&name=Bob";
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
