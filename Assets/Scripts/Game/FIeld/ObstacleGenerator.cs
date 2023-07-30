using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
namespace Game.Field {
    public class ObstacleGenerator :Generator {
        [SerializeField] GameFieldManger gameFieldManger;
        [SerializeField] GameObject wallXRight;
        [SerializeField] GameObject wallXLeft;
        [SerializeField] GameObject wallYUp;
        [SerializeField] GameObject wallYDown;

        private GameObject[] obstacleList;
        public List<GameObject> obstaclePrefabsList;
        

        NavMeshSurface navMeshSurface;

        
        private void Start() {
            _inGameManager = FindObjectOfType<InGameManager>();
            if (!_inGameManager) {
                UnityEngine.Debug.LogError($"{this} has not found {nameof(_inGameManager)}");
            }
            navMeshSurface = GetComponent<NavMeshSurface>();
            StartCoroutine(Init());

        }

        private IEnumerator Init() {
            
            SetWalls();
            //SetObstacle();
            SetItem(ref obstacleList, _inGameManager.CountOfObstacle,null, true, obstaclePrefabsList);
            yield return null;

            navMeshSurface.BuildNavMesh();

        }

        private void SetPosToWall(GameObject gameObject, Vector3 scale, Vector3 pos) {
            gameObject.transform.localScale = scale;
            gameObject.transform.position = pos;
            gameObject.SetActive(true);
        }

        private void SetWalls() {
            SetPosToWall(wallXRight,
                new Vector3(wallXRight.transform.localScale.x, wallXRight.transform.localScale.y, sizeOfPlane.x),
                new Vector3(sizeOfPlane.y / 2, 0, sizeOfPlane.x / 2));
            SetPosToWall(wallXLeft,
                new Vector3(wallXLeft.transform.localScale.x, wallXLeft.transform.localScale.y, sizeOfPlane.x),
                new Vector3(-sizeOfPlane.y / 2, 0, sizeOfPlane.x / 2));
            SetPosToWall(wallYUp,
                new Vector3(sizeOfPlane.y, wallYUp.transform.localScale.y, wallYUp.transform.localScale.y),
                new Vector3(0, 0, sizeOfPlane.x));
            SetPosToWall(wallYDown,
                new Vector3(sizeOfPlane.y, wallYDown.transform.localScale.y, wallYDown.transform.localScale.y),
                new Vector3(0, 0, 0));
        }

        private void SetObstacle() {
            obstacleList = new GameObject[_inGameManager.CountOfObstacle];
            for (int i = 0; i < obstacleList.Length; i++) {
                int num = GenerateRandomNumOfList(obstaclePrefabsList.Count);
                Vector3 coord = GenerateRandomVectorInt(sizeOfPlane);
                obstacleList[i] = Instantiate(obstaclePrefabsList[num],coord,Quaternion.identity);
            }
        }

       
    }
}