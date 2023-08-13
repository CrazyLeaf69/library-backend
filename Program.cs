using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using backend.Helpers;
using backend.Services;
using Azure.Identity;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager _configuration = builder.Configuration;

// Add services to the container.
var services = builder.Services;
services.AddDbContext<DataContext>();
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
services.AddControllers();

services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:AccessSecret").Value!)),
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
        };
    });

services.AddCors(options => 
    options.AddPolicy(name: "NgOrigins",
    policy =>
    {
        policy.WithOrigins(_configuration.GetSection("AppSettings:ClientUrl").Value!).AllowAnyMethod().AllowAnyHeader().AllowCredentials();
    }));

services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

services.AddScoped<IAuthService, AuthService>();
services.AddScoped<IUserService, UserService>();
services.AddScoped<IBookService, BookService>();
services.AddScoped<IQuoteService, QuoteService>();
services.AddScoped<IFavoriteQuoteService, FavoriteQuoteService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("NgOrigins");

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
