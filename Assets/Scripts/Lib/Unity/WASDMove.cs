/// —————————————————————————————————————————————
//? 
//!? 📜 WASDMove.cs
//!? 🖋️ Galacticai 📅 2022
//!  ⚖️ GPL-3.0-or-later
//?  🔗 Dependencies:
//      + UnityEngine
//? 
/// —————————————————————————————————————————————


using UnityEngine;

namespace Commanders.Assets.Scripts.Lib.Unity {
    public class WASDMove : MonoBehaviour {
        [SerializeField] private float Speed = 20, Spacing = 10;
        private Vector3 Position;

        public void Start() {
            Position = transform.position;
        }

        public void Update() {
            if (Input.GetKeyDown(KeyCode.W))
                Position.z += Spacing;
            if (Input.GetKeyDown(KeyCode.S))
                Position.z -= Spacing;
            if (Input.GetKeyDown(KeyCode.A))
                Position.x -= Spacing;
            if (Input.GetKeyDown(KeyCode.D))
                Position.x += Spacing;

            transform.position = Vector3.MoveTowards(transform.position, Position, Speed * Time.deltaTime);
        }
    }
}