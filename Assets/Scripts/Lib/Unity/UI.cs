using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UIElements;

namespace Commanders.Assets.Scripts.Lib.Unity {
    public static class UI {
        public static VisualElement GetFirstChild(this VisualElement visualElement) {
            if (visualElement == null) return null;
            foreach (var child in visualElement.Children())
                return child ?? null;
            return null;
        }
        public static VisualElement GetFirstChild(this UIDocument uiDocument) {
            return uiDocument.rootVisualElement[0];
        }

        public struct Screen {
            public static bool IsValid(VisualElement screenElement)
                => screenElement.ClassListContains("Screen");
            public static bool IsValid(UIDocument uiDocument, out VisualElement screenElement) {
                screenElement = uiDocument.GetFirstChild();
                if (screenElement == null) return false;
                if (!IsValid(screenElement)) return false;
                return true;
            }
            public static bool IsValid(GameObject screen, out UIDocument uiDocument, out VisualElement screenElement) {
                uiDocument = screen.GetComponent<UIDocument>(); screenElement = null;
                if (uiDocument == null) return false;
                if (!IsValid(uiDocument, out screenElement)) return false;
                return true;
            }

            public static bool? ScreenElement_isHidden(VisualElement screenElement) {
                if (!IsValid(screenElement)) return null;
                return screenElement.style.opacity == 0;
            }

            public static bool Hide(GameObject screen)
                => Hide(screen, default);
            public static bool Show(GameObject screen)
                => Show(screen, default);
            public static bool Hide(GameObject screen, StyleTranslate customStyleTranslate) {
                bool screen_isValid = IsValid(screen, out UIDocument uiDocument, out VisualElement screenElement);
                if (!screen_isValid) return false;
                screenElement.style.translate
                    = customStyleTranslate == default
                        ? new Translate(0, Length.Percent(200), 0)
                        : customStyleTranslate;
                screenElement.style.opacity = 0;
                return true;
            }
            public static bool Show(GameObject screen, StyleTranslate customStyleTranslate) {
                bool screen_isValid = IsValid(screen, out UIDocument uiDocument, out VisualElement screenElement);
                if (!screen_isValid) return false;
                screenElement.style.opacity = 1;
                screenElement.style.translate
                    = customStyleTranslate == default
                        ? new Translate(0, Length.Percent(0), 0)
                        : customStyleTranslate;
                return true;
            }


            public static async Task<bool> Navigate(
                    GameObject fromScreen, GameObject toScreen,
                    StyleTranslate from_customStyleTranslate = default, StyleTranslate to_customStyleTranslate = default,
                    int delay = 20) {
                Debug.Log($"{fromScreen.name} >> {toScreen.name}");
                if (!Hide(fromScreen, from_customStyleTranslate)) return false;
                await Task.Delay(delay);
                if (!Show(toScreen, to_customStyleTranslate)) return false;
                return false;
            }
        }
    }
}
