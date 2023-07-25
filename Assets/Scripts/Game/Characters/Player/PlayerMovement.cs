using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Characters.Components;

namespace Game.Characters.Player {
    public class PlayerMovement : Movement {

        private Vector3 vect;
        private void Update() {
            vect = new Vector3(1f, 0f, 0f);
            Direction = vect;
        }
    }
}