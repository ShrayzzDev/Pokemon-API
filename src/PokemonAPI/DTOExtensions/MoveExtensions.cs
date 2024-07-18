using DTO;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOExtensions
{
    public static class MoveExtensions
    {
        public static MoveDTO ToDTO(this Move model)
        {
            return new MoveDTO(
                model.Id,
                model.Name,
                model.Type.ToDTO(),
                model.Power,
                model.PP,
                model.Accuracy
            );
        }

        public static IEnumerable<MoveDTO> ToDTOs(this IEnumerable<Move> models)
        {
            var dtos = new List<MoveDTO>(models.Count());
            foreach (var model in models)
            {
                dtos.Add(model.ToDTO());
            }
            return dtos;
        }
    }
}
