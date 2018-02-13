using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleTreeSimulatorConsole.PokemonClasses
{
    public class Species
    {
        public string Name { get; set; }
        public Type Type1 { get; set; }
        public Type Type2 { get; set; }

        public short baseHP { get; set; }
        public short baseAtk { get; set; }
        public short baseDef { get; set; }
        public short baseSpAtk { get; set; }
        public short baseSpDef { get; set; }
        public short baseSpeed { get; set; }

        bool CanEvolve { get; set; }

        public Species(string Name, Type Type1, Type Type2, short baseHP, short baseAtk, short baseDef, short baseSpAtk, short baseSpDef, short baseSpeed, bool CanEvolve)
        {
            this.Name = Name;
            this.Type1 = Type1;
            this.Type2 = Type2;
            this.baseHP = baseHP;
            this.baseAtk = baseAtk;
            this.baseDef = baseDef;
            this.baseSpAtk = baseSpAtk;
            this.baseSpDef = baseSpDef;
            this.baseSpeed = baseSpeed;
            this.CanEvolve = CanEvolve;
        }
    }
}
