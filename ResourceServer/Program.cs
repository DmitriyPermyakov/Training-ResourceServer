using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using ResourceServer;
using ResourceServer.JwtSettingFolder;
using ResourceServer.Repositories;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<ISupplierRepo, SupplierRepo>();
builder.Services.AddTransient<IProductRepo, ProductRepo>();

string connectionString = builder.Configuration.GetConnectionString("ResourceDatabase");
builder.Services.AddDbContext<ApplicationContext>(b =>
{
    b.UseSqlServer(connectionString);
});

var jwtSettings = new JwtSettings();
builder.Configuration.GetSection("JwtSettings").Bind(jwtSettings);

var tokenValidationParam = new TokenValidationParameters()
{
    ValidateIssuer = false,
    ValidateAudience = false,
    ValidateIssuerSigningKey = true,
    RequireExpirationTime = false,
    ValidateLifetime = false,
    
    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSettings.AccessTokenSecret))
};



builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        
        options.SaveToken = true;
        options.TokenValidationParameters = tokenValidationParam;
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
//app.MapControllers();

app.Run();
