using GraphQL;
using Keycloak;
using Microsoft.AspNetCore.Localization;
using Persistance;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAuthentication();
builder.Services.AddAuthorization();
builder.Services.AddLocalization();
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var cultures = new[]
    {
        new CultureInfo("en"),
        new CultureInfo("da")
    };
    options.DefaultRequestCulture = new RequestCulture("da");
    options.SupportedCultures = cultures;
    options.SupportedUICultures = cultures;
});
builder.Services.AddMongoDb(builder.Configuration).AddKeycloak(builder.Configuration).AddCustomGraphQL();

//var section = builder.Configuration.GetSection("OAuth2.0");
//builder.Services.Configure<OAuth2>(section);
//builder.Services.AddAuthentication("Bearer")
//           .AddJwtBearer("Bearer", options =>
//           {
//               options.Authority = "";

//               options.TokenValidationParameters = new TokenValidationParameters
//               {
//                   ValidateAudience = false
//               };
//           });

var app = builder.Build();
app.UseAuthentication();
app.UseAuthorization();
app.UseCustomGraphQL();
app.Run();