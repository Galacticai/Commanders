/// —————————————————————————————————————————————
//? 
//!? 📜 CameraFollow_MainMenu.cs
//!? 🖋️ Galacticai 📅 2022
//!  ⚖️ GPL-3.0-or-later
//?  🔗 Dependencies:
//      + UnityEngine
//? 
/// —————————————————————————————————————————————


using UnityEngine;

namespace Commanders.Assets.Scripts.Lib.Unity {
    /// <summary> Move the camera in 3D manner with the movement of the mouse pointer  </summary>
    public class Camera3DMouseMove : MonoBehaviour {
        private Vector3 CamPos;

        private void FixedUpdate() {
            Vector2 MousePos = new(Input.mousePosition.x, Input.mousePosition.y);
            Vector2 DisplaySize = new(Screen.width, Screen.height);
            // ]-inf, (  0 , screenXY), inf[
            Vector2 MousePos100 = MousePos / DisplaySize * 100;
            // ]-inf, (  0 , 100) , inf[
            MousePos100.x = ForceInRange(MousePos100.x, 0, 100);
            MousePos100.y = ForceInRange(MousePos100.y, 0, 100);
            // [  0 , 100]
            MousePos100.x -= 50; MousePos100.y -= 50;
            // [-50 , 50 ]
            Vector2 MousePosCentered = new(
                SinSmooth_StartEnd(MousePos100.x, 100),
                SinSmooth_StartEnd(MousePos100.y, 100)
            );

            CamPos = new Vector3(MousePosCentered.x, MousePosCentered.y, transform.position.z);
        }

        private void LateUpdate() {
            transform.position = CamPos;
            transform.LookAt(new Vector3(CamPos.x / 2, CamPos.y / 2, 0));
        }

        private float ForceInRange(float input, float min, float max) {
            if (input > max) return max;
            else if (input < min) return min;
            else return input;
        }

        private float SinSmooth_StartEnd(float linearSpace, float scale) {
            return Mathf.Sin(Mathf.PI * linearSpace / scale) * scale;
        }


    }
}
