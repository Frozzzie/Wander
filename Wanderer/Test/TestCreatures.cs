using MoonSharp.Interpreter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wanderer.Creatures;
using Wanderer.Creatures.Powers;
using Wanderer.GameComponents;

namespace Wanderer.Test
{
    class TestCreatures
    {
        public static Creature TestPlayer()
        {
            Creature c = new Creature(18, 16, 11, 15, 8, 8); // BIG WARRIOR OOF OOF
            List<Power> p = new List<Power>();
            ScriptPower attack = new ScriptPower();
            attack.PowerName = "Strike";
            attack.NumTargets = 2;
            attack.ScriptString = @"
            
            function Activate (targets)
                for i in ipairs(targets) do
                    local targ = targets[i]:GetTarget()
                    local enemycon = targ:GetStatModifier('con')
                    local mystr = Parent.GetStatModifier('str')
                    targ:Damage(mystr - enemycon)
                end
                
            end ";
            p.Add(attack);
            c.Powers = p;
            //c.SetHP(8);
            c.WriteName("Player Hero");
            //c.LoadSpriteFromFile(@"Images\Sprites\wanderer.png", 80, 80);
            return c;
        }

        public static Creature GardenSnake()
        {
            Creature c = new Creature(12, 10, 18, 14, 5, 5);
            List<Power> p = new List<Power>();
            ScriptPower attack = new ScriptPower();
            attack.PowerName = "Poison Bite";
            attack.Description = "Bite a single target, inflicting STR poison counters";
            attack.ScriptString = @"

            function Activate (targets)
                for i in ipairs(targets) do
                    local targ = targets[i]:GetTarget()
                    local mystr = Parent.GetStatModifier('str')
                    targ:Damage(1)
                    targ:ApplyCounters('poison', mystr)
                end
                
            end
            ";

            p.Add(attack);
            c.Powers = p;
            //c.SetHP(5);
            c.WriteName("Garden Snake");
            //c.LoadSpriteFromFile(@"Images\Sprites\gardensnek.png", 80, 80);
            return c;
        }

        public static Creature HardCodeSnake()
        {
            Creature c = new Creature(12, 10, 18, 14, 5, 5);
            List<Power> p = new List<Power>();
            SnakeBite bite = new SnakeBite(c);
            p.Add(bite);
            c.Powers = p;
            //c.SetHP(5);
            c.WriteName("Garden Snake");
            //c.LoadSpriteFromFile(@"Images\Sprites\gardensnek.png", 80, 80);
            return c;
        }

        public static Creature HardCodeHero()
        {
            Creature c = new Creature(18, 16, 11, 15, 8, 8); // BIG WARRIOR OOF OOF
            List<Power> p = new List<Power>();
            Strike attack = new Strike(c);
            
            p.Add(attack);
            c.Powers = p;
            //c.SetHP(8);
            c.WriteName("Player Hero");
            //c.LoadSpriteFromFile(@"Images\Sprites\wanderer.png", 80, 80);
            return c;
        }

        public static void LuaTesting()
        {
            ScriptInterp.LuaCreatureInterface bi = new ScriptInterp.LuaCreatureInterface(new Creature(10, 10, 0, 10, 10, 10));
            Script s = new Script();
            Table t = bi.CreateScriptTable(s);
            s.Globals["Creature"] = t;

            string script = @"return Creature.GetStat('dex')";

            DynValue r = s.DoString(script);
        }
    }
}
