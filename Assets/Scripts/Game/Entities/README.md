[<h1><img height=48 src="https://img.shields.io/badge/Class%20Diagram-Entity-white?color=informational&style=flat-square" /></h1>](https://github.com/Galacticai/Commanders/blob/dev/Assets/Scripts/Game/Entities/Entity.cs)

`Commanders`>`Assets`>`Scripts`>`Game`>`Entities`>**`Entity`**

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
    Entity --* StatDictionary : composes
        class StatDictionary {
            ! Check README.md in the
            corresponding namespace.
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

```