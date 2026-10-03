using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    ).LogTo(Console.WriteLine , LogLevel.Information);
});


//Exception Handler
builder.Services.AddProblemDetails();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();


//Model Validation


var app = builder.Build();

app.UseExceptionHandler();
app.MapControllers();


app.Run();
