var builder = WebApplication.CreateBuilder(args);

// Register services
builder.Services.AddControllers();

// Register BookService as a singleton (or transient if preferred)
builder.Services.AddSingleton<BookService>(); // This line is important

// Add Swagger services (if needed)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.RoutePrefix = "swagger");
}

app.UseAuthorization();
app.MapControllers(); // Map controllers to routes
app.Run();
