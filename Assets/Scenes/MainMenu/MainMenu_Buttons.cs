using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scenes.MainMenu {
    public class MainMenu_Buttons : MonoBehaviour {

        public void SampleScene_Button_Click() {
            SceneManager.LoadScene((int)ScenesIndex.SampleScene);
        }

        public void Quit_Button_Click() {
            Application.Quit();
        }
    }
}
