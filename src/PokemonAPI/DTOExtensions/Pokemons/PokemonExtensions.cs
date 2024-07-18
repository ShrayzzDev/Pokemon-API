using DTO.Pokemons;
using Model.Pokemons;

namespace DTOExtensions.Pokemons
{
    public static class PokemonExtensions
    {
        public static PokemonDTO ToDTO(this Pokemon model)
        {
            return new PokemonDTO(
                model.Id,
                model.Name,
                model.HP,
                model.Attack,
                model.Defense,
                model.SP_Attack,
                model.SP_Defense,
                model.Special,
                model.Speed,
                model.Types.ToDTOs(),
                model.MovePool.ToDTOs()
            );
        }

        public static IEnumerable<PokemonDTO> ToDTOs(this IEnumerable<Pokemon> models)
        {
            var list = new List<PokemonDTO>();
            foreach (var model in models)
            {
                list.Add(model.ToDTO());
            }
            return list;
        }
    }
}
