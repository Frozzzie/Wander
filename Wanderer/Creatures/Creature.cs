using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SdlDotNet.Graphics.Sprites;
using SdlDotNet.Graphics;
using System.Drawing;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Wanderer.Creatures.Powers;
using System.IO;
using Wanderer.Counters;
using Wanderer.Creatures.Stats.StatusStats;
using Wanderer.Creatures.Stats;
using Wanderer.Creatures.Stats.BaseStats;
using Wanderer.Creatures.Stats.DerivedStats;
using Wanderer.EntityEngine;

namespace Wanderer.Creatures
{
    public class Creature : IComparable<Creature>, IGameEntity
    {
        private List<Power> powers_;
        private List<Buff<Stat>> buffs_;

        private List<Stat> _stats;

        public List<Power> Powers { get { return powers_; } set { powers_ = value; powers_.ForEach(x => x.Parent = this); } }

        private Sprite drawable_;

        public void LoadImage(string filename)
        {
            var sc = new SurfaceCollection();
            
            //Sprite s = new Sprite(System.IO.Path.Combine(System.Environment.CurrentDirectory, filename));
            sc.Add(new Surface(new Bitmap(System.IO.Path.Combine(System.Environment.CurrentDirectory, filename))));
            
            drawable_ = new AnimatedSprite(sc);

        }

        internal int CurrentSpeed { get; private set; }


        public void IncrementSpeed()
        {
            if (IsDead)
                CurrentSpeed = -1;
            else
                CurrentSpeed += GetValue<Speed>();
        }

        public void ResetSpeed()
        {
            CurrentSpeed = 0;
        }

        public void ApplyInitiative()
        {
            CurrentSpeed = GetValue<Initiative>();
        }

        public class DamagedEventArgs : EventArgs
        {
            public int Damage { get; private set; }
            // public DamageType Type {get; private set; }
            public DamagedEventArgs(int damage)
            {
                Damage = damage;
            }
        }

        public delegate void DamagedEventHandler(object sender, DamagedEventArgs args);
        public event DamagedEventHandler Damaged;

        public class TargetedEventArgs : EventArgs
        {
            public Creature TargetSource { get; private set; }
            public Power TargetPower { get; private set; }

            public TargetedEventArgs(Creature targetSource, Power targetPower)
            {
                TargetSource = targetSource;
                TargetPower = targetPower;
            }
        }

        public delegate void TargetedEventHandler(object sender, TargetedEventArgs args);
        public event TargetedEventHandler Targeted;

        private AnimatedSprite _currentAnimation;
        private string creatureName_ = "";
        public int CurrentHealth { get { return GetValue<HealthStat>(); } }
        public string Name { get { return creatureName_; } }

        public StrengthStat Strength { get { return GetStat<StrengthStat>(); } set { GetStat<StrengthStat>().Value = value.Value; } }
        public ConstitutionStat Constution { get { return GetStat<ConstitutionStat>(); } set { GetStat<ConstitutionStat>().Value = value.Value; } }
        public DexterityStat Dexterity { get { return GetStat<DexterityStat>(); } set { GetStat<DexterityStat>().Value = value.Value; } }
        public PerceptionStat Perception { get { return GetStat<PerceptionStat>(); } set { GetStat<PerceptionStat>().Value = value.Value; } }
        public IntelligenceStat Intelligence { get { return GetStat<IntelligenceStat>(); } set { GetStat<IntelligenceStat>().Value = value.Value; } }
        public WisdomStat Wisdom { get { return GetStat<WisdomStat>(); } set { GetStat<WisdomStat>().Value = value.Value; } }

        public Speed Speed { get { return GetStat<Speed>(); } }
        public MaxHealth MaxHealth { get { return GetStat<MaxHealth>(); } }
        public Initiative Initiative { get { return GetStat<Initiative>(); } }
        public HealthStat Health { get { return GetStat<HealthStat>(); } set { GetStat<DamageStat>().Value = MaxHealth - value; } }


        public ModifierStat<StrengthStat> StrMod { get { return GetModifier<StrengthStat>(); } }
        public ModifierStat<ConstitutionStat> ConMod { get { return GetModifier<ConstitutionStat>(); } }
        public ModifierStat<DexterityStat> DexMod { get { return GetModifier<DexterityStat>(); } }
        public ModifierStat<PerceptionStat> PerMod { get { return GetModifier<PerceptionStat>(); } }
        public ModifierStat<IntelligenceStat> IntMod { get { return GetModifier<IntelligenceStat>(); } }
        public ModifierStat<WisdomStat> WisMod { get { return GetModifier<WisdomStat>(); } }

        /// <summary>
        /// Blank creature with the following stats:
        /// </summary>
        /// <param name="str">Base Strength</param>
        /// <param name="con">Base Constitution</param>
        /// <param name="dex">Base Dexterity</param>
        /// <param name="per">Base Perception</param>
        /// <param name="intel">Base Intelligence</param>
        /// <param name="wis">Base Wisdom</param>
        public Creature(int str, int con, int dex, int per, int intel, int wis)
        {
            _stats = new List<Stat>();

            AddStat(new StrengthStat(str), new ConstitutionStat(con), new DexterityStat(dex), new PerceptionStat(per),
                    new IntelligenceStat(intel), new WisdomStat(wis));

            AddStat(new ModifierStat<StrengthStat>(GetStat<StrengthStat>()), new ModifierStat<ConstitutionStat>(GetStat<ConstitutionStat>()),
                    new ModifierStat<DexterityStat>(GetStat<DexterityStat>()), new ModifierStat<PerceptionStat>(GetStat<PerceptionStat>()),
                    new ModifierStat<IntelligenceStat>(GetStat<IntelligenceStat>()), new ModifierStat<WisdomStat>(GetStat<WisdomStat>()));

            DamageStat damage = new DamageStat();
            MaxHealth maxhealth = new MaxHealth(GetModifier<ConstitutionStat>());
            HealthStat health = new HealthStat(maxhealth, damage);
            Initiative initiative = new Initiative(GetStat<WisdomStat>(), GetStat<PerceptionStat>());
            Speed speed = new Speed(GetStat<DexterityStat>());

            AddStat(damage, maxhealth, health, initiative, speed);
        }

        private void AddStat(params Stat[] stats)
        {
            foreach (Stat s in stats)
                _stats.Add(s);
        }

        public void ApplyDamage(int dmg)
        {
            dmg = Math.Max(dmg, 1);
            GetStat<HealthStat>().Value -= dmg;
            if (Damaged != null)
                Damaged.Invoke(this, new DamagedEventArgs(dmg));
        }

        public void ApplyDamage<T>(Stat attack) where T : Stat
        {
            ApplyDamage(GetModifier<T>().Value - attack.Value);
        }

        public void AddHealth(int health)
        {
            var Health = GetStat<HealthStat>();
            var maxHealth = GetStat<MaxHealth>();
            Health.Value = Math.Min(maxHealth.Value, Health.Value + health);
        }

        public void SetCurrentHealth(int hp)
        {
            GetStat<HealthStat>().Value = Math.Min(hp, GetValue<MaxHealth>());
        }
        #region Stat nonsense
        public int GetStatByName(string name)
        {
            return _stats.First(x => x.Name.ToLower() == name.ToLower()).Value;
        }

        public int GetModifierByName(string name)
        {
            return GetStatByName(name + " Modifier");
        }

        public Stat GetModStat(string name)
        {
            return _stats.First(x => x.Name.ToLower() == name.ToLower());
        }

        public int CompareTo(Creature other)
        {
            return other.CurrentSpeed - CurrentSpeed;
        }

        private T GetStatus<T>() where T : Stat, IStatus
        {
            return _stats.First(x => x is T) as T;
        }

        public T GetStat<T>() where T : Stat
        {
            return _stats.First(x => x is T) as T;
        }

        private int GetValue<T>() where T : Stat
        {
            return GetStat<T>().Value;
        }

        private ModifierStat<T> GetModifier<T>() where T : Stat
        {
            return GetStat<ModifierStat<T>>();
        }

        public void AccumulateStatus<T>(IStatus status) where T : Stat, IStatus
        {
            if (!(status is T)) throw new Exception("Status and type do not match");
            GetStatus<T>().Value += (status as Stat).Value;
        }

        public void ApplyStatus<T>(IStatus status) where T : Stat, IStatus
        {
            if (!(status is T)) throw new Exception("Status and type do not match");
            GetStatus<T>().Value = (status as Stat).Value;
        }
        #endregion
        public void LoadSpriteFromFile(string filename, int width, int height)
        {
            Surface s = new Surface(filename).Convert(Video.Screen);
            s.AlphaBlending = true;
            drawable_ = new Sprite(filename);
        }

        public void Update(SdlDotNet.Core.TickEventArgs e)
        {
            drawable_.Update(e);
        }

        public void Draw(Surface onto, Point pos)
        {
            onto.Blit(drawable_, pos);
        }

        public void WriteBaseStats(int str, int con, int dex, int per, int intel, int wis)
        {
            GetStat<StrengthStat>().Value = str;
            GetStat<ConstitutionStat>().Value = con;
            GetStat<DexterityStat>().Value = dex;
            GetStat<PerceptionStat>().Value = per;
            GetStat<IntelligenceStat>().Value = intel;
            GetStat<WisdomStat>().Value = wis;
        }

        public void WriteName(string name)
        {
            creatureName_ = name;
        }

        public void WriteToJson(string filename)
        {

            using (JsonTextWriter writer = new JsonTextWriter(new System.IO.StreamWriter(filename)))
            {
                writer.Formatting = Formatting.Indented;
                writer.WriteStartObject();
                writer.WritePropertyName("CreatureName");
                writer.WriteValue(creatureName_);

                foreach (Stat t in _stats)
                {
                    writer.WritePropertyName(t.Name);
                    writer.WriteValue(t.Value);
                }

                // if I want to write in moves, I'll have to store them in separate files. Then I'll just write in file names
                // it seems. I'd like to write in definitions in here, but now that I think about it it might be best
                // to standardise moves in different files.
                // But I still need to make a list of moves. Difficult... Standardising lists of moves would be dumb anyway.
                if (powers_ != null)
                {
                    writer.WritePropertyName("List"); // NEVERMIND FIGURED IT OUT LOL
                    writer.WriteStartObject();
                    foreach (Power p in powers_)
                        p.WriteToJson(writer);
                    writer.WriteEndObject();
                }
                writer.WriteEndObject();
            }
        }

        /// <summary> Presently broken apparently </summary>
        public void ReadFromJson(string file)
        {
            string JSONstring = System.IO.File.ReadAllText(file);
            Dictionary<string, object> values = JsonConvert.DeserializeObject<Dictionary<string, object>>(JSONstring);
            JsonReader r = new JsonTextReader(new StringReader(JSONstring));
            while (r.Read())
            {
                if (r.TokenType == JsonToken.PropertyName && r.Value == "CreatureName")
                    creatureName_ = r.ReadAsString();
            }
            string s = r.ReadAsString();
            creatureName_ = (string)values["CreatureName"];
            Stat str, con, dex, per, intel, wis;
            str = new StrengthStat(int.Parse(string.Format("{0}", values["Strength"])));
            con = new ConstitutionStat(int.Parse(string.Format("{0}", values["Constitution"])));
            /*_const = int.Parse(string.Format("{0}", values["Constitution"]));
            _dex = int.Parse(string.Format("{0}", values["Dexterity"]));
            _per = int.Parse(string.Format("{0}", values["Perception"]));
            _int = int.Parse(string.Format("{0}", values["Intelligence"]));
            _wis = int.Parse(string.Format("{0}", values["Wisdom"]));*/
            JObject j;
            object pass;
            values.TryGetValue("List", out pass);
            j = pass as JObject;
            if (j != null)
            {
                IEnumerable<object> o = j.Cast<List<object>>();
                List<object> list = new List<object>();
                foreach (object ob in o)
                {
                    list.Add(o);
                }
            }
        }
    
        public bool IsSelectable(Creature selector, Power selectingPower)
        {
            // If I, as a creature have some script or feature of a creature that means I can't be selected
            // by certain creatures/creature types or by certain powers, here is where I determine that sort of
            // nonsense.
            // No idea how I would use this but it might be handy in the future.
            return true;
        }

        public override string ToString()
        {
            return String.Format("{0}: Health: {1} Initiative: {2}", Name, GetValue<HealthStat>(), CurrentSpeed);
        }

        public bool IsDead { get { return GetValue<HealthStat>() <= 0; } }


        public IDictionary<string, IDataHolder> Children
        {
            get { throw new NotImplementedException(); }
        }

        public object Data
        {
            get { throw new NotImplementedException(); }
        }

        public int ID
        {
            get { throw new NotImplementedException(); }
        }

        IDictionary<int, IDataHolder> IDataHolder.Children
        {
            get { throw new NotImplementedException(); }
        }
    }
}
