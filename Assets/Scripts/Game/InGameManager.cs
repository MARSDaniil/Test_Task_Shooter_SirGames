using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Characters.Player;
using UI.InGame;

namespace Game {
    public class InGameManager :MonoBehaviour {

        [SerializeField] Player player;
        public InGameUIManager _inGameUIManager;

        void Awake() {
            Init();
        }

        private void Init() {
            if (player == null) FindPlayer();
            
        }

        // Update is called once per frame
        void Update() {
            player.SetVectorByJoystic(_inGameUIManager.joystickManager.Direction);
        }

        void FindPlayer() {
            var player = GameObject.FindGameObjectsWithTag("Player");
            if(player == null)  Debug.LogError($"{player} doesn't contain Player!");
        }
    }
}