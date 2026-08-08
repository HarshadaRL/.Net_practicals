using _28July.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


//singleton = single instance is created & shared for entire appl lifetime
//transient = new instance is created every time services is required 
//Addscoped = one instance is created per http request
builder.Services.AddScoped<IProductService, ProductService>();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseSwaggerUI();
app.UseSwagger();

app.UseAuthorization();

app.MapControllers();

app.Run();
