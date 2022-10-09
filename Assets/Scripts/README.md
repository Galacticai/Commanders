# Class Diagram: `Entity`
###### `Commanders.Assets.Scripts.Game.Entities.Entity`
---

```mermaid
classDiagram-v2
    class Entity {
        internal static readonly Dictionary~string,Entity~ ActiveEntities
        internal GameObject GameObject
        internal bool Exists
        internal Command Command
        internal Territory Territory
        internal Health Health
        
        internal GameObject CreateGameObject()
        internal abstract GameObject CreateGameObject(string ID)

        internal StatDictionary Stats

        private protected Entity(Command command, params Stat[] stats)
        private protected Entity(Command command, StatDictionary statDictionary)

        public static implicit operator GameObject(Entity entity)
    }
    Entity <|-- Unit : inherits
        class Unit {
            private protected Human(Command command, StatDictionary stats = null)
        }
        Unit <|-- Human : inherits
            class Human {
                private protected Human(Command command, StatDictionary stats = null)
            }
        Unit <|-- Vehicle : inherits
            class Vehicle {
                private protected Vehicle(Command command, StatDictionary stats = null)
            }
    Entity <|-- Building : inherits
        class Building {
            internal bool BuildMode
            internal Task<bool> hoverBuild(Point center)
            internal double ConstructionRadius
            private protected Building(Command command, double constructionRadius, StatDictionary stats)
        }

    class Commander {
        internal static readonly Dictionary~string, Commander~ ActiveCommanders

        internal bool IsMe
        internal bool IsMASTER
        internal bool IsComputer
        internal bool IsPlayer
        internal bool IsAlliesWith(Commander commander)
        internal bool IsAlliesWith(int alliance)

        internal string Name
        internal Provenance Provenance
        private int _Alliance
        protected internal int Alliance
        internal string CameraID
        private protected Commander(string name,Provenance provenance,int alliance,string cameraID = default,bool replace = false)
    }
        Commander <|-- Player : inherits
        class Player {
            internal bool IsOnNetwork
            internal Player(string name, Provenance provenance, int alliance, string cameraID, bool replace = false)
        }
        Commander <|-- Computer : inherits
        class Computer {
            internal static readonly Computer MASTER
            internal enum ComputerStrategy
            internal ComputerStrategy Strategy


            private Computer()
            internal Computer(int computerIndex, ComputerStrategy strategy, Provenance provenance, int alliance)
        }
    Entity --* StatDictionary : composes
    class TypeDictionary~TValue~ {
        public int Count
        public Dictionary~Type, TValue~.KeyCollection Keys
        public Dictionary~Type, TValue~.ValueCollection Values
        public TValue this[Type type]

        public void TrimExcess()
        public virtual void Clear()
        public virtual bool Remove<ITValue>() where ITValue : TValue
        public virtual ITValue Get<ITValue>() where ITValue : TValue
        public virtual bool Set<ITValue>(ITValue value) where ITValue : TValue
        public virtual bool Set<ITValue>(ITValue value, bool force) where ITValue : TValue
        public bool Contains<ITValue>() where ITValue : TValue
        public bool ContainsValue<ITValue>(ITValue value) where ITValue : TValue

        private Dictionary~Type, TValue~ Dictionary

        public TypeDictionary(params TValue[] values)
        public TypeDictionary(Dictionary<Type, TValue> dictionary)
        public TypeDictionary(List<TValue> list)
        public TypeDictionary()

        public List<TValue> ToList()
        public Dictionary<Type, TValue> ToDictionary()
        public static implicit operator List<TValue>(TypeDictionary<TValue> typeDictionary)
        public static implicit operator Dictionary<Type, TValue>(TypeDictionary<TValue> typeDictionary)
        public static implicit operator TypeDictionary<TValue>(Dictionary<Type, TValue> dictionary)
        public static implicit operator TypeDictionary<TValue>(List<TValue> list)
    }
        TypeDictionary <|-- StatDictionary : inherits
        StatDictionary ..o Stat : aggregates
        class StatDictionary {
            internal record Default
            
            internal static bool StatIsRequired(Type statType)
            public override void Clear()
            public override bool Remove<IStat>()
            private void _SetDefaults(bool force = false)

            public StatDictionary(params Stat[] values)
            public StatDictionary()

            internal static StatDictionary CreateDefault()
        }

class Stat {
    protected internal Entity Parent
    private protected Stat(Entity parent)
}
    Stat <-- Command : inherits
    Command ..o Commander : aggregates
    Command ..o GameObject : aggregates
    class Command {
        internal GameObject GameObject
        internal bool GameObject_Exists
        
        private string GameObjectName
        internal Commander Commander

        internal Command(Entity parent_Entity, string gameObject_name, Commander commander = null)
    }
    class GameObject{
        (From UnityEngine.GameObject)
    }
    Stat <-- Territory : inherits
    class Territory {
        internal enum TerritoryType
        internal TerritoryType Current
        internal bool CanLand
        internal bool CanWater
        internal bool CanAir
        internal bool IsOnLand
        internal bool IsOnWater
        internal bool IsOnAir

        internal List~TerritoryType~ Allowed

        internal Territory(Entity parent_Entity, List<TerritoryType> allowed)
        internal Territory(Entity parent_Entity, params TerritoryType[] allowed)
        
        public static implicit operator TerritoryType(Territory territory)
    }
    Stat <-- Weapon : inherits
    class Weapon {
        internal enum WeaponType

        internal WeaponType Type
        internal Damage Damage
        private double _Radius
        internal double Radius
        
        private Weapon(Entity parent_Entity, WeaponType type, Damage damage, double radius = 0)
        
        internal Weapon Nearby(Entity parent_Entity, Damage damage)
        internal Weapon Ranged(Entity parent_Entity, Damage damage, double radius)
    }
        Weapon ..* Damage : composes
        class Damage {
            internal enum DamageType
            internal DamageType Type
            private double _Radius
            internal double Radius
            internal double Amount
            private double _Piercing
            internal double Piercing

            private Damage(DamageType type, double amount, double radius = 0, double piercing = 0)

            internal static Damage Direct(double amount, double piercing = 0)
            internal static Damage Area(double amount, double radius, double piercing = 0)
        }
    Stat <-- Vision : inherits
    class Vision {
        internal double Radius
        internal bool CamoVisible
        internal Vision(Entity parent_Entity, double radius, bool camoVisible = false)
    }
    Stat <-- Health : inherits
    Amount <.. Health : uses
    class Health {
        internal double Total
        internal bool IsImmortal
        internal bool IsDamaged
        internal bool IsHealed
        internal double Health_Ratio
        internal double Health_Percent

        private Amount _Health_Delta(double delta)
        internal Amount Heal(double amount)
        internal Amount Hurt(double amount, double piercing = 0)
        internal Amount HurtBy(Damage damage)
        internal Amount HurtBy(Weapon weapon)
        internal Amount HurtBy(Entity entity)
        internal Amount Restore()
        internal Amount Kill()
        internal void MakeImmortal()
        internal void MakeImmortal_Period(int timeMS)

        private Amount _Amount
        internal Amount Amount

        private double _Defence
        internal double Defence

        internal Health(Entity parent_Entity, Amount amount, double defence = 0)

        internal Health Immortal(Entity parent_Entity)
    }
    
    Range <.. Amount : uses
    class Amount {
        public double Ratio_InRange
        private double _Value
        public double Value
        public Range Range

        public Amount(double value)
        public Amount(double value, Range range)

        public static implicit operator double(Amount amount)
    }
    class Range {
        public static readonly Range ZERO_ONE
        public static readonly Range ZERO_TEN    
        public static readonly Range ZERO_HUNDRED

        public double Min
        public double Max

        public double AtOrBetween(double value)
        public double GetRatio(double value)
        public double GetPercent(double percent)

        public Range Union(Range range)

        private double _Start
        private double _End

        public double Start
        public double End

        public Range(double start, double end, bool fromEnd)
        public Range(double start, double end)

        public static double AtOrBetween(this double value, Range range)
        public static double AtOrBetween(this double input, double min, double max)
        public static double AtOrAbove(this double input, double min)
        public static double AtOrBelow(this double input, double max)
        public static double Positive(this double input)
        public static double Negative(this double input)
        public static bool IsBetween(this double input, double min, double max)
    }
```