using BattleTreeSimulatorConsole.PokemonClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleTreeSimulatorConsole.Trainers
{
    class Trainer
    {
        public IPokemon Pokemon1 { get; set; }
        public IPokemon Pokemon2 { get; set; }
        public IPokemon Pokemon3 { get; set; }

        public Trainer()
        {
            //Blank to randomly populate computer trainer
        }

        public Trainer(IPokemon pokemon1, IPokemon pokemon2, IPokemon pokemon3)
        {
            Pokemon1 = pokemon1;
            Pokemon2 = pokemon2;
            Pokemon3 = pokemon3;
        }

        public bool HasRemainingPokemon()
        {
            if(Pokemon1.RemainingHP > 0)
            {
                return true;
            }
            else if(Pokemon2.RemainingHP > 0)
            {
                return true;
            }
            else if(Pokemon3.RemainingHP > 0)
            {
                return true;
            }

            return false;
        }

        public void PopulateRandomCPU()
        {
            DamagingMove move1 = new DamagingMove("Thunderbolt", Type.Electric, MoveType.Special, 100, 15, 90);
            Species Pichu = new Species("Pichu", Type.Electric, Type.None, 20, 40, 15, 35, 35, 60, true);
            Species Pikachu = new Species("Pikachu", Type.Electric, Type.None, 35, 55, 40, 50, 50, 90, true);
            Species Raichu = new Species("Raichu", Type.Electric, Type.Psychic, 60, 85, 50, 95, 85, 110, false);

            Pokemon3 = new Pokemon(Pichu, 50, Nature.Timid, 31, 0, 31, 31, 31, 31, 4, 0, 0, 252, 0, 252, Item.Eviolite, move1, null, null, null);
            Pokemon2 = new Pokemon(Pikachu, 50, Nature.Timid, 31, 0, 31, 31, 31, 31, 4, 0, 0, 252, 0, 252, Item.ChoiceScarf, move1, null, null, null);
            Pokemon1 = new Pokemon(Raichu, 50, Nature.Timid, 31, 0, 31, 31, 31, 31, 4, 0, 0, 252, 0, 252, Item.ChoiceBand, move1, null, null, null);
        }
    }
}
