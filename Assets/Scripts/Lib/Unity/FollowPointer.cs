using Commanders.Assets.Scripts.Lib.Math.Space3D;
using UnityEngine;

namespace Commanders.Assets.Scripts.Lib.Unity {
    public class FollowPointer : MonoBehaviour {
        [SerializeField] private PlaneType _TargetPlane;
        [SerializeField] private Canvas _AlignToCanvas;
        private Transform _Transform;

        private void Start() {
            _Transform = GetComponent<Transform>();
        }
        private void Update() {
            if (_Transform == null) return;
            Vector3 newPos = _TargetPlane switch {
                PlaneType.YZ => new(_Transform.position.x, Input.mousePosition.x, Input.mousePosition.y),
                PlaneType.XZ => new(Input.mousePosition.x, _Transform.position.y, Input.mousePosition.y),
                //!? PlaneType.XY 
                _ => new(Input.mousePosition.x, Input.mousePosition.y, _Transform.position.z),
            };
            if (_AlignToCanvas != null) {

            }
            _Transform.position = newPos;
        }
    }
}