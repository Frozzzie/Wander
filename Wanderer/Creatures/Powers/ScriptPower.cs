using MoonSharp.Interpreter;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wanderer.ScriptInterp;

namespace Wanderer.Creatures.Powers
{
    class ScriptPower : Power
    {
        public string ScriptString { get { return script; } set { script = value; } }
        private string script;

        public ScriptPower()
        {

        }

        public ScriptPower(string filename)
        {
            script = File.ReadAllText(filename);
        }

        public override void Activate(List<TargetingInformation> targets)
        {
            LuaPowerInterface lpi = new LuaPowerInterface(this, targets);
            Script s = new Script();
            lpi.RunScript(s);
        }

        public override void WriteToJson(Newtonsoft.Json.JsonWriter writer)
        {
            base.WriteToJson(writer);
            writer.WritePropertyName("Script");
            writer.WriteValue(script);
        }

        public override void ReadFromJson(Newtonsoft.Json.JsonReader reader)
        {
            base.ReadFromJson(reader);
            while (reader.Read())
            {
                if (reader.TokenType == JsonToken.PropertyName && reader.Value == "Script")
                    script = reader.ReadAsString();
            }
        }
    }
}
