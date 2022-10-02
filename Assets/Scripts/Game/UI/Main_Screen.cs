using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace Assets.Scripts.Game.UI {
    public class Main_Screen : MonoBehaviour {
        internal static UIDocument _UIDocument = null;
        private VisualElement _Screen = null;

        public enum ButtonName {
            Skirmish_Button,
            SampleScene_Button,
            Quit_Button
        }

        private Action Skirmish_Button_Click()
            => new(async () => {
                await Lib.Unity.UI.Screen.Navigate(
                    gameObject, GameScreens.GetScreen(GameScreens.ScreenName.Skirmish_Screen));

                Debug.Log("==( Skirmish_Button_Click )==");
            });
        private Action SampleScene_Button_Click()
            => new(() => {
                Debug.Log("==( SampleScene_Button_Click )==");
            });
        private Action Quit_Button_Click()
            => new(() => {
                Debug.Log("==( Quit_Button_Click )==");
#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
#endif
                Application.Quit();
            });

        private Action buttonAction(ButtonName buttonName)
            => buttonName switch {
                ButtonName.Skirmish_Button => Skirmish_Button_Click(),
                ButtonName.SampleScene_Button => SampleScene_Button_Click(),
                ButtonName.Quit_Button => Quit_Button_Click(),
                _ => null
            };
        private bool initEvents(VisualElement container) {
            var children = container.Children();
            foreach (var child in children) {
                if (Enum.TryParse(child.name, out ButtonName buttonName)) {
                    ((Button)child).clicked += buttonAction(buttonName);
                }
            }
            return true;
        }


        private void Start() {
            if (_UIDocument != null)
                _UIDocument = GetComponent<UIDocument>();
            if (_Screen != null)
                _Screen = _UIDocument.rootVisualElement[0];
            initEvents(_Screen);
        }
    }
}
