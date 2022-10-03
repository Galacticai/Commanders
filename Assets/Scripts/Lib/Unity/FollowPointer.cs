using Commanders.Assets.Scripts.Lib.Math;
using UnityEngine;

namespace Commanders.Assets.Scripts.Lib.Unity {
public class FollowPointer : MonoBehaviour {
    [SerializeField] private Common.Space.Plane _targetPlane;
    [SerializeField] private Canvas _alignToCanvas;
    private Transform _transform;

    private void Start() {
        this._transform = this.GetComponent<Transform>();
    }
    private void Update() {
        if (this._transform == null) return;
        Vector3 newPos = this._targetPlane switch {
            Common.Space.Plane.xy => new(Input.mousePosition.x, Input.mousePosition.y, this._transform.position.z),
            Common.Space.Plane.yz => new(this._transform.position.x, Input.mousePosition.x, Input.mousePosition.y),
            Common.Space.Plane.xz => new(Input.mousePosition.x, this._transform.position.y, Input.mousePosition.y),
        };
        if (this._alignToCanvas != null) {

        }
        this._transform.position = newPos;
    }
}
