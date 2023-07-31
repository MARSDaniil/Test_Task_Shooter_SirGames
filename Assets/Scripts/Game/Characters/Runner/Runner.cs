using UnityEngine;
namespace Game.Characters.Runner {
    public class Runner : Character {
        RunnerMovement _runnerMovement;
        ShootManager _shootManager;
        InGameManager _inGameManager;

        public bool canShoot = false;
        private void Awake() {
            Init();
            base.Init();
            _runnerMovement.Init(_inGameManager.PlayerGameObject, Speed);
            
        }

        private void Update() {
            _runnerMovement.isGameStarted = _inGameManager.isStartGameClose;
            _shootManager.SetAvailibleOfShoot(canShoot);
        }




        public override void Init() {
            base.Init();
            _inGameManager = FindObjectOfType<InGameManager>();
            if (!_inGameManager) {
                UnityEngine.Debug.Log($"{this} has not found {nameof(_inGameManager)}");
            }
            _runnerMovement = GetComponent<RunnerMovement>();
            _shootManager = GetComponent<ShootManager>();

            if (_runnerMovement == null) {
                UnityEngine.Debug.Log($"{_runnerMovement} has not found {nameof(_inGameManager)}");
            } 
            if (_shootManager == null) {
                UnityEngine.Debug.Log($"{_runnerMovement} has not found {nameof(_inGameManager)}");
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
                _inGameManager.MinusRunner();
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