using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleTreeSimulatorConsole.PokemonClasses
{
    public class DamagingMove : IMove
    {
        string Name { get; set; }
        string IMove.Name { get { return Name; } set { Name = value; } }

        Type type { get; set; }
        Type IMove.type { get { return type; } set { type = value; } }

        MoveType moveType { get; set; }
        MoveType IMove.moveType { get { return moveType; } set { moveType = value; } }

        short accuracy { get; set; }
        short IMove.accuracy { get { return accuracy; } set { accuracy = value; } }

        short PP { get; set; }
        short IMove.PP { get { return PP; } set { PP = value; } }

        short basePower { get; set; }

        public DamagingMove(string name, Type type, MoveType moveType, short accuracy, short PP, short basePower)
        {
            this.Name = name;
            this.type = type;
            this.moveType = moveType;
            this.accuracy = accuracy;
            this.PP = PP;
            this.basePower = basePower;
        }

        public short GetBasePower()
        {
            return basePower;
        }
    }
}
