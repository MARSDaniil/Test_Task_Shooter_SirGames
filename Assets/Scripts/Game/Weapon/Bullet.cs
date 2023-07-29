using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Characters.Components;
namespace Game.Weapons.Bullet {
    [RequireComponent(typeof(Rigidbody))]
    public class Bullet : Movement {
        [SerializeField] float timeOfLife;
        private void Update() {
        }

        public void SetDirectionOfBullet(Vector3 value) => Direction = value;

        private void OnEnable() {
            StartCoroutine(SetActiveFalseBullet());
        }

        IEnumerator SetActiveFalseBullet() {
            yield return new WaitForSeconds(timeOfLife);
            gameObject.SetActive(false);
        }
        private void OnCollisionEnter(Collision collision) {
            gameObject.SetActive(false);
        }
        
    }
}
