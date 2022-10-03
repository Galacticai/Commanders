/// —————————————————————————————————————————————
//? 
//!? 📜 CameraLook.cs
//!? 🖋️ Galacticai 📅 2022
//!  ⚖️ GPL-3.0-or-later
//?  🔗 Dependencies:
//      + UnityEngine
//? 
/// —————————————————————————————————————————————


using UnityEngine;

namespace Commanders.Assets.Scripts.Lib.Unity {
    /// <summary> Look with the camera using mouse movement </summary>
    public class CameraLook : MonoBehaviour {
        [SerializeField] private float MouseSensitivity = 100.0f;
        [SerializeField] private float ClampAngle = 80.0f;

        private float _RotationY = 0.0f; // rotation around the up/y axis
        private float _RotationX = 0.0f; // rotation around the right/x axis

        private void Start() {
            Vector3 rot = transform.localRotation.eulerAngles;
            _RotationY = rot.y;
            _RotationX = rot.x;
        }

        private void Update() {
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = -Input.GetAxis("Mouse Y");

            _RotationY += mouseX * MouseSensitivity * Time.deltaTime;
            _RotationX += mouseY * MouseSensitivity * Time.deltaTime;

            _RotationX = Mathf.Clamp(_RotationX, -ClampAngle, ClampAngle);

            Quaternion localRotation = Quaternion.Euler(_RotationX, _RotationY, 0.0f);
            transform.rotation = localRotation;
        }
    }
}