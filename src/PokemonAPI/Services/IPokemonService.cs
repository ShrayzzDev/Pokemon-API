namespace Services
{
    public interface IPokemonService<T>
    {
        /// <summary>
        /// Get a pokemon from it's pokedex entry
        /// </summary>
        /// <param name="id">Pokedex entry of that pokemon</param>
        /// <returns></returns>
        public Task<T?> GetPokemonById(int id);

        /// <summary>
        /// Returns a list a pokemon containing the
        /// string passed as parameter
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Task<IEnumerable<T>> GetPokemonByName(string name, int index, int count);
    }
}
