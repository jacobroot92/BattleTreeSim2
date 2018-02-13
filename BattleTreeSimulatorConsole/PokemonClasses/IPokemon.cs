using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleTreeSimulatorConsole.PokemonClasses
{
    public interface IPokemon
    {
        Species Species { get; set; }
        short Level { get; set; }
        Nature Nature { get; set; }
        short RemainingHP { get; set; }
        short MaxHP { get; set; }
        short Attack { get; set; }
        short Defense { get; set; }
        short SpecialAttack { get; set; }
        short SpecialDefense { get; set; }
        short Speed { get; set; }
        Item HeldItem { get; set; }

        IMove Move1 { get; set; }
        IMove Move2 { get; set; }
        IMove Move3 { get; set; }
        IMove Move4 { get; set; }

        int DoDamage(double random, double modifier, int level, int basePower);

        void TakeDamage(int damageBase, bool physical);
    }
}
