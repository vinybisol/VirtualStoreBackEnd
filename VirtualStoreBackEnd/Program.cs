using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using VirtualStoreBackEnd.Data;
using VirtualStoreBackEnd.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<SQLServerContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SQLServerContext") ?? throw new InvalidOperationException("Connection string 'SQLServerContext' not found.")));

// Add services to the container.
builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
