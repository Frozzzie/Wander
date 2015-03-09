using MoonSharp.Interpreter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wanderer.Creatures;

namespace Wanderer.ScriptInterp
{
    class LuaCreatureInterface : LuaInterface
    {
        private Creature creature_;
        public LuaCreatureInterface(Creature c)
        {
            creature_ = c;
        }

        public override void RunScript(MoonSharp.Interpreter.Script s)
        {
            
        }

        #region Creature Manipulation
        private int Damage(int damage)
        {
            creature_.ApplyDamage(damage);
            return -1;
        }
        private int GetHealth()
        {
            return creature_.CurrentHealth;
        }
        private int SetHealth(int setTo)
        {
            creature_.SetCurrentHealth(setTo);
            return -1;
        }
        private int GetStat(string statname)
        {
            return creature_.GetStatByName(statname);
        }
        private int GetStatModifier(string statname)
        {
            return creature_.GetStatByName(statname + " Modifier");
        }
        private int GetCounterCount(string countername)
        {
            return creature_.GetStatByName("Poison");
        }
        private int ApplyCounters(string name, int amount)
        {
            
            return -1;
        }
        private int SetStat(string statname, int changeTo)
        {
            return -1;
        }
        private int SetCounter(string countername, int changeTo)
        {
            return -1;
        }
        #endregion
       
        public override MoonSharp.Interpreter.Table CreateScriptTable(Script s)
        {
            Table t = new Table(s);
            t["Damage"] = (Func<int, int>)Damage;
            t["GetHealth"] = (Func<int>)GetHealth;
            t["SetHealth"] = (Func<int, int>)SetHealth;
            t["GetStat"] = (Func<string, int>)GetStat;
            t["GetStatModifier"] = (Func<string, int>)GetStatModifier;
            t["GetCounterCount"] = (Func<string, int>)GetCounterCount;
            t["ApplyCounters"] = (Func<string, int, int>)ApplyCounters;
            t["SetStat"] = (Func<string, int, int>)SetStat;
            t["SetCounter"] = (Func<string, int, int>)SetCounter;
            t["Name"] = creature_.Name;
            
            return t;
        }
    }
}
