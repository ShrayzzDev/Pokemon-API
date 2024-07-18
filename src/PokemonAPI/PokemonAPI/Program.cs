using Business;
using Context;
using Entities;
using Entities.Pokemons;
using EntityExtensions.Pokemons;
using InitDatabase;
using Microsoft.EntityFrameworkCore;
using Model;
using Model.DamageParameters;
using Model.Pokemons;
using Repositories;
using Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IPokemonService<PokemonEntity, PokemonWithoutMovesEntity, SimplePokemonEntity>, PokemonRepository>();
builder.Services.AddScoped<IPokemonService<Pokemon, PokemonWithoutMoves, SimplePokemon>, PokemonBusinessServices>();

builder.Services.AddScoped<IMoveService<MoveEntity>, MoveRepository>();
builder.Services.AddScoped<IMoveService<Move>, MoveBusinessServices>();

builder.Services.AddScoped<ITypeEfficiencyService<TypeEfficiencyEntity>, TypeEfficiencyRepository>();

builder.Services.AddScoped<IDamageCalculator<Gen1DamageInformations>, Gen1DamageCalculator>();

builder.Services.AddDbContext<PokemonDBContext>();

using (var context = new PokemonDBContext())
{
    if (!context.Pokemons.Any())
    {
        await context.Types.AddRangeAsync(InitTypes.GetTypesDict().Values);
        await context.SaveChangesAsync();
        await context.TypeEfficiencies.AddRangeAsync(InitTypeEfficiency.GetTypeEfficiencyArray());
        await context.Moves.AddRangeAsync(InitMoves.GetMovesArray());
        await context.Pokemons.AddRangeAsync(await InitPokemon.GetPokemonArray(context));
        await context.MovePool.AddRangeAsync(await InitPokemonMove.GetPokemonMoveArray(context));

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
