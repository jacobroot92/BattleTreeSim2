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
            Random random = new Random();
            DamagingMove move1 = new DamagingMove("Thunderbolt", Type.Electric, MoveType.Special, 100, 15, 90);
            DamagingMove move2 = new DamagingMove("Flamethrower", Type.Fire, MoveType.Special, 100, 15, 90);
            Species Typhlosion = new Species("Typhlosion", Type.Fire, Type.None, 78, 84, 78, 109, 85, 100, false);
            Pokemon Pokemon1 = new Pokemon(Typhlosion, 50, Nature.Timid, 31, 0, 31, 31, 31, 31, 4, 0, 0, 252, 0, 252, Item.ChoiceScarf, move2, null, null, null);
            //IPokemon Pokemon2 = new Pokemon("Pikachu", 200, 50, 50, 50, 50, 5, Item., move1, null, null, null);
            //IPokemon Pokemon3 = new Pokemon("Porygon2", 200, 50, 50, 50, 50, 2, Item.Eviolite, move1, move2, null, null);
            Pokemon Pokemon2 = new Pokemon(Pokemon1);
            Pokemon Pokemon3 = new Pokemon(Pokemon1);
            Trainer User = new Trainer(Pokemon1, Pokemon2, Pokemon3);
            Trainer CPU = new Trainer();
            CPU.PopulateRandomCPU();
            IPokemon pkmn1;
            IPokemon pkmn2;
            int round = 1;

            var userPokemon = User.Pokemon1;
            var CPUPokemon = CPU.Pokemon1;


            Console.WriteLine("Pokemon 1: "+ userPokemon.Species.Name + " HP: "+userPokemon.MaxHP + " Atk: "+userPokemon.Attack + " Def: "+ userPokemon.Defense 
                                + " Sp. Atk: "+userPokemon.SpecialAttack + " Sp. Def: " + userPokemon.SpecialDefense + " Speed: "+userPokemon.Speed);
            Console.WriteLine("Pokemon 2: " + CPUPokemon.Species.Name + " HP: " + CPUPokemon.MaxHP + " Atk: " + CPUPokemon.Attack + " Def: " + CPUPokemon.Defense
                                + " Sp. Atk: " + CPUPokemon.SpecialAttack + " Sp. Def: " + CPUPokemon.SpecialDefense + " Speed: " + CPUPokemon.Speed);

            while (userPokemon.RemainingHP > 0 && CPU.Pokemon1.RemainingHP > 0)
            {
                userPokemon = Update(userPokemon, userPokemon.Move1);
                CPUPokemon = Update(CPUPokemon, CPUPokemon.Move1);

                if (userPokemon.Speed > CPUPokemon.Speed)
                {
                    pkmn1 = userPokemon;
                    pkmn2 = CPUPokemon;
                }
                else if (userPokemon.Speed < CPUPokemon.Speed)
                {
                    pkmn1 = CPUPokemon;
                    pkmn2 = userPokemon;
                }
                else
                {
                    if(GetRandomNumber(0,1,random) > 0.5)
                    {
                        pkmn1 = userPokemon;
                        pkmn2 = CPUPokemon;
                    }
                    else
                    {
                        pkmn1 = CPUPokemon;
                        pkmn2 = userPokemon;
                    }
                }
                Console.WriteLine("Round " + round);
                Battle(pkmn1, pkmn2, GetRandomNumber(0.85, 1.0, random), GetRandomNumber(0.85, 1.0, random));
                round++;
            }

            if (userPokemon.RemainingHP > 0)
                Console.WriteLine(userPokemon.Species.Name + " Wins!");
            else
                Console.WriteLine(CPUPokemon.Species.Name + " Wins!");
            endInput = Console.ReadLine();
        }

        private static IPokemon Update(IPokemon pokemon, IMove MoveSelected)
        {
            IPokemon updatedPokemon = pokemon;
            switch(pokemon.HeldItem)
            {
                case Item.ChoiceBand:
                    if(MoveSelected.moveType == MoveType.Physical)
                        updatedPokemon = new ChoiceBand(pokemon);
                    break;
                case Item.ChoiceScarf:
                    updatedPokemon = new ChoiceScarf(pokemon);
                    break;
                case Item.Eviolite:
                    updatedPokemon = new Eviolite(pokemon);
                    break;
            }

            if (MoveSelected.type == updatedPokemon.Species.Type1 || MoveSelected.type == updatedPokemon.Species.Type2 && MoveSelected.type != Type.None)
                updatedPokemon = new STAB(updatedPokemon);

            return updatedPokemon;
        }

        static public double GetRandomNumber(double minimum, double maximum, Random random)
        {
            return random.NextDouble() * (maximum - minimum) + minimum;
        }

        static public void Battle(IPokemon pkmn1, IPokemon pkmn2, double random1, double random2)
        {
            IMove move = pkmn1.Move1;
            Console.WriteLine(pkmn1.Species.Name + " uses " + move.Name + "!");

            pkmn2.TakeDamage(pkmn1.DoDamage(random1, 1, pkmn1.Level, move.GetBasePower()), false);
            Console.WriteLine();

            if (pkmn2.RemainingHP > 0)
            {
                move = pkmn2.Move1;
                Console.WriteLine(pkmn2.Species.Name + " uses " + move.Name+"!");
                pkmn1.TakeDamage(pkmn2.DoDamage(random2, 1, pkmn2.Level, move.GetBasePower()), true);
                Console.WriteLine();
            }
        }
    }
}
