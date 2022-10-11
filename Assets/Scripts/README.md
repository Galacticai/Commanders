[<h1><img height=32 src="https://img.shields.io/badge/Overview-Entities-white?color=informational&style=flat-square" /></h1>](https://github.com/Galacticai/Commanders/blob/dev/Assets/Scripts/Game/Entities)

`Commanders`>`Assets`>`Scripts`>`Game`>(**`Entities`**)

---

```mermaid
classDiagram-v2
class GameObject{
    (From UnityEngine)
}
class TypeDictionary~Attribute~{
    <<TypeDictionary< TValue >>>
    (From Lib)
}
    TypeDictionary~Attribute~ <|-- AttributeDictionary : inherits
Entity --* AttributeDictionary : composes
    AttributeDictionary ..o Attribute : aggregates
        Amount <.. Health : uses
    Attribute <|-- Health : inherits
    Attribute <|-- Territory : inherits
        Territory -- TerritoryType : with
    Attribute <-- Weapon : inherits
        Weapon -- WeaponType : with
        Weapon ..* Damage : composes
            Damage -- DamageType : with
    Attribute <|-- Vision : inherits
    Attribute <|-- Command : inherits
        GameObject o.. Command : references
        Commander o.. Command : references
            Commander <|-- Player : inherits
            Commander <|-- Computer : inherits
Entity -- GameObject : ??composes??
Entity <|-- Unit : inherits
    Unit <|-- Human : inherits
    Unit <|-- Vehicle : inherits
Entity <|-- Building : inherits
```
