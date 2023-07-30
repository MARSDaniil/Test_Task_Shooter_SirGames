using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Game.Field {
    public class MobGenerator :Generator {
        [SerializeField] private int countOfRunners;
        [SerializeField] private GameObject runnerPrefab;
        [SerializeField] private int countOfBirds;
        [SerializeField] private GameObject birdsPrefab;
        private GameObject[] runnerList;
        private GameObject[] birdList;

        private void Start() {
            Init();
        }
        private void Init() {
            sizeOfPlane = _inGameManager.sizeOfField;
            SetItem(ref runnerList, countOfRunners, runnerPrefab);
            SetItem(ref birdList, countOfBirds, birdsPrefab);
        }

        public void MunisRunnerCount() => countOfRunners--;
        public void MunisBirdCount() => countOfBirds--;
    }
}
