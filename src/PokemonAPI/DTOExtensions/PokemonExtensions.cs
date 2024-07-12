using DTO;
using Model;

namespace DTOExtensions
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
    }
}
