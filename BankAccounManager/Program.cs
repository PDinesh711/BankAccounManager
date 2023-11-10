using BankAccounManager.Database;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region config of Cors 
builder.Services.AddCors(options =>
{
    options.AddPolicy("BankAccount",bank=>bank.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});
#endregion

#region config of database 

builder.Services.AddDbContext<BankAccountDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("sql"));
});
#endregion
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("BankAccount");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
