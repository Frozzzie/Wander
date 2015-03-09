using MoonSharp.Interpreter;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wanderer.Screens;
using Wanderer.ScriptInterp;

namespace Wanderer.Creatures.Powers
{
    public abstract class Power
    {
        private string powerName_;
        private int numTargets_;
        public string PowerName { get { return powerName_; } set { powerName_ = value; } }
        public int NumTargets { get { return numTargets_; } set { numTargets_ = value; } }
        

        public string Description { get; set; }

        protected Creature parent_;
        public Creature Parent { get { return parent_; } set { parent_ = value; } }

        public Power()
        {
        }

        public Power(Creature creature)
        {
            parent_ = creature;
        }

        public Power(string filename)
        {
        }


        public virtual void WriteToJson(JsonWriter writer)
        {
            writer.WritePropertyName("Name");
            writer.WriteValue(powerName_);
            writer.WritePropertyName("NumTargets");
            writer.WriteValue(numTargets_);
            
        }

        public virtual void ReadFromJson(JsonReader reader)
        {
            while (reader.Read())
            {
                if (reader.TokenType == JsonToken.PropertyName && reader.Value == "Name")
                    powerName_ = reader.ReadAsString();
                else if (reader.TokenType == JsonToken.PropertyName && reader.Value == "NumTargets")
                    numTargets_ = (int)reader.ReadAsInt32();
                else
                    break;
            }
        }

        public abstract void Activate(List<TargetingInformation> targets);

        public void ActivateScript(List<TargetingInformation> targets)
        {
            
        }

        public void WriteToFile(StreamWriter writer)
        {
            // for when we are storing them not inside a creature
            writer.Write("Name:");
            writer.WriteLine(powerName_);
            writer.Write("NumTargets:");
            writer.WriteLine(numTargets_);
            writer.WriteLine("{");
            writer.Write("Script:");
            writer.WriteLine();
            writer.Write("}");
        }
    }
}
