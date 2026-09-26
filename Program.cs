using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    ).LogTo(Console.WriteLine , LogLevel.Information);
});
var app = builder.Build();

app.MapControllers();


app.Run();
