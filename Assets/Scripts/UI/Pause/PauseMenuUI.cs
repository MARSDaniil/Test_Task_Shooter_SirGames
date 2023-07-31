using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UI.InGame;
using UI.Common;
namespace UI.Pause {
    public class PauseMenuUI: MenuWindow {
        public Button continuationButton;

        InGameUIManager inGameUIManager;

        public void Init() {
            base.Init();
            inGameUIManager = GetComponentInParent<InGameUIManager>();
            continuationButton.onClick.AddListener(On—ontinuationPauseMenuClicked);
           
        }

        void On—ontinuationPauseMenuClicked() {
            this.Close();
            inGameUIManager.UnfreezeGame();
        }

    }
}