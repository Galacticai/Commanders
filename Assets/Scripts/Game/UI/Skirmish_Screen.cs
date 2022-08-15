using Assets.Scripts.Game.Commanders;
using Assets.Scripts.Lib.Unity;
using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace Assets.Scripts.Game.UI {
    public class Skirmish_Screen : MonoBehaviour {
        internal static UIDocument _uiDocument = null;
        private VisualElement _screen = null;

        public enum ButtonName {
            Demand_Button,
            Back_Button
        }


        internal VisualElement getCommanders_Box()
            => this._screen.Q("Skirmish_Body").Q("Commanders_Box");
        internal Commander[] getCommanders() {
            Commander[] commanders = Array.Empty<Commander>();
            VisualElement Commanders_Box_Element = this.getCommanders_Box();

            //!? Keep as IEnumerable, skip converting to array for performance
            //!? 2D loop is ok because there is 8x4 iterations only
            foreach (var Commander_Box_Element in Commanders_Box_Element.Children()) {
                foreach (var commanderAttribute_Element in Commander_Box_Element.Children()) {

                }
            }
            return commanders;
        }
        internal bool addCommander(Commander commander) {
            return true;
        }
        internal bool addCommanders(Commander[] commanders) {
            if (commanders.Length > 8)
                throw new ArgumentOutOfRangeException();
            for (int i = 0; i < 8; i++) {

            }
            return true;
        }

        private Action Demand_Button_Click()
            => new(() => {
                Debug.Log("Demand_Button_Click");
            });
        private Action Back_Button_Click()
            => new(() => {
                Debug.Log("Back_Button_Click");

                Assets.Scripts.Lib.Unity.UI.Screen.navigate(
                    this.gameObject,
                    GameScreens.getScreen(GameScreens.ScreenName.Main_Screen),
                    default, Length.Percent(50));
            });

        private Action buttonAction(ButtonName buttonName)
            => buttonName switch {
                ButtonName.Demand_Button => this.Demand_Button_Click(),
                ButtonName.Back_Button => this.Back_Button_Click(),
                _ => null
            };
        private bool initEvents(VisualElement container) {
            Debug.Log(container.name);
            var children = container.Children();
            foreach (var child in children) {
                if (Enum.TryParse(child.name, out ButtonName buttonName))
                    ((Button)child).clicked += this.buttonAction(buttonName);
            }
            return true;
        }

        private void Start() {
            _uiDocument = this.GetComponent<UIDocument>();
            this._screen = _uiDocument.rootVisualElement.getFirstChild();
            this.initEvents(this._screen.Q("Skirmish_Footer"));
            this._screen.style.top = UnityEngine.Screen.height;
        }
    }
}
