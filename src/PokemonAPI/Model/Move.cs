using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Move
    {
        public int Id;

        public string Name;

        public Type Type;

        public int Power;

        public int PP;

        public int Accuracy;

        public Move(int id, string name, Type type, int power, int pP, int accuracy)
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
