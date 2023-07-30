using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Config.Characters;
namespace Game.Characters.Player {

    public class Player: Character {

        PlayerMovement _playerMovement;
        ShootManager _shootManager;
        Rotate _rotate;

        private void Awake() {
            Init();
        }
        public override void Init() {
            _playerMovement = GetComponent<PlayerMovement>();
            _shootManager = GetComponent<ShootManager>();
            _rotate = GetComponentInChildren<Rotate>();
            
            //base.Init();
        }
        public void SetVectorByJoystick(Vector2 value) {
            _rotate.SetDirectionVector(value);
            _playerMovement.SetDirectionVector(value);
            if(value != Vector2.zero) _shootManager.SetVectorOfShooting(value);
        }

        public void SetShootManagerAvailible(bool value) => _shootManager.SetAvailibleOfShoot(value);
    }
}