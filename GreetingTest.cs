using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using Xunit;

namespace api_testing
{
    public class GreetingTest : IClassFixture<IntegrationTestFixture>
    {

        TestEndpoints testEndpoints;
        HttpClient apiClient;

        public GreetingTest(IntegrationTestFixture fixture)
        {
            // common items for each test to us should come from the fixture
            testEndpoints = fixture.testEndpoints;
            apiClient = fixture.apiClient;
        }
        
        [Fact]
        public async Task TestGreetingApi_withBob()
        {
            try
            {
                // Commnet: This test uses JsonSerializer. Another path is to use a more
                // dynamic serializer so that test does not reference a concrete class. In the test,
                // it deserializes JSON data to Greeting class
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