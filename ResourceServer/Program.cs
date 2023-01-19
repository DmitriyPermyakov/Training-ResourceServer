using Microsoft.EntityFrameworkCore;
using ResourceServer;
using ResourceServer.Repositories;

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

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
//app.MapControllers();

app.Run();
