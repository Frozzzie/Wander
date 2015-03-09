using MoonSharp.Interpreter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wanderer.Creatures;
using Wanderer.GameComponents;
using Wanderer.GameComponents.BattleComponents;

namespace Wanderer.ScriptInterp
{
    class LuaBattleInterface : LuaInterface
    {
        Battle battle_;

        public LuaBattleInterface(Battle battle)
        {
            battle_ = battle;
        }

        public override void RunScript(Script s)
        {
            
        }

        private LuaCreatureInterface CurrentTurnCreature()
        {
            return new LuaCreatureInterface(battle_.GetCurrentTurnCreature());
        }

        private List<LuaCreatureInterface> LeftPlayerCreatures()
        {
            List<LuaCreatureInterface> result = new List<LuaCreatureInterface>();
            battle_.GetLeftPlayerCreatures().ForEach(x => result.Add(new LuaCreatureInterface(x)));
            return result;
        }

        private List<LuaCreatureInterface> RightPlayerCreatures()
        {
            List<LuaCreatureInterface> result = new List<LuaCreatureInterface>();
            battle_.GetRightPlayerCreatures().ForEach(x => result.Add(new LuaCreatureInterface(x)));
            return result;
        }


        public override Table CreateScriptTable(Script s)
        {
            Table t = new Table(s);
            t["CurrentTurnCreature"] = (Func<LuaCreatureInterface>)CurrentTurnCreature;
            t["LeftPlayerCreatures"] = (Func<List<LuaCreatureInterface>>)LeftPlayerCreatures;
            t["RightPlayerCreatures"] = (Func<List<LuaCreatureInterface>>)RightPlayerCreatures;
            return t;
        }
    }
}
