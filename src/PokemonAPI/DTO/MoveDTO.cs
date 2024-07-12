using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class MoveDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public TypeDTO Type { get; set; }

        public int Power { get; set; }

        public int PP { get; set; }

        public int Accuracy { get; set; }

        public MoveDTO(int id, string name, TypeDTO type, int power, int pP, int accuracy)
        {
            Id = id;
            Name = name;
            Type = type;
            Power = power;
            PP = pP;
            Accuracy = accuracy;
        }
    }
}
