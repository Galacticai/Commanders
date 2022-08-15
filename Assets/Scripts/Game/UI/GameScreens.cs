using UnityEngine;

namespace Assets.Scripts.Game.UI {
    internal static class GameScreens {
        internal enum ScreenName {
            Main_Screen,
            Skirmish_Screen,
            Background_Screen
        }
        internal static GameObject getScreen(ScreenName screenName)
            => GameObject.Find(screenName.ToString());

    }
}
