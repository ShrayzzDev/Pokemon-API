using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TypeDTO
    {
        public string Name { get; set; }

        public string Typing { get; set; }

        public TypeDTO(string name, string typing)
        {
            Name = name;
            Typing = typing;
        }
    }
}
