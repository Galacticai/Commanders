using Assets.Scripts.Lib.Unity;
using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace Assets.UI.Scripts {
    public class Main_Screen : MonoBehaviour {
        internal static UIDocument _uiDocument = null;
        private VisualElement _screen = null;

        public enum ButtonName {
            Skirmish_Button,
            SampleScene_Button,
            Quit_Button
        }

        private Action Skirmish_Button_Click()
            => new(() => {
                Assets.Scripts.Lib.Unity.UI.Screen.navigate(
                    this.gameObject,
                    GameScreens.getScreen(GameScreens.ScreenName.Skirmish_Screen),
                    Length.Percent(25), default);

                Debug.Log("Skirmish_Button_Click");
            });
        private Action SampleScene_Button_Click()
            => new(() => {
                Debug.Log("SampleScene_Button_Click");
            });
        private Action Quit_Button_Click()
            => new(() => {
                Debug.Log("Quit_Button_Click");
#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
#endif
                Application.Quit();
            });

        private Action buttonAction(ButtonName buttonName)
            => buttonName switch {
                ButtonName.Skirmish_Button => this.Skirmish_Button_Click(),
                ButtonName.SampleScene_Button => this.SampleScene_Button_Click(),
                ButtonName.Quit_Button => this.Quit_Button_Click(),
                _ => null
            };
        private bool initEvents(VisualElement container) {
            var children = container.Children();
            foreach (var child in children) {
                if (Enum.TryParse(child.name, out ButtonName buttonName)) {
                    ((Button)child).clicked += this.buttonAction(buttonName);
                }
            }
            return true;
        }

        private void Start() {
            _uiDocument = this.GetComponent<UIDocument>();
            this._screen = _uiDocument.rootVisualElement.getFirstChild();
            this.initEvents(this._screen);
        }
    }
}
