using MoonSharp.Interpreter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wanderer.Creatures.Powers;

namespace Wanderer.ScriptInterp
{
    class LuaTargetingInformationInterface : LuaInterface
    {
        private TargetingInformation targetingInfo_;

        public LuaTargetingInformationInterface(TargetingInformation t)
        {
            targetingInfo_ = t;
        }

        public override void RunScript(MoonSharp.Interpreter.Script s)
        {
            throw new NotImplementedException();
        }

        private Table GetTarget()
        {
            LuaCreatureInterface lci = new LuaCreatureInterface(targetingInfo_.Target);
            return lci.CreateScriptTable(new Script());
        }

        private bool IsFriendly()
        {
            return targetingInfo_.IsFriendly;
        }

        public override MoonSharp.Interpreter.Table CreateScriptTable(MoonSharp.Interpreter.Script s)
        {
            Table t = new Table(s);
            t["GetTarget"] = (Func<Table>)GetTarget;
            t["IsFriendly"] = (Func<bool>)IsFriendly;
            return t;            
        }
    }
}
