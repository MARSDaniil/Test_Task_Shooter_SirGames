using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Game.Field {
    public class ObstacleGenerator :MonoBehaviour {
        [SerializeField] GameFieldManger gameFieldManger;
        [SerializeField] GameObject wallXRight;
        [SerializeField] GameObject wallXLeft;
        [SerializeField] GameObject wallYUp;
        [SerializeField] GameObject wallYDown;

        public GameObject[] obstacleList { get; set; }
        public List<GameObject> obstaclePrefabsList;
        private Vector2Int sizeOfPlane;

        InGameManager _inGameManager;

        private void Start() {
            _inGameManager = FindObjectOfType<InGameManager>();
            if (!_inGameManager) {
                UnityEngine.Debug.LogError($"{this} has not found {nameof(_inGameManager)}");
            }

            Init();
        }

        private void Init() {
            sizeOfPlane = _inGameManager.sizeOfField;
            SetWalls();
            SetObstacle();



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

        private int GenerateRandomNumOfList(int lenghtOfList) => (Random.Range(0, lenghtOfList));
        private Vector3 GenerateRandomVectorInt(Vector2Int size) {
            int rndX = Random.Range(-size.y / 2 + 1, size.y / 2);
            int rndY = Random.Range(size.x / 3, size.x);
            return (new Vector3(rndX,0.5f, rndY));
        }
    }
}