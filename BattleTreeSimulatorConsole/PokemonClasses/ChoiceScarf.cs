using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleTreeSimulatorConsole.PokemonClasses
{
    class ChoiceScarf : IPokemon
    {
        IPokemon pokemon;

        public ChoiceScarf(IPokemon pokemon)
        {
            this.pokemon = pokemon;
        }
        
        public short RemainingHP { get => pokemon.RemainingHP; set => pokemon.RemainingHP = value; }
        public short MaxHP { get => pokemon.MaxHP; set => pokemon.MaxHP = value; }
        public short Attack { get => pokemon.Attack; set => pokemon.Attack = value; }
        public short Defense { get => pokemon.Defense; set => pokemon.Defense = value; }
        public short SpecialAttack { get => pokemon.SpecialAttack; set => pokemon.SpecialAttack = value; }
        public short SpecialDefense { get => pokemon.SpecialDefense; set => pokemon.SpecialDefense = value; }
        public short Speed { get { return pokeRound(pokemon.Speed * 1.5); } set => pokemon.Speed = value; }
        public Item HeldItem { get => pokemon.HeldItem; set => pokemon.HeldItem = value; }
        public Species Species { get => pokemon.Species; set => pokemon.Species = value; }
        public short Level { get => pokemon.Level; set => pokemon.Level = value; }
        public Nature Nature { get => pokemon.Nature; set => pokemon.Nature = value; }
        IMove IPokemon.Move1 { get => pokemon.Move1; set => pokemon.Move1 = value; }
        IMove IPokemon.Move2 { get => pokemon.Move2; set => pokemon.Move2 = value; }
        IMove IPokemon.Move3 { get => pokemon.Move3; set => pokemon.Move3 = value; }
        IMove IPokemon.Move4 { get => pokemon.Move4; set => pokemon.Move4 = value; }

        public int DoDamage(double random, double modifier, int level, int basePower)
        {
            return pokemon.DoDamage(random, modifier, level, basePower);
        }

        public void TakeDamage(int damageBase, bool physical)
        {
            pokemon.TakeDamage(damageBase, physical);
        }

        private short pokeRound(double number)
        {
            //Rounds double in the same fashion in the games
            return (number % 1 > 0.5) ? (short)Math.Ceiling(number) : (short)Math.Floor(number);
        }
    }
}
