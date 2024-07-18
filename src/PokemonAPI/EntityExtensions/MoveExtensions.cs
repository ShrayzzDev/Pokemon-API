using Entities;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityExtensions
{
    public static class MoveExtensions
    {
        public static Move ToModel(this MoveEntity entity)
        {
            return new Move(
                entity.Id,
                entity.Name,
                entity.Type.ToModel(),
                entity.Power,
                entity.PP,
                entity.Accuracy
            );
        }

        public static IEnumerable<Move> ToModels(this IEnumerable<MoveEntity> entities)
        {
            var list = new List<Move>(entities.Count());
            foreach(var entity in entities)
            {
                list.Add(entity.ToModel());
            }
            return list;
        }
    }
}
