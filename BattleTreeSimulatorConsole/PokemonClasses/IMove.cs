using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleTreeSimulatorConsole.PokemonClasses
{
    public interface IMove
    {
        string Name { get; set; }
        Type type { get; set; }
        MoveType moveType { get; set; }
        short accuracy { get; set; }
        short PP { get; set; }

        short GetBasePower();
    }
}
