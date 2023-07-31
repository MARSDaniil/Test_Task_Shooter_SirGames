using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Weapons.Bullet;

namespace Game {
    public class ShootManager :MonoBehaviour {
        private bool _canShoot = false;
        [SerializeField] private List<GameObject> _bulletsListGameObject;
        [SerializeField] private List<Bullet> _bulletsList;
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] Transform firePoint;
        private Vector3 DirectrionOfPlayer;
        private float timeBetweenShoots;
        
        private void Update() {
            if (_canShoot) Shoot();

        }

        private void Shoot() {
            bool freeBullet = false;
            
            for (int i = 0; i < _bulletsListGameObject.Count; i++) {
                if (!_bulletsListGameObject[i].activeInHierarchy) {
                    _bulletsListGameObject[i].transform.position = firePoint.transform.position;
                    _bulletsListGameObject[i].transform.rotation = firePoint.transform.rotation;
                    _bulletsList[i].SetDirectionOfBullet(DirectrionOfPlayer);
                    _bulletsListGameObject[i].SetActive(true);
                    freeBullet = true;
                    break;
                }
            }

            if (!freeBullet) {
                _bulletsListGameObject.Add(Instantiate(bulletPrefab, firePoint.position, firePoint.rotation));
                _bulletsList.Add(_bulletsListGameObject[_bulletsListGameObject.Count - 1].GetComponent<Bullet>());
                _bulletsList[_bulletsList.Count-1].SetDirectionOfBullet(DirectrionOfPlayer);
            }
        }

        public void SetAvailibleOfShoot(bool value) => _canShoot = value;
        public void SetVectorOfShooting(Vector3 value) {
            DirectrionOfPlayer.x = value.x;
            DirectrionOfPlayer.z = value.y;
        }


        public void SetTimeBetweenShoots(float value) => timeBetweenShoots = value;
       
    }
}