using System;
namespace api_testing
{
    public class TestEndpoints
    {
        public string baseUrl { get; }
        public string apiKey { get; }

        public TestEndpoints()
        {
            this.baseUrl = Environment.GetEnvironmentVariable("baseURL");
            if (String.IsNullOrEmpty(this.baseUrl))
            {
                throw new System.NullReferenceException("baseURL environment variable not set.");
            }
            this.apiKey = Environment.GetEnvironmentVariable("apiKey");
            if (String.IsNullOrEmpty(this.apiKey))
            {
                throw new System.NullReferenceException("apiKey environment variable not set.");
            }
        }
    }
}
