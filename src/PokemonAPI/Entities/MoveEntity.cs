
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [PrimaryKey(nameof(Id))]
    public class MoveEntity
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string TypeId { get; set; } = null!;

        public TypeEntity Type { get; set; } = null!;

        public int Power { get; set; }

        public int PP { get; set; }

        public int Accuracy { get; set; }

        public MoveEntity() { }

        public MoveEntity(int id, string name, string typeId, int power, int pP, int accuracy)
        {
            Id = id;
            Name = name;
            TypeId = typeId;
            Power = power;
            PP = pP;
            Accuracy = accuracy;
        }
    }
}
