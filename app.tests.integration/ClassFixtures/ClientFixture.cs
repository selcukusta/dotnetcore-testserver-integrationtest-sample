using app.api;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Net.Http;

namespace app.tests.integration.ClassFixtures
{
    public class ClientFixture : IDisposable
    {
        public HttpClient Client { get; }

        public ClientFixture()
        {
            var server = new TestServer(new WebHostBuilder()
                .UseEnvironment("IntegrationTest")
                .UseStartup<Startup>());

            Client = server.CreateClient();
        }

        public void Dispose()
        {
            Client.Dispose();
        }
    }
}