using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Characters.Components;
namespace Game.Weapons.Bullet {
    [RequireComponent(typeof(Rigidbody))]
    public class Bullet : Movement {
        private void Update() {
            Direction = new Vector3(1, 0, 1);
        }
    }
}
