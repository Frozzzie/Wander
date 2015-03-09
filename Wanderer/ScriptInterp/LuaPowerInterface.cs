using MoonSharp.Interpreter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wanderer.Creatures.Powers;

namespace Wanderer.ScriptInterp
{
    class LuaPowerInterface : LuaInterface
    {
        private ScriptPower power_;
         
        private List<LuaTargetingInformationInterface> targets_;

        public LuaPowerInterface(ScriptPower power, List<TargetingInformation> targets)
        {
            power_ = power;
            targets_ = new List<LuaTargetingInformationInterface>();
            targets.ForEach(x => targets_.Add(new LuaTargetingInformationInterface(x)));
        }

        public override void RunScript(MoonSharp.Interpreter.Script s)
        {
            List<Table> targets = new List<Table>();
            foreach (LuaTargetingInformationInterface targ in targets_)
            {
                Table innertarget = targ.CreateScriptTable(s);
                targets.Add(innertarget);
            }
            LuaCreatureInterface lci = new LuaCreatureInterface(power_.Parent);
            s.Globals["Parent"] = lci.CreateScriptTable(s);
            s.LoadString(power_.ScriptString);
            try
            {
                s.DoString(power_.ScriptString);
                DynValue result = s.Call(s.Globals["Activate"], targets);
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message, "Lua Error", System.Windows.MessageBoxButton.OK);
                return;
            }
        }

        public override MoonSharp.Interpreter.Table CreateScriptTable(MoonSharp.Interpreter.Script s)
        {
            throw new NotImplementedException();
        }
    }
}
