using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Characters.Components;
using Game.Field;

namespace Game.Characters.Bird {
    public class BirdMovement :Movement {
        Bird bird;
        Transform playerPosition;
        Rotate _rotate;
        [SerializeField]Generator generator;
        [SerializeField] float shootDistance;
        [SerializeField] float timeToChangeLocation;
        public bool isGameStarted = false;
        InGameManager _inGameManager;
        private Vector3 nextPosition;
        private Vector2Int _sizeOfMap;
        private bool canMove = true;
        // Update is called once per frame
        public override void FixedUpdate() {
            base.FixedUpdate();
            if (isGameStarted) {
                if (!DeltaPosition(playerPosition, shootDistance) && canMove) {
                    transform.position = generator.GenerateRandomVectorInt(_sizeOfMap, 0, true, _inGameManager); 
                    canMove = false;
                    bird.canShoot = false;
                }
                else {
                    bird.SetShootVector(playerPosition.position);
                    bird.canShoot = true;
                }
                _rotate.SetDirectionVector(new Vector2(playerPosition.position.x - gameObject.transform.position.x, playerPosition.position.z - gameObject.transform.position.z));
                if (!canMove) StartCoroutine(CanMove());
            }
        }

        public void Init(GameObject player, float speed,Vector2Int sizeOfMap) {
            _inGameManager = FindObjectOfType<InGameManager>();
            bird = GetComponent<Bird>();
            playerPosition = player.GetComponent<Transform>();
            Speed = speed;
            _rotate = GetComponentInChildren<Rotate>();
            _sizeOfMap = sizeOfMap;
        }
       private IEnumerator CanMove() {
            yield return new WaitForSeconds(timeToChangeLocation);
            canMove = true;
        }
    }
}