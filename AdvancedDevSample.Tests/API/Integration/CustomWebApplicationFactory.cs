using AdvancedDevSample.Domain.Interfaces.Products;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdvancedDevSample.Tests.API.Integration
{
   /* public class CustomWebApplicationFactory : WebApplicationFactory<Program>
    {

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                // Supprimer le vrai repository enregistré dans Program.cs
                var descriptor = services.SingleOrDefault(
                    d => d.ServiceType == typeof(IProductRepository));
                if (descriptor != null)
                {
                    services.Remove(descriptor);
                }

                // Ajouter la version In-Memory pour les tests
                services.AddSingleton<IProductRepository, InMemoryProductRepository>();
            });
        }

    }*/
}
