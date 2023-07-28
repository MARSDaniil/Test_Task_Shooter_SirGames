using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Characters.Components;
namespace Game.Weapons.Bullet {
    [RequireComponent(typeof(Rigidbody))]
    public class Bullet : Movement {
        private void Update() {
        }

        public void SetDirectionOfBullet(Vector3 value) => Direction = value;

    }
}
