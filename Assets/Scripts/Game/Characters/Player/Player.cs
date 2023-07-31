using UnityEngine;
namespace Game.Characters.Player {
    public class Player: Character {

        PlayerMovement _playerMovement;
        ShootManager _shootManager;
        Rotate _rotate;

        private void Awake() {
            Init();
        }
        public override void Init() {
            base.Init();
            _playerMovement = GetComponent<PlayerMovement>();
            _shootManager = GetComponent<ShootManager>();
            _rotate = GetComponentInChildren<Rotate>();
            _playerMovement.SetSpeed(Speed);
        }
        public void SetVectorByJoystick(Vector2 value) {
            _rotate.SetDirectionVector(value);
            _playerMovement.SetDirectionVector(value);
            if(value != Vector2.zero) _shootManager.SetVectorOfShooting(value);
        }
        private void Start() {
            _shootManager.SetTimeBetweenShoots(charactersConfig.shootTimeInterval);
        }
        public void SetShootManagerAvailible(bool value) => _shootManager.SetAvailibleOfShoot(value);

        public void OnCollisionEnter(Collision collision) {

            switch (collision.gameObject.tag) {
                case "Obstacle":
                HP = HP - 5;
                break;
                case "Mob":
                HP = HP - 20;
                break;
                case "Bullet":
                HP = HP - 10;
                break;

            }
            if (HP <= 0) IsDead = true;
        }

    }
}