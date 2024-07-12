using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Type
    {
        public string Name;

        public string Typing;

        public Type(string name, string typing)
        {
            Name = name;
            Typing = typing;
        }
    }
}
