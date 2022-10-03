using Commanders.Assets.Scripts.Game.Commanders;
using System;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

namespace Commanders.Assets.Scripts.Game.UI {
    public class Skirmish_Screen : MonoBehaviour {
        private UIDocument _UIDocument = null;
        private VisualElement _Screen = null;

        public enum ButtonName {
            Demand_Button,
            Back_Button
        }


        internal VisualElement GetCommanders_Box()
            => _Screen.Q("Skirmish_Body").Q("Commanders_Box");
        internal Commander[] GetCommanders() {
            Commander[] commanders = Array.Empty<Commander>();
            VisualElement Commanders_Box_Element = GetCommanders_Box();

            //!? Keep as IEnumerable, skip converting to array for performance
            //!? 2D loop is ok because there is 8x4 lightweight iterations only
            foreach (var Commander_Box_Element in Commanders_Box_Element.Children()) {
                foreach (var commanderAttribute_Element in Commander_Box_Element.Children()) {

                }
            }
            return commanders;
        }
        internal bool AddCommander(Commander commander) {
            return true;
        }
        internal bool AddCommanders(Commander[] commanders) {
            if (commanders.Length > 8)
                throw new ArgumentOutOfRangeException();
            for (int i = 0; i < 8; i++) {

            }
            return true;
        }

        private Action Demand_Button_Click()
            => new(() => {
                Debug.Log("==( Demand_Button_Click )==");
                Scene game = SceneManager.CreateScene("game");
                GameObject MainBuilding = new("MainBuilding");
                GameObject mainBuild = Instantiate(MainBuilding);
                SceneManager.LoadScene(game.buildIndex);
            });
        private Action Back_Button_Click()
            => new(async () => {
                Debug.Log("==( Back_Button_Click )==");
                await Lib.Unity.UI.Screen.Navigate(
                    gameObject, GameScreens.GetScreen(GameScreens.ScreenName.Main_Screen),
                    default, new Translate(0, Length.Percent(-50), 0));
            });

        private Action _ButtonAction(ButtonName buttonName)
            => buttonName switch {
                ButtonName.Demand_Button => Demand_Button_Click(),
                ButtonName.Back_Button => Back_Button_Click(),
                _ => null
            };
        private bool _InitEvents() {
            VisualElement footer = _Screen.Q("Skirmish_Footer");
            VisualElement buttons_Container = footer.Children().Last();
            foreach (var child in buttons_Container.Children()) {
                if (Enum.TryParse(child.name, out ButtonName buttonName)) {
                    ((Button)child).clicked += _ButtonAction(buttonName);
                }
            }
            return true;
        }

        private void Start() {
            _UIDocument = GetComponent<UIDocument>();
            _Screen = _UIDocument.rootVisualElement[0];
            _InitEvents();
            Lib.Unity.UI.Screen.Hide(gameObject);
            _Screen.style.transitionProperty = StyleKeyword.Undefined;
        }
    }
}
