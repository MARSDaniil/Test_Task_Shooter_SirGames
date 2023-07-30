using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Game.Field {
    public class Generator :MonoBehaviour {
        // Start is called before the first frame update
        protected InGameManager _inGameManager;
        protected Vector2Int sizeOfPlane;
        protected void Awake() {
            _inGameManager = FindObjectOfType<InGameManager>();
            if (!_inGameManager) {
                UnityEngine.Debug.LogError($"{this} has not found {nameof(_inGameManager)}");
            }
            sizeOfPlane = _inGameManager.sizeOfField;
        }

        protected void SetItem(ref GameObject[] gameObjects, int count, GameObject gameObject = null,bool randomNum = false, List<GameObject> obstaclePrefabsList = null) {
            gameObjects = new GameObject[count];
            for (int i = 0; i < count; i++) {
                Vector3 coord = GenerateRandomVectorInt(sizeOfPlane);
                if (randomNum) {
                    int num = GenerateRandomNumOfList(obstaclePrefabsList.Count);
                    gameObjects[i] = Instantiate(obstaclePrefabsList[num], coord, Quaternion.identity);
                }
                else gameObjects[i] = Instantiate(gameObject, coord, Quaternion.identity);
            }

        }
        protected int GenerateRandomNumOfList(int lenghtOfList) => (Random.Range(0, lenghtOfList));
        protected Vector3 GenerateRandomVectorInt(Vector2Int size) {
            bool isFree = false;
            Vector3 vector3 = new Vector3(0, 0.5f, 0);
            while (!isFree) {
                vector3.x = Random.Range(-size.y / 2 + 1, size.y / 2);
                vector3.z = Random.Range(size.x / 3, size.x);

                if (_inGameManager.occupiedPositions.Count == 0) isFree = true;
                int i = 0;
                while (i < _inGameManager.occupiedPositions.Count && !isFree) {
                    if (vector3.x == _inGameManager.occupiedPositions[i].x &&
                        vector3.z == _inGameManager.occupiedPositions[i].z) {
                        break;
                    }
                    if (i == _inGameManager.occupiedPositions.Count - 1) isFree = true;
                    i++;
                }
            }
            _inGameManager.occupiedPositions.Add(vector3);
            return (vector3);
        }
    }
}