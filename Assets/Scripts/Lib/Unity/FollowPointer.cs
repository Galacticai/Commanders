using Commanders.Assets.Scripts.Lib.Math;
using UnityEngine;

namespace Commanders.Assets.Scripts.Lib.Unity {
    public class FollowPointer : MonoBehaviour {
        [SerializeField] private Common.Space.Plane _TargetPlane;
        [SerializeField] private Canvas _AlignToCanvas;
        private Transform _Transform;

        private void Start() {
            _Transform = GetComponent<Transform>();
        }
        private void Update() {
            if (_Transform == null) return;
            Vector3 newPos = _TargetPlane switch {
                Common.Space.Plane.yz => new(_Transform.position.x, Input.mousePosition.x, Input.mousePosition.y),
                Common.Space.Plane.xz => new(Input.mousePosition.x, _Transform.position.y, Input.mousePosition.y),
                //Common.Space.Plane.xy 
                _ => new(Input.mousePosition.x, Input.mousePosition.y, _Transform.position.z),
            };
            if (_AlignToCanvas != null) {

            }
            _Transform.position = newPos;
        }
    }
}