using BattleTreeSimulatorConsole.PokemonClasses;
using BattleTreeSimulatorConsole.Trainers;
using System;

namespace BattleTreeSimulatorConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var endInput = "";
            DamagingMove move1 = new DamagingMove("Thunderbolt", Type.Electric, MoveType.Special, 100, 15, 90);
            DamagingMove move2 = new DamagingMove("Flamethrower", Type.Fire, MoveType.Special, 100, 15, 90);
            DamagingMove move3 = new DamagingMove("Pound", Type.Normal, MoveType.Physical, 100, 35, 40);

            Species Typhlosion = new Species("Typhlosion", Type.Fire, Type.None, 78, 84, 78, 109, 85, 100, false);
            Species Minccino = new Species("Minccino", Type.Normal, Type.None, 55, 50, 40, 40, 40, 75, true);
            Species Porygon2 = new Species("Porygon2", Type.Normal, Type.None, 85, 80, 90, 105, 95, 60, true);

            IPokemon Pokemon1 = new Pokemon(Minccino, 50, Nature.Adamant, 31, 31, 31, 17, 31, 31, 252, 252, 0, 0, 4, 0, Item.ChoiceBand, move3, null, null, null);
            Pokemon Pokemon2 = new Pokemon(Typhlosion, 50, Nature.Timid, 31, 0, 31, 31, 31, 31, 4, 0, 0, 252, 0, 252, Item.ChoiceScarf, move2, null, null, null);
            IPokemon Pokemon3 = new Pokemon(Porygon2, 50, Nature.Modest, 31, 0, 31, 31, 31, 31, 252, 0, 4, 252, 0, 0, Item.Eviolite, move1, move2, null, null);
            Trainer User = new Trainer("Breeder Jacob", Pokemon1, Pokemon2, Pokemon3);
            Trainer CPU = new Trainer();
            CPU.PopulateRandomCPU();

            var result = Battle.SingleBattle(User, CPU);

            if (result)
                Console.WriteLine(User.Name + " Wins!");
            else
                Console.WriteLine(CPU.Name + " Wins!");
            endInput = Console.ReadLine();
        }
    }
}
