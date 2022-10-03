using Commanders.Assets.Scripts.Game.Commanders;
using Commanders.Assets.Scripts.Game.Entities.Stats;
using UnityEngine;

namespace Commanders.Assets.Scripts.Game.Entities.Units {
    internal class Human : Unit {

        internal static GameObject TestHuman(Commander commander, Vector3 location) {
            var target = new GameObject($"TestHuman_c{commander.Name}");
            var command = new Command(target.name, commander);
            var mesh = (Mesh)Object.Instantiate(Resources.Load("modelName", typeof(Mesh)));
            var human = new Human(command);

            target.AddComponent<Transform>().localPosition = location;
            target.AddComponent<MeshFilter>().sharedMesh = mesh;
            target.AddComponent<UnityEntity>().Entity = human;
            return target;
        }

        private protected Human(Command command, StatDictionary stats = null)
                : base(command, stats) { }

    }
}
