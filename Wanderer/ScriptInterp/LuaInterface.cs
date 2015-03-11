using MoonSharp.Interpreter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wanderer.ScriptInterp
{
    abstract class LuaInterface
    {
        public abstract void RunScript(Script s);
        public abstract Table CreateScriptTable(Script s);

        protected void TypeCheck(DynValue v, DataType type)
        {
            if (v.Type != type)
                throw new Exception("ERROR: Expected " + type.ToLuaTypeString() + ", got " + v.Type.ToLuaTypeString());
        }
    }
}
