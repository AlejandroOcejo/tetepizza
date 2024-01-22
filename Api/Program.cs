using TetePizza.Data;
using TetePizza.Bussines;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IPizzaRepository, PizzaRepository>();
builder.Services.AddScoped<IPizzaServices, PizzaServices>();

builder.Services.AddSingleton<IIngredientesRepository, IngredientesRepository>();
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
