using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Game.Characters.Runner {
    public class Runner : Character {
        RunnerMovement _runnerMovement;
        ShootManager _shootManager;
        Rotate _rotate;

        private void Awake() {
            Init();
        }
        public override void Init() {
            _runnerMovement = GetComponent<RunnerMovement>();
            _shootManager = GetComponent<ShootManager>();
            _rotate = GetComponentInChildren<Rotate>();

            if (_rotate == null) {
                Debug.LogError("rotate null");
            }
            //base.Init();
        }
    }
}