using TetePizza.Data;
using TetePizza.Bussines;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("ServerDB");

// Use Scoped for both repositories
builder.Services.AddScoped<IPizzaRepository, PizzaSqlRepository>(serviceProvider => new PizzaSqlRepository(connectionString));
builder.Services.AddScoped<IIngredientesRepository, IngredientesRepository>();

// Use Scoped for both services
builder.Services.AddScoped<IPizzaServices, PizzaServices>();
builder.Services.AddScoped<IIngredientesServices, IngredientesServices>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

/* app.UseHttpsRedirection();*/
app.UseAuthorization();

app.MapControllers();

app.Run();
