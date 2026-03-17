var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();


app.MapGet("/health", () => Results.Json(new { status = "ok", time = DateTime.UtcNow }));

app.MapGet("/version", (IConfiguration config) => Results.Json(new
{
    name = config["App:Name"],
    version = config["App:Version"]
}));


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
