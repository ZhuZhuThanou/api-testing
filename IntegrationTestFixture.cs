using System;
using System.Net.Http;
using Xunit;

namespace api_testing
{
    public class IntegrationTestFixture : IDisposable
    {

        public string coolName { get; }
        public TestEndpoints testEndpoints { get; }
        public HttpClient apiClient { get; }
        public IntegrationTestFixture()
        {
            coolName = "faloo";
            testEndpoints = new TestEndpoints();
            apiClient = new HttpClient();
        }

        public void Dispose()
        {
          
        }
    }
}
