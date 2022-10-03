using UnityEngine;

namespace Commanders.Assets.Scripts.Game.UI {
    internal static class GameScreens {
        internal enum ScreenName {
            Main_Screen,
            Skirmish_Screen,
            Background_Screen
        }
        internal static GameObject GetScreen(ScreenName screenName)
            => GameObject.Find(screenName.ToString());

    }
}
