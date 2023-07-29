using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Characters.Player;
namespace Game.Field {
    public class GameFieldManger :MonoBehaviour {
        InGameManager _inGameManager;
        [SerializeField] private GameObject plane;

        [SerializeField] GameObject PlayerGameObject;
        Player player;


        public Vector2Int sizeOfPlane { get; set; }
        private void Start() {
            _inGameManager = FindObjectOfType<InGameManager>();
            if (!_inGameManager) {
                UnityEngine.Debug.LogError($"{this} has not found {nameof(_inGameManager)}");
            }

            player = PlayerGameObject.GetComponent<Player>();
            if (!player || !PlayerGameObject) {
                UnityEngine.Debug.LogError($"{this} has not found {nameof(Player)}");
            }


            if (_inGameManager.HasStarted)
                Init();
        }

        private void Init() {


            sizeOfPlane = _inGameManager.sizeOfField;
            plane.transform.localScale = new Vector3(sizeOfPlane.y / (10), 1, sizeOfPlane.x / (10));
            plane.transform.position = new Vector3(0 , 0, sizeOfPlane.x / 2 );

            PlayerGameObject.transform.position = new Vector3(0,
                PlayerGameObject.transform.localScale.y,
                sizeOfPlane.x / (2 * 3));
                
        }


    }
}