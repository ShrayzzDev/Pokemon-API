using Entities;
using Entities.Pokemons;
using EntityExtensions;
using EntityExtensions.Pokemons;
using Model;
using Model.DamageParameters;
using Model.Pokemons;
using Services;

namespace Business
{
    public class Gen1DamageCalculator : IDamageCalculator<Gen1DamageInformations>
    {
        private IPokemonService<PokemonEntity, PokemonWithoutMovesEntity, SimplePokemonEntity> _pkmnRepository;

        private IMoveService<MoveEntity> _moveRepository;

        private ITypeEfficiencyService<TypeEfficiencyEntity> _typeEfficiencyRepository;

        public Gen1DamageCalculator(IPokemonService<PokemonEntity, PokemonWithoutMovesEntity, SimplePokemonEntity> pkmnService,
                                    IMoveService<MoveEntity> moveRepository,
                                    ITypeEfficiencyService<TypeEfficiencyEntity> typeEfficiencyRepository)
        {
            _pkmnRepository = pkmnService;
            _moveRepository = moveRepository;
            _typeEfficiencyRepository = typeEfficiencyRepository;
        }

        /// <inheritdoc/>
        public int EffectiveStat(int bst, int evs, int ivs, int level, bool isHp)
        {
            int lastValue;

            if (isHp)
                lastValue = 10 + level;
            else
                lastValue = 5;

            return ((bst + ivs) * 2 + (evs / 4)) * level / 100 + lastValue;
        }

        /// <inheritdoc/>
        public async Task<(double, double)> GetDamage(Gen1DamageInformations informations)
        {
            var damaging = (await _pkmnRepository.GetPokemonWithoutMovesById(informations.DamagingId))?.ToModel();
            var target = (await _pkmnRepository.GetPokemonWithoutMovesById(informations.TargetId))?.ToModel();
            if (damaging == null || target == null)
            {
                throw new KeyNotFoundException("Either damaging or target pokemon could not be found");
            }
            var move = (await _moveRepository.GetMoveById(informations.MoveId))?.ToModel();
            if (move == null)
            {
                throw new KeyNotFoundException("The move could not be found");
            }
            (int, int) result = GetRealAttackDefenseStats(move, damaging, target, informations);
            int attack = attack = result.Item1;
            int defense = defense = result.Item2;
            float STAB = GetSTAB(damaging, move);
            int critical = informations.IsCritical ? 2 : 1;
            float typeEffi = await GetTypeEfficiency(move, target);
            float max = 1f;
            float min = 217f / 255f;
            float maxResult = ((((2 * informations.DamagingLevel * critical / 5) + 2)
                * move.Power * attack / defense
                / 50) + 2) * STAB * typeEffi * max;
            float minResult = ((((2 * informations.DamagingLevel * critical / 5) + 2)
                * move.Power * attack / defense
                / 50) + 2) * STAB * typeEffi * min;
            return (minResult, maxResult);
        }

        protected (int, int) GetRealAttackDefenseStats(Move move,
                                                       PokemonWithoutMoves damaging,
                                                       PokemonWithoutMoves target,
                                                       Gen1DamageInformations informations)
        {
            int attack;
            int defense;
            switch (move.Type.Typing)
            {
                case "Phy":
                    attack = EffectiveStat(
                        damaging.Attack,
                        informations.DamagingEvs.Attack,
                        informations.DamagingIvs.Attack,
                        informations.DamagingLevel,
                        false
                    );
                    defense = EffectiveStat(
                        target.Defense,
                        informations.TargetEvs.Defense,
                        informations.TargetIvs.Defense,
                        informations.TagetLevel,
                        false
                    );
                    break;

                case "Spe":
                    attack = EffectiveStat(
                        damaging.Special,
                        informations.DamagingEvs.Special,
                        informations.DamagingIvs.Special,
                        informations.DamagingLevel,
                        false
                    );

                    // We can do that since in gen1,
                    // they are the same stat.
                    defense = attack;
                    break;

                default:
                    throw new ArgumentException("Invalid typing");
            }
            return (attack, defense);
        }

        private float GetSTAB(PokemonWithoutMoves damaging, Move move)
        {
            float STAB = 1f;
            foreach (var type in damaging.Types)
            {
                if (type.Name == move.Type.Name) STAB = 1.5f;
            }
            return STAB;
        }

        private async Task<float> GetTypeEfficiency(Move move, PokemonWithoutMoves target)
        {
            IEnumerable<float> typeEffis = await _typeEfficiencyRepository.GetEfficiencyOn(
                move.Type.Name, target.Types.Select(t => t.Name)
            );
            if (typeEffis.Count() == 1) return typeEffis.First() / 100f;
            return typeEffis.Aggregate((f, s) => f / 100f * s / 100f);
        }
    }
}
