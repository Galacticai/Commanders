using Commanders.Assets.Scripts.Game.Commanders;
using Commanders.Assets.Scripts.Game.Entities.Stats;
using UnityEngine;

namespace Commanders.Assets.Scripts.Game.Entities.Units {
    internal class Vehicle : Unit {

        internal static GameObject TestVehicle(Commander commander, Vector3 location) {
            throw new System.NotImplimentedException();
        }

        private protected Vehicle(Command command, StatDictionary stats = null)
                : base(command, stats) { }

    }
}
