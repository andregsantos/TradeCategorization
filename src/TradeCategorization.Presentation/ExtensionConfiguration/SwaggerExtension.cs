using Microsoft.OpenApi.Models;

namespace TradeCategorization.API.ExtensionConfiguration
{
    public static class SwaggerExtension
    {
        public static void AddSwaggerExtension(this WebApplicationBuilder builder)
        {

            builder.Services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "TradeCategorization API",
                    Description = "TradeCategorization API Swagger",
                    Contact = new OpenApiContact
                    {
                        Name = "André Gomes Santos",
                        Email = "del.gsantos75@gmail.com",
                        Url = new Uri("https://www.linkedin.com/in/andr%C3%A9-g-santos-9ab894270")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "LICENSE MIT",
                        Url = new Uri("https://github.com/andregsantos/TradeCategorization/blob/main/LICENSE")
                    }
                });

                s.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme (Example: 'Bearer 12345abcdef')",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                s.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
            {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
            });
        }
    }
}
