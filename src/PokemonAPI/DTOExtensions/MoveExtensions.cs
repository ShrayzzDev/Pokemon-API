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
    }
}
