using Microsoft.Extensions.Options;
using ProductManagement.Infrastructure.Authentication;

namespace ProductManagement.API.OptionsSetup;

public class JwtOptionsSetup : IConfigureOptions<JwtOptions> //IConfigureOptions là gì?, IOptions là gì?
{
    private const string sectionName = "Jwt";
    private readonly IConfiguration _configuration;
    public JwtOptionsSetup(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public void Configure(JwtOptions options)
    {
       _configuration.GetSection(sectionName).Bind(options);
    }
}

