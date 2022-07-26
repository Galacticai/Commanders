using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Lib.Unity {
    /// <summary> Commanders vX.x (Phase) - © XEROling 2022 </summary>
    public class ProjectInfoText : MonoBehaviour {


        public string gameName = "Commanders";
        public bool showGameName = true,
                    showVersion = true,
                    showVersionMinor = true,
                    showPhase = true,
                    showCopyrightSymbol = true,
                    showDeveloperName = true,
                    showYear = true;
        public int year = 2022;

        private TMP_Text _TMPText;
        private void Start() {
            this._TMPText = this.GetComponent<TMP_Text>();
            if (this._TMPText == null) return;


            List<string> infoList = new();

            if (this.showGameName) infoList.Add(this.gameName);

            string[] version = Application.version.Split('.');
            if (this.showVersion)
                infoList.Add(
                    $"v{version[0]}"
                    + (this.showVersionMinor ? $".{version[1]}" : "")
                );
            if (this.showPhase) infoList.Add($"({(ProjectPhase)Convert.ToInt32(version[2])})");
            if (this.showCopyrightSymbol
                || this.showDeveloperName
                || this.showYear)
                infoList.Add("—");
            if (this.showCopyrightSymbol) infoList.Add("©");
            if (this.showDeveloperName) infoList.Add(Application.companyName);
            if (this.showYear) infoList.Add(this.year.ToString());


            this._TMPText.text = string.Join(' ', infoList.ToArray());
        }
    }
}
