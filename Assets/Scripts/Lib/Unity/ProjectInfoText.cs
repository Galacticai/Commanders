using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Commanders.Assets.Scripts.Lib.Unity {
    /// <summary> Commanders vX.x (Phase) - � Galacticai 2022 </summary>
    public class ProjectInfoText : MonoBehaviour {


        [SerializeField] private string gameName = "Commanders";
        [SerializeField]
        private bool showGameName = true,
                     showVersion = true,
                     showVersionMinor = true,
                     showPhase = true,
                     showCopyrightSymbol = true,
                     showDeveloperName = true,
                     showYear = true;
        [SerializeField] private int year = 2022;

        private void Start() {
            TMP_Text _TMPText = GetComponent<TMP_Text>();
            if (_TMPText == null) return;


            List<string> infoList = new();

            if (showGameName) infoList.Add(gameName);

            string[] version = Application.version.Split('.');
            if (showVersion)
                infoList.Add(
                    $"v{version[0]}"
                    + (showVersionMinor ? $".{version[1]}" : "")
                );
            if (showPhase) infoList.Add($"({(ProjectPhase)Convert.ToInt32(version[2])})");
            if (showCopyrightSymbol
                || showDeveloperName
                || showYear)
                infoList.Add("�");
            if (showCopyrightSymbol) infoList.Add("�");
            if (showDeveloperName) infoList.Add(Application.companyName);
            if (showYear) infoList.Add(year.ToString());


            _TMPText.text = string.Join(' ', infoList.ToArray());
        }
    }
}
