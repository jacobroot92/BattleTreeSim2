using System;
using BattleTreeSimulatorConsole.Trainers;
using BattleTreeSimulatorConsole.PokemonClasses;

namespace BattleTreeSimulatorConsole
{
    public class Battle
    {
        public static bool SingleBattle(Trainer User, Trainer CPU)
        {
            Random random = new Random();
            IPokemon pkmn1;
            IPokemon pkmn2;
            int round = 1;

            var userPokemon = User.Pokemon1;
            var CPUPokemon = CPU.Pokemon1;

            short userPokemonCount = 1;
            short CPUPokemonCount = 1;

            while (userPokemon.RemainingHP > 0 && CPUPokemon.RemainingHP > 0)
            {
                SpeedCheck(userPokemon, CPUPokemon, random, out pkmn1, out pkmn2);
                userPokemon = Update(userPokemon, userPokemon.Move1);
                CPUPokemon = Update(CPUPokemon, CPUPokemon.Move1);
                Console.WriteLine("Round " + round);
                Attack(pkmn1, pkmn2, GetRandomNumber(0.85, 1.0, random), GetRandomNumber(0.85, 1.0, random));
                round++;
                if(userPokemon.RemainingHP <= 0 && userPokemonCount < 3)
                {
                    if (userPokemonCount == 1)
                        userPokemon = User.Pokemon2;
                    else
                        userPokemon = User.Pokemon3;
                    userPokemonCount++;
                }
                if (CPUPokemon.RemainingHP <= 0 && CPUPokemonCount < 3)
                {
                    if (CPUPokemonCount == 1)
                        CPUPokemon = CPU.Pokemon2;
                    else
                        CPUPokemon = CPU.Pokemon3;
                    CPUPokemonCount++;
                }
            }

            if (userPokemon.RemainingHP > 0)
                return true;
            else
                return false;
        }

        private static IPokemon Update(IPokemon pokemon, IMove MoveSelected)
        {
            IPokemon updatedPokemon = pokemon;
            switch (pokemon.HeldItem)
            {
                case Item.ChoiceBand:
                    if (MoveSelected.moveType == MoveType.Physical)
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

        static public void Attack(IPokemon pkmn1, IPokemon pkmn2, double random1, double random2)
        {
            IMove move = pkmn1.Move1;
            Console.WriteLine(pkmn1.Species.Name + " uses " + move.Name + "!");

            pkmn2.TakeDamage(pkmn1.DoDamage(random1, 1, pkmn1.Level, move.GetBasePower()), false);
            Console.WriteLine();

            if (pkmn2.RemainingHP > 0)
            {
                move = pkmn2.Move1;
                Console.WriteLine(pkmn2.Species.Name + " uses " + move.Name + "!");
                pkmn1.TakeDamage(pkmn2.DoDamage(random2, 1, pkmn2.Level, move.GetBasePower()), true);
                Console.WriteLine();
            }
        }

        static public void SpeedCheck(IPokemon userPokemon, IPokemon CPUPokemon, Random random, out IPokemon pkmn1, out IPokemon pkmn2)
        {

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
                if (GetRandomNumber(0, 1, random) > 0.5)
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

        }
    }
}
