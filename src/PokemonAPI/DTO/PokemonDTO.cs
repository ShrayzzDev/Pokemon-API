namespace DTO
{
    public class PokemonDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int HP { get; set; }

        public int Attack { get; set; }

        public int Defense { get; set; }

        public int SP_Attack { get; set; }

        public int SP_Defense { get; set; }

        public int Special { get; set; }

        public int Speed { get; set; }

        public IEnumerable<TypeDTO> Types { get; set; }

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
        {
            Id = id;
            Name = name == null ? "" : name;
            HP = hP;
            Attack = attack;
            Defense = defense;
            SP_Attack = sP_Attack;
            SP_Defense = sP_Defense;
            Special = special;
            Speed = speed;
            Types = types;
            MovePool = movePool;
        }
    }
}
