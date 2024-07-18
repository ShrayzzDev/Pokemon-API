namespace Services
{
    public interface IPokemonService<Detailed, WithoutMoves ,Simple> where Detailed: class
                                                                     where WithoutMoves: class
                                                                     where Simple : class
    {
        /// <summary>
        /// Get a pokemon from it's pokedex entry
        /// </summary>
        /// <param name="id">Pokedex entry of that pokemon</param>
        /// <returns>The pokemon, null if not found</returns>
        public Task<Detailed?> GetPokemonById(int id);

        /// <summary>
        /// Returns a list a pokemon containing the
        /// string passed as parameter
        /// </summary>
        /// <param name="name"></param>
        /// <returns>The pokemon, null if not found</returns>
        public Task<IEnumerable<Simple>> GetPokemonByName(string name, int index, int count);
    }
}
