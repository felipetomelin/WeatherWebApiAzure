var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/hello", () => "Hello World!");
app.MapGet("/hello/{name}", (string name) => $"Hello {name}!");
app.MapPost("/items", (Item item) => 
{
    item.Id = Guid.NewGuid();
    return Results.Created($"/items/{item.Id}", item);
});

app.MapGet("/search", (string query) => 
{
    return Results.Ok(new { results = $"Searching for: {query}" });
});

app.Run();

public class Item
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
}