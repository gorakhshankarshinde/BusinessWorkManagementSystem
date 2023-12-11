using BusinessWorkManagementSystem;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<BusinessWorkManagementSystemContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("Server=DESKTOP-E3QEKAH;Database=BusinessWorkManagementSystem;Integrated Security=True;TrustServerCertificate=True;")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.MapControllers();
//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=User}/{action=GetAllUserList}/{UserId?}");


app.Run();
