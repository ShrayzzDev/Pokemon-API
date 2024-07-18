using Entities;
using Entities.Pokemons;
using EntityExtensions.Pokemons;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace Context
{
    public class PokemonDBContext : DbContext
    {
        public DbSet<TypeEntity> Types { get; set; }

        public DbSet<MoveEntity> Moves { get; set; }

        public DbSet<PokemonMoveEntity> MovePool { get; set; }

        public DbSet<PokemonEntity> Pokemons { get; set; }

        public DbSet<PokemonWithoutMovesEntity> PokemonsWithoutMoves { get; set; }

        public DbSet<TypeEfficiencyEntity> TypeEfficiencies { get; set; }

        public DbSet<SimplePokemonEntity> SimplePokemons { get; set; }

        public PokemonDBContext() { }

        public PokemonDBContext(DbContextOptions<PokemonDBContext> options) : base(options) { }
        
        /// <inheritdoc/>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlite($"Data Source=Database_Test.db");
            }
        }
    }
}
