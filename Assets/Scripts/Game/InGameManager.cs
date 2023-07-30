using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Characters.Player;
using Game.Field;
using UI.InGame;

namespace Game {
    public class InGameManager :MonoBehaviour {
        public bool HasStarted { get; private set; }
        public bool isStartGameClose { get;  set; }

        [Header("Player")]
        [SerializeField] GameObject PlayerGameObject;
        Player player;
        [Header("Field")]
        [SerializeField] GameFieldManger fieldManger;
        public Vector2Int sizeOfField;
        public int CountOfObstacle;

        public InGameUIManager _inGameUIManager;
        
        public List<Vector3> occupiedPositions;
        [Header("Mobs")]
        [SerializeField] MobGenerator mobGenerator;

        void Awake() {
            Init();
            HasStarted = true;
        }

        private void Init() {
            player = PlayerGameObject.GetComponent<Player>();
            if (player == null) FindPlayer();
        }

        // Update is called once per frame
        void Update() {
            /*
            if (_inGameUIManager.joystickManager.Direction != new Vector2(0, 0)) player.SetShootManagerAvailible(false);
            else player.SetShootManagerAvailible(true);
            */
            if (isStartGameClose) {
                if (_inGameUIManager.joystickManager.Direction == new Vector2(0, 0)
                    && Input.GetKeyDown(KeyCode.Space)
                    ) {
                    player.SetShootManagerAvailible(true);
                }
                else {
                    player.SetShootManagerAvailible(false);
                }
            }
            player.SetVectorByJoystick(_inGameUIManager.joystickManager.Direction);
        }
        void FindPlayer() {
            PlayerGameObject = GameObject.FindGameObjectWithTag("Player");
            player = PlayerGameObject.GetComponent<Player>();
            if (PlayerGameObject == null) Debug.LogError($"{player} doesn't contain Player!");
        }

        public void FreezeGame() {
            Time.timeScale = 0;
        }
        public void UnfreezeGame() {
            Time.timeScale = 1;
        }
    }
}
    
    
    
