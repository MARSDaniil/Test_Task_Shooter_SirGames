using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Weapons.Bullet;

namespace Game {
    public class ShootManager :MonoBehaviour {
        private bool _canShoot = false;
        private List<GameObject> _bulletsListGameObject;
        [SerializeField] private List<Bullet> _bulletsList;
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] Transform firePoint; 
        private void Update() {
            if (_canShoot) Shoot();
        }

        private void Shoot() {
            bool freeBullet = false;
            /*
            for (int i = 0; i < _bulletsListGameObject.Count; i++) {
                if (!_bulletsListGameObject[i].activeInHierarchy) {
                    _bulletsListGameObject[i].transform.position = firePoint.transform.position;
                    _bulletsListGameObject[i].transform.rotation = firePoint.transform.rotation;
                    _bulletsListGameObject[i].GetComponent<Bullet>().SetDirectionOfBullet(new Vector3(1,0,1));
                    _bulletsListGameObject[i].SetActive(true);
                    freeBullet = true;
                   // setForceToBullet(i);
                    break;
                }
            }

            if (!freeBullet) {
               // _bulletsListGameObject.Add(Instantiate((GameObject)Resources.Load("Prefab/Bullet"), firePoint.position, firePoint.rotation));
                _bulletsListGameObject.Add(Instantiate(bulletPrefab, firePoint.position, firePoint.rotation));
                _bulletsList.Add(_bulletsListGameObject[_bulletsListGameObject.Count - 1].GetComponent<Bullet>());
                _bulletsList[_bulletsList.Count-1].SetDirectionOfBullet(new Vector3(1, 0, 1));
                //SetForceToBullet(_bulletsList.Count - 1);
            }
            */
            GameObject bulletObj = Instantiate(bulletPrefab, firePoint.position, new Quaternion(firePoint.rotation.x , firePoint.rotation.y + 90, firePoint.rotation.z+ 90 , 1));
            Bullet bullet = bulletObj.GetComponent<Bullet>();
            bullet.SetDirectionOfBullet(new Vector3(1, 0, 1));
        }

        public void SetAvailibleOfShoot(bool value) => _canShoot = value;
    }
}