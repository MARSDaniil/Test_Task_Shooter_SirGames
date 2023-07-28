using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Config.Characters;
namespace Game.Characters.Player {

    public class Player: Character {

        PlayerMovement _playerMovement;
        ShootManager _shootManager;
        private void Awake() {
            Init();
        }
        public override void Init() {
            _playerMovement = GetComponent<PlayerMovement>();
            _shootManager = GetComponent<ShootManager>();
            //base.Init();
        }
        public void SetVectorByJoystic(Vector2 value) => _playerMovement.SetDirectionVector(value);
        public void SetShootManagerAvailible(bool value) => _shootManager.SetAvailibleOfShoot(value);
    }
}