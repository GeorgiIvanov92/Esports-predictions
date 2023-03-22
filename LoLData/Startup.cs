using Azure.Extensions.AspNetCore.Configuration.Secrets;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using LolData.Data;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.AzureAppConfiguration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.Services.AppAuthentication;

[assembly: FunctionsStartup(typeof(LoLData.Startup))]
namespace LoLData
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            var keyVaultUrl = Environment.GetEnvironmentVariable("KeyVaultUri");
            var serviceTokenProvider = new AzureServiceTokenProvider();
            var keyVaultClient = new KeyVaultClient(new KeyVaultClient.AuthenticationCallback(serviceTokenProvider.KeyVaultTokenCallback));
            var secret = keyVaultClient.GetSecretAsync(keyVaultUrl, "ConnectionStrings--DefaultConnection").Result;

            builder.Services.AddDbContext<TrackerDBContext>(options =>
            {
                options.UseSqlServer(secret.Value);
            });
        }
    }
}
