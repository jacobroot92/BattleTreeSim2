using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleTreeSimulatorConsole.PokemonClasses
{
    class ChoiceBand : IPokemon
    {
        IPokemon pokemon;

        public ChoiceBand(IPokemon pokemon)
        {
            this.pokemon = pokemon;
        }
        
        public short RemainingHP { get { return pokemon.RemainingHP; } set { pokemon.RemainingHP = value; } }
        public short MaxHP { get { return pokemon.MaxHP; } set { pokemon.MaxHP = value; } }
        public short Attack { get { return pokemon.Attack; } set { pokemon.Attack = value; } }
        public short Defense { get { return pokemon.Defense; } set { pokemon.Defense = value; } }
        public short SpecialAttack { get => pokemon.SpecialAttack; set => pokemon.SpecialAttack = value; }
        public short SpecialDefense { get => pokemon.SpecialDefense; set => pokemon.SpecialDefense = value; }
        public short Speed { get { return pokemon.Speed; } set { pokemon.Speed = value; } }
        public Item HeldItem { get => pokemon.HeldItem; set => pokemon.HeldItem = value; }
        public Species Species { get => pokemon.Species; set => pokemon.Species = value; }
        public short Level { get => pokemon.Level; set => pokemon.Level = value; }
        public Nature Nature { get => pokemon.Nature; set => pokemon.Nature = value; }
        IMove IPokemon.Move1 { get => pokemon.Move1; set => pokemon.Move1 = value; }
        IMove IPokemon.Move2 { get => pokemon.Move2; set => pokemon.Move2 = value; }
        IMove IPokemon.Move3 { get => pokemon.Move3; set => pokemon.Move3 = value; }
        IMove IPokemon.Move4 { get => pokemon.Move4; set => pokemon.Move4 = value; }
        

        int IPokemon.DoDamage(double random, double modifier, int level, int basePower)
        {
            return pokemon.DoDamage(random, modifier * 1.5, level, basePower);
        }

        private int pokeRound(double number)
        {
            //Rounds double in the same fashion in the games
            return (number % 1 > 0.5) ? (int)Math.Ceiling(number) : (int)Math.Floor(number);
        }

        void IPokemon.TakeDamage(int damageBase, bool physical)
        {
            pokemon.TakeDamage(damageBase, physical);
        }
    }
}
