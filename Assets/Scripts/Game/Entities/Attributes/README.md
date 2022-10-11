<a href="https://github.com/Galacticai/Commanders/blob/dev/Assets/Scripts/Game/Entities/Attributes/Attribute.cs">
    <img height=24 src="https://img.shields.io/badge/Class%20Diagram-Attribute-informational?&style=flat-square" />
</a>
<br/>

`Commanders`>`Assets`>`Scripts`>`Game`>`Entities`>`Attributes`>**{`Attribute`}**

---

```mermaid
classDiagram-v2
TypeDictionary~Attribute~ <|-- AttributeDictionary : inherits
class TypeDictionary~Attribute~ {
    (From Lib)
}
AttributeDictionary ..o Attribute : aggregates
class AttributeDictionary {
    internal record Default
            
    internal static bool AttributeIsRequired(Type statType)
    public override void Clear()
    public override bool Remove<IAttribute>()
    private void _SetDefaults(bool force = false)

    public AttributeDictionary(params Attribute[] values)
    public AttributeDictionary()

    internal static AttributeDictionary CreateDefault()
}

class Attribute {
    protected internal Entity Parent
    private protected Attribute(Entity parent)
}
    Attribute <-- Command : inherits
    Command ..o GameObject : aggregates
    class Command {
        internal GameObject GameObject
        internal bool GameObject_Exists
        
        private string GameObjectName
        internal Commander Commander

        internal Command(Entity parent_Entity, string gameObject_name, Commander commander = null)
    }
        Command ..o Commander : aggregates
        class Commander {
            ! Check README.md in the
            corresponding namespace.
        }
    class GameObject{
        (From UnityEngine.GameObject)
    }
    Attribute <-- Territory : inherits
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
    Attribute <-- Weapon : inherits
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
    Attribute <-- Vision : inherits
    class Vision {
        internal double Radius
        internal bool CamoVisible
        internal Vision(Entity parent_Entity, double radius, bool camoVisible = false)
    }
    Attribute <-- Health : inherits
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
        Amount <.. Health : uses
        class Amount {
            (From Lib)
        }
```