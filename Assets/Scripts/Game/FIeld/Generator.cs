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

        protected void SetItem(ref GameObject[] gameObjects, int count, GameObject gameObject = null,bool randomNum = false, List<GameObject> obstaclePrefabsList = null, float hight = 0) {
            gameObjects = new GameObject[count];
            for (int i = 0; i < count; i++) {
                Vector3 coord = GenerateRandomVectorInt(sizeOfPlane,hight,false,_inGameManager);
                if (randomNum) {
                    int num = GenerateRandomNumOfList(obstaclePrefabsList.Count);
                    gameObjects[i] = Instantiate(obstaclePrefabsList[num], coord, Quaternion.identity);
                }
                else gameObjects[i] = Instantiate(gameObject, coord, Quaternion.identity);
            }

        }
        protected int GenerateRandomNumOfList(int lenghtOfList) => (Random.Range(0, lenghtOfList));
        public Vector3 GenerateRandomVectorInt(Vector2Int size, float hight = 0, bool needAddToList = false,InGameManager inGameManager = null) {
            bool isFree = false;
            Vector3 vector3 = new Vector3(0, hight, 0);
            while (!isFree) {
                vector3.x = Random.Range(-size.y / 2 + 1, size.y / 2);
                vector3.z = Random.Range(size.x / 3, size.x);

                if (inGameManager.occupiedPositions.Count == 0) isFree = true;
                int i = 0;
                while (i < inGameManager.occupiedPositions.Count && !isFree) {
                    if (vector3.x == inGameManager.occupiedPositions[i].x &&
                        vector3.z == inGameManager.occupiedPositions[i].z) {
                        break;
                    }
                    if (i == inGameManager.occupiedPositions.Count - 1) isFree = true;
                    i++;
                }
            }
            if(!needAddToList) inGameManager.occupiedPositions.Add(vector3);
            return (vector3);
        }
    }
}