namespace DTO.Pokemons
{
    public class PokemonDTO : PokemonWithoutMovesDTO
    {
        public IEnumerable<PokemonMoveDTO> MovePool { get; set; }

        public PokemonDTO(int id,
                          string? name,
                          int hP,
                          int attack,
                          int defense,
                          int sP_Attack,
                          int sP_Defense,
                          int special,
                          int speed,
                          IEnumerable<TypeDTO> types,
                          IEnumerable<PokemonMoveDTO> movePool)
            : base(id, name, hP, attack, defense, sP_Attack, sP_Defense, special, speed, types)
        {
            MovePool = movePool;
        }
    }
}
