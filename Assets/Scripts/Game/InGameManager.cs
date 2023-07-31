using System.Collections.Generic;
using UnityEngine;
using Game.Characters.Player;
using Game.Field;
using UI.InGame;
using CameraManagerNS;

namespace Game {
    public class InGameManager :MonoBehaviour {
        public bool HasStarted { get; private set; }
        public bool isStartGameClose { get; set; }

        [Header("Player")]
        public GameObject PlayerGameObject;
        Player player;
        [Header("Field")]
        [SerializeField] GameFieldManger fieldManger;
        [SerializeField] ObstacleGenerator obstacleGenerator;
        public Vector2Int sizeOfField;
        public int CountOfObstacle;

        public InGameUIManager _inGameUIManager;

        public List<Vector3> occupiedPositions;
        [Header("Mobs")]
        [SerializeField] MobGenerator mobGenerator;

        [Header("Camera")]
        [SerializeField] CameraManager cameraManager;
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
                player.SetVectorByJoystick(_inGameUIManager.joystickManager.Direction);
            }
            if (mobGenerator.countOfBirds <= 0 && mobGenerator.countOfRunners <= 0) {
                _inGameUIManager.GameOver("u win");
                isStartGameClose = false;
            }
            if (player.IsDead == true) {
                _inGameUIManager.GameOver("u loose");
                isStartGameClose = false;
            }

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
        public void MinusRunner() {
            mobGenerator.countOfRunners--;
            _inGameUIManager.PlusCoin();
        }

        public void MinusBird() {
            mobGenerator.countOfBirds--;
            _inGameUIManager.PlusCoin();
        }
    }
}
    
    
    
