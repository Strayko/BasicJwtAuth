using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using SofthouseDev.Api.Persistence;

namespace SofthouseDev.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAuth(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => 
                {
                    var key = Convert.FromBase64String("OFRC1j9aaR2BvADxNWlG2pmuD392UfQBZZLM1fuzDEzDlEpSsn+btrpJKd3FfY855OMA9oK4Mc8y48eYUrVUSw==");
                    var signingKey = new SymmetricSecurityKey(key);

                    options.Authority = "https://localhost:7224";
                    options.RequireHttpsMetadata = false;
                    options.SaveToken = true;
                    options.Configuration = new OpenIdConnectConfiguration();
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = signingKey,
                        ValidIssuer = "http://coding.com",
                        ValidAudience = "http://coding.com"
                    };
                });

            return services;
        }
    }
}
