using UnityEngine;
using UnityEngine.UIElements;

namespace Commanders.Assets.Scripts.Lib.Unity {
    public static class UI {
        public static VisualElement getFirstChild(this VisualElement visualElement) {
            if (visualElement == null) return null;
            foreach (var child in visualElement.Children())
                return child ?? null;
            return null;
        }
        public static VisualElement getFirstChild(this UIDocument uiDocument) {
            return uiDocument.rootVisualElement.getFirstChild();
        }

        public struct Screen {
            public static bool isValid(VisualElement screenElement)
                => screenElement.ClassListContains("Screen");
            public static bool isValid(UIDocument uiDocument, out VisualElement screenElement) {
                screenElement = uiDocument.getFirstChild();
                if (screenElement == null) return false;
                if (!isValid(screenElement)) return false;
                return true;
            }
            public static bool isValid(GameObject screen, out UIDocument uiDocument, out VisualElement screenElement) {
                uiDocument = screen.GetComponent<UIDocument>(); screenElement = null;
                if (uiDocument == null) return false;
                if (!isValid(uiDocument, out screenElement)) return false;
                return true;
            }

            public static bool hide(GameObject screen, StyleLength customStyleTop = default) {
                bool screen_isValid = isValid(screen, out UIDocument uiDocument, out VisualElement screenElement);
                if (!screen_isValid) return false;
                screenElement.style.top
                    = customStyleTop == default
                        ? UnityEngine.Screen.height
                        : customStyleTop;
                screenElement.style.opacity = 0;
                return true;
            }
            public static bool show(GameObject screen, StyleLength customStyleTop = default) {
                bool screen_isValid = isValid(screen, out UIDocument uiDocument, out VisualElement screenElement);
                if (!screen_isValid) return false;
                screenElement.style.top
                    = customStyleTop == default ? 0 : customStyleTop;
                screenElement.style.opacity = 1;
                return true;
            }


            public static bool navigate(GameObject fromScreen, GameObject toScreen,
                    StyleLength from_customStyleTop = default, StyleLength to_customStyleTop = default) {
                Debug.Log($"{fromScreen.name} >> {toScreen.name}");
                if (!hide(fromScreen, from_customStyleTop)) return false;
                if (!show(toScreen, to_customStyleTop)) return false;
                return false;
            }
        }
    }
}
