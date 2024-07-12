using Entities;
using InitDatabase;
using Microsoft.EntityFrameworkCore;

namespace Context
{
    public class PokemonDBContext : DbContext
    {

        public DbSet<TypeEntity> Types { get; set; }

        public DbSet<MoveEntity> Moves { get; set; }

        public DbSet<PokemonMoveEntity> MovePool { get; set; }

        public DbSet<PokemonEntity> Pokemons { get; set; }

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
