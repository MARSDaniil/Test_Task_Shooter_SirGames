using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Game;
using UI.Pause;
using UI.StartGameUI;
namespace UI.InGame {
    public class InGameUIManager :MonoBehaviour {
        [Header("Input")]
        public GameObject input;
        public JoystickManager joystickManager;

        [Header("InfoPanel")]
        public Button openPauseMenuButton;

        [Header("PauseMenu")]
        public PauseMenuUI pauseMenuUI;
        public StartGame startGame;
        [HideInInspector]

        InGameManager _inGameManager;

        private void Start() {
            _inGameManager = FindObjectOfType<InGameManager>();
            if (!_inGameManager) {
                UnityEngine.Debug.Log($"{this} has not found {nameof(_inGameManager)}");
            }

            if (_inGameManager.HasStarted)
                Init();
        }
        private void Init() {
            openPauseMenuButton.onClick.AddListener(OnOpenPauseMenuClicked);
            if (pauseMenuUI != null) pauseMenuUI.Init();
            if (startGame != null) {
                startGame.Open();
                startGame.Init();
            }
        }

            void OnOpenPauseMenuClicked() {
            pauseMenuUI.Open();
            FreezeGame();
        }

        public void FreezeGame() => _inGameManager.FreezeGame();
        public void UnfreezeGame() => _inGameManager.UnfreezeGame();

    }
}