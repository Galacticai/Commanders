[<h1><img height=48 src="https://img.shields.io/badge/Namespace%20Overview-Entities-white?color=informational&style=flat-square" /></h1>](https://github.com/Galacticai/Commanders/blob/dev/Assets/Scripts/Game/Entities)

`Commanders`>`Assets`>`Scripts`>`Game`>(**`Entities`**)

---

```mermaid
classDiagram-v2
    Entity <|-- Unit : inherits
        Unit <|-- Human : inherits
        Unit <|-- Vehicle : inherits
    Entity <|-- Building : inherits

        Commander <|-- Player : inherits
        Commander <|-- Computer : inherits
    Entity --* StatDictionary : composes
        TypeDictionary <|-- StatDictionary : inherits
        StatDictionary ..o Stat : aggregates

    Stat <-- Command : inherits
    Command ..o Commander : aggregates
    Command ..o GameObject : aggregates
    class GameObject{
        (From UnityEngine.GameObject)
    }
    Stat <-- Territory : inherits
    Stat <-- Weapon : inherits
        Weapon ..* Damage : composes
    Stat <-- Vision : inherits
    Stat <-- Health : inherits
    Amount <.. Health : uses
        Range <.. Amount : uses

```