using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Game.Characters.Bird {
    public class Bird :Character {
        ShootManager _shootManager;
        InGameManager _inGameManager;
        BirdMovement _birdMovement;
        public bool canShoot = false;
        public float distanceToGround;
        Ray ray;
        private void Awake() {
            Init();
            base.Init();
            _birdMovement.Init(_inGameManager.PlayerGameObject, Speed,_inGameManager.sizeOfField);

        }
        private void Update() {
            _birdMovement.isGameStarted = _inGameManager.isStartGameClose;
            _shootManager.SetAvailibleOfShoot(canShoot);
        }
        public override void Init() {
            base.Init();
            _inGameManager = FindObjectOfType<InGameManager>();
            if (!_inGameManager) {
                UnityEngine.Debug.Log($"{this} has not found {nameof(_inGameManager)}");
            }
            _birdMovement = GetComponent<BirdMovement>();
            _shootManager = GetComponent<ShootManager>();

            if (_birdMovement == null) {
                UnityEngine.Debug.Log($"{_birdMovement} has not found {nameof(_inGameManager)}");
            }
            if (_shootManager == null) {
                UnityEngine.Debug.Log($"{_shootManager} has not found {nameof(_inGameManager)}");
            }
            IsDead = false;
           
        }
       
        public void OnCollisionEnter(Collision collision) {
            switch (collision.gameObject.tag) {
                case "Obstacle":
                HP = HP - 5;
                break;
                case "Player":
                HP = HP - 20;
                break;
                case "Bullet":
                HP = HP - 10;
                break;

            }
            if (HP <= 0) {
                _inGameManager.MinusBird();
                IsDead = true;
                gameObject.SetActive(false);
            }
        }
        public void SetShootVector(Vector2 value) {
            Vector3 vector3 = new Vector3(value.x, 0, value.y);
            _shootManager.SetVectorOfShooting(vector3);
        }
    }


}