using System.Collections;
using UnityEngine;
using Game.Characters.Components;
using Config.Items.Bullet;
namespace Game.Weapons.Bullet {
    [RequireComponent(typeof(Rigidbody))]
    public class Bullet : Movement {
        [SerializeField] BulletConfig bulletConfig;

        public void SetDirectionOfBullet(Vector3 value) => Direction = value;

        private void OnEnable() {

            Speed = bulletConfig.speed;
            StartCoroutine(SetActiveFalseBullet());
        }

        IEnumerator SetActiveFalseBullet() {
            yield return new WaitForSeconds(bulletConfig.timeOfLife);
            gameObject.SetActive(false);
        }
        private void OnCollisionEnter(Collision collision) {
            gameObject.SetActive(false);
        }
        
    }
}
