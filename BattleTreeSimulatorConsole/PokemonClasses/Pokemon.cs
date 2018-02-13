using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleTreeSimulatorConsole.PokemonClasses
{
    public class Pokemon : IPokemon
    {
        public Species Species;
        public short Level;
        public Nature Nature;
        public short RemainingHP;
        public short MaxHP;
        public short Attack;
        public short Defense;
        public short SpecialAttack;
        public short SpecialDefense;
        public short Speed;
        public Item HeldItem;

        public IMove Move1;
        public IMove Move2;
        public IMove Move3;
        public IMove Move4;

        Species IPokemon.Species { get { return Species; } set { Species = value; } }
        short IPokemon.RemainingHP { get { return RemainingHP; } set { RemainingHP = value; } }
        short IPokemon.MaxHP { get { return MaxHP; } set { MaxHP = value; } }
        short IPokemon.Attack { get { return Attack; } set { Attack = value; } }
        short IPokemon.Defense { get { return Defense; } set { Defense = value; } }
        short IPokemon.SpecialAttack { get { return SpecialAttack; } set { SpecialAttack = value; } }
        short IPokemon.SpecialDefense { get { return SpecialDefense; } set { SpecialDefense = value; } }
        short IPokemon.Speed { get { return Speed; } set { Speed = value; } }
        Item IPokemon.HeldItem { get { return HeldItem; } set { HeldItem = value; } }
        IMove IPokemon.Move1 { get { return Move1; } set { Move1 = value; } }
        IMove IPokemon.Move2 { get { return Move2; } set { Move2 = value; } }
        IMove IPokemon.Move3 { get { return Move3; } set { Move3 = value; } }
        IMove IPokemon.Move4 { get { return Move4; } set { Move4 = value; } }
        short IPokemon.Level { get { return Level; } set { Level = value; } }
        Nature IPokemon.Nature { get { return Nature; } set { Nature = value; } }

        public Pokemon (Pokemon pokemon)
        {
            Species = pokemon.Species;
            RemainingHP = pokemon.RemainingHP;
            MaxHP = pokemon.MaxHP;
            Attack = pokemon.Attack;
            Defense = pokemon.Defense;
            SpecialAttack = pokemon.SpecialAttack;
            SpecialDefense = pokemon.SpecialDefense;
            Speed = pokemon.Speed;
            HeldItem = pokemon.HeldItem;
            Move1 = pokemon.Move1;
            Move2 = pokemon.Move2;
            Move3 = pokemon.Move3;
            Move4 = pokemon.Move4;
        }

        public Pokemon (Species species, short Level, Nature nature, short HPIV, short AttackIV, short DefenseIV, short SpecialAttackIV, short SpecialDefenseIV, short SpeedIV, 
                            short HPEV, short AttackEV, short DefenseEV, short SpecialAttackEV, short SpecialDefenseEV, short SpeedEV, Item HeldItem,  IMove Move1, IMove Move2, IMove Move3, IMove Move4)
        {
            this.Level = Level;
            Nature = nature;
            Species = species;
            RemainingHP = MaxHP = calculateStat(Level, species.baseHP, HPIV, HPEV, "HP", nature);
            Attack = calculateStat(Level, species.baseAtk, AttackIV, AttackEV, "Attack", nature);
            Defense = calculateStat(Level, species.baseDef, DefenseIV, DefenseEV, "Defense", nature);
            SpecialAttack = calculateStat(Level, species.baseSpAtk, SpecialAttackIV, SpecialAttackEV, "Special Attack", nature);
            SpecialDefense = calculateStat(Level, species.baseSpDef, SpecialDefenseIV, SpecialDefenseEV, "Special Defense", nature);
            Speed = calculateStat(Level, species.baseSpeed, SpeedIV, SpeedEV, "Speed", nature);
            this.HeldItem = HeldItem;
            this.Move1 = Move1;
            this.Move2 = Move2;
            this.Move3 = Move3;
            this.Move4 = Move4;
        }

        public int DoDamage(double random, double modifier, int level, int basePower)
        {
            int baseAttack;

            if (Move1.moveType == MoveType.Physical)
                baseAttack = Attack;
            else
                baseAttack = SpecialAttack;

            return pokeRound((((2*level)/5)+2)*baseAttack*basePower*modifier*random);
        }

        public void TakeDamage(int damageBase, bool physical)
        {
            int baseDefense;
            
            if (physical)
                baseDefense = Defense;
            else
                baseDefense = SpecialDefense;

            var damageAfterDefense = damageBase / (50* baseDefense);
            var roundedDamage = pokeRound(damageAfterDefense+2);
            if (roundedDamage > RemainingHP)
                RemainingHP = 0;
            else if (roundedDamage > 0)
                RemainingHP -= (short)roundedDamage;
            Console.WriteLine(Species.Name + " has " + RemainingHP + " HP remaining!");
        }

        public int pokeRound(double number)
        {
            //Rounds double in the same fashion in the games
            return (number % 1 > 0.5) ? (int)Math.Ceiling(number) : (int)Math.Floor(number);
        }

        private short calculateStat(short level, short baseStat, short IV, short EV, string stat, Nature nature)
        {
            int result = 0;
            int temp = 2 * baseStat;
            double temp2 = EV / 4.0;
            temp2 += (IV + temp);
            temp2 *= level;
            temp = pokeRound(temp2 / 100);

            if (stat == "HP")
            {
                result = temp + level + 10;
            }
            else
            {
                temp += 5;
                result = temp;
                if (stat == "Attack")
                {
                    if (nature == Nature.Adamant || nature == Nature.Brave || nature == Nature.Lonely || nature == Nature.Naughty)
                        result = pokeRound(temp * 1.1);
                    else if (nature == Nature.Bold || nature == Nature.Calm || nature == Nature.Modest || nature == Nature.Timid)
                        result = pokeRound(temp * 0.9);
                }
                else if (stat == "Defense")
                {
                    if (nature == Nature.Bold || nature == Nature.Impish || nature == Nature.Lax || nature == Nature.Relaxed)
                        result = pokeRound(temp * 1.1);
                    else if (nature == Nature.Gentle || nature == Nature.Hasty || nature == Nature.Lonely || nature == Nature.Mild)
                        result = pokeRound(temp * 0.9);
                }
                else if (stat == "Special Attack")
                {
                    if (nature == Nature.Mild || nature == Nature.Modest || nature == Nature.Quiet || nature == Nature.Rash)
                        result = pokeRound(temp * 1.1);
                    else if (nature == Nature.Adamant || nature == Nature.Careful || nature == Nature.Impish || nature == Nature.Jolly)
                        result = pokeRound(temp * 0.9);
                }
                else if (stat == "Special Defense")
                {
                    if (nature == Nature.Calm || nature == Nature.Careful || nature == Nature.Gentle || nature == Nature.Sassy)
                        result = pokeRound(temp * 1.1);
                    else if (nature == Nature.Lax || nature == Nature.Naive || nature == Nature.Naughty || nature == Nature.Rash)
                        result = pokeRound(temp * 0.9);
                }
                else if (stat == "Speed")
                {
                    if (nature == Nature.Hasty || nature == Nature.Jolly || nature == Nature.Naive || nature == Nature.Timid)
                        result = pokeRound(temp * 1.1);
                    else if (nature == Nature.Brave || nature == Nature.Quiet || nature == Nature.Relaxed || nature == Nature.Sassy)
                        result = pokeRound(temp * 0.9);
                }
            }

            return (short)result;
        }
    }
}
