using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ProductManagement.Infrastructure.Authentication;

namespace ProductManagement.API.OptionsSetup;

public class JwtBearerSetup : IConfigureOptions<JwtBearerOptions>
{
    private readonly JwtOptions _jwtOptions;
    public JwtBearerSetup(IOptions<JwtOptions> jwtOptions)
    {
        _jwtOptions = jwtOptions.Value;
    }
    public void Configure(JwtBearerOptions options)
    {
        options.TokenValidationParameters = new()
        {
            //Audience
            ValidateAudience = true,
            ValidAudience = _jwtOptions.Audience,
            //Issuer
            ValidateIssuer = true,
            ValidIssuer = _jwtOptions.Issuer,
            //
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.Secret))            
        };
    }
}
