using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scenes.MainMenu {
    internal class Buttons : MonoBehaviour {

        internal void Play_Button_Click() {
            SceneManager.LoadScene((int)ScenesIndex.SampleScene);
        }

        internal void Quit_Button_Click() {
            Application.Quit();
        }
    }
}
