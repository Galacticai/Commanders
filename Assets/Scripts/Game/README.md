<a href="https://github.com/Galacticai/Commanders/blob/dev/Assets/Scripts/Game">
    <img height=24 src="https://img.shields.io/badge/Namespace%20Overview-Game-white?color=informational&style=flat-square" />
</a>
<br/>

`Commanders`>`Assets`>`Scripts`>(**`Game`**)

---

```mermaid
classDiagram-v2
class Commander {
    (From Commanders)
}
Commander <-- Computer : inherits
Commander <-- Player : inherits
GameObject *-- Entity : composes
GameObject ..o Entity : references

Commander o..o Entity : references
Entity
    Entity <|-- Building : inherits
    Entity <|-- Unit : inherits
        Unit <|-- Human : inherits
        Unit <|-- Vehicle : inherits

class AttributeDictionary {
    (From Attributes)
}
    Entity o.. Attribute : references
    class Attribute {
        (From Attributes)
    }
Entity --* AttributeDictionary : composes
    AttributeDictionary --o Attribute : aggregates
        Attribute <|-- Vision : inherits
        Attribute <|-- Territory : inherits
            Territory -- TerritoryType : with
        Attribute <|-- Weapon : inherits
            Weapon -- WeaponType : with
            Weapon --* Damage : composes
        Attribute <|-- Health : inherits
            class Amount {
                (From Lib)
            }
            Amount <.. Health : uses

class GameObject {
    (From UnityEngine)
}
TypeDictionary~Attribute~ <-- AttributeDictionary : inherits
class TypeDictionary~Attribute~ {
    <<TypeDictionary< TValue >>>
    (From Lib)
}
```
