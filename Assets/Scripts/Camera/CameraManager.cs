using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game;
namespace CameraManagerNS {
    public class CameraManager :MonoBehaviour {
        Camera camera;
        InGameManager _inGameManager;
        private  Vector2Int sizeOfField;

        private void Awake() {
            camera = GetComponent<Camera>();
            _inGameManager = FindObjectOfType<InGameManager>();
            if (!_inGameManager) {
                UnityEngine.Debug.Log($"{this} has not found {nameof(_inGameManager)}");
            }
            sizeOfField = _inGameManager.sizeOfField;
        }
        void Start() {
            camera.transform.position = new Vector3(0f, 5f, sizeOfField.x / 2);
            if (sizeOfField.y > sizeOfField.x) camera.orthographicSize = sizeOfField.y / 2;
            else camera.orthographicSize = sizeOfField.x / 2;
        }

    }
}