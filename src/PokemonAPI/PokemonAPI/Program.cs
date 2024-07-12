using Business;
using Context;
using Entities;
using InitDatabase;
using Microsoft.EntityFrameworkCore;
using Model;
using Repositories;
using Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IPokemonService<PokemonEntity>, PokemonRepository>();
builder.Services.AddScoped<IPokemonService<Pokemon>, PokemonBusinessServices>();

builder.Services.AddDbContext<PokemonDBContext>();


using (var context = new PokemonDBContext())
{
    foreach (var pkmn in context.Pokemons)
    {
        Console.WriteLine(pkmn.Name);
    }
    Console.WriteLine(!context.Pokemons.Any());
    if (!context.Pokemons.Any())
    {
        await context.Types.AddRangeAsync(InitTypes.GetTypesArray());
        await context.Moves.AddRangeAsync(InitMoves.GetMovesArray());
        await context.MovePool.AddRangeAsync(InitPokemonMove.GetPokemonMoveArray());
        await context.Pokemons.AddRangeAsync(InitPokemon.GetPokemonArray());

        await context.SaveChangesAsync();
    }
}

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

app.Run();
