using UnityEngine;
using UnityEngine.AI;
namespace Game.Characters.Runner {
    public class RunnerMovement: MonoBehaviour {
        Runner runner;
        NavMeshAgent _navMeshAgent;
        Transform playerPosition;
        Rotate _rotate;
        [SerializeField] float shootDistance;

        public bool isGameStarted = false;
     
        void FixedUpdate() {
            if (isGameStarted) {
                _navMeshAgent.destination = playerPosition.position;
                if (!DeltaPosition()) {
                    _rotate.SetDirectionVector(new Vector2(_navMeshAgent.desiredVelocity.x, _navMeshAgent.desiredVelocity.z));
                    runner.canShoot = false;
                }
                else {
                    runner.SetShootVector(playerPosition.position);
                    runner.canShoot = true;
                    _navMeshAgent.velocity = Vector3.zero;
                    _rotate.SetDirectionVector(new Vector2(_navMeshAgent.desiredVelocity.x, _navMeshAgent.desiredVelocity.z));
                }
            }
        }

        public void Init(GameObject player, float speed) {
            runner = GetComponent<Runner>();
            _navMeshAgent = GetComponent<NavMeshAgent>();
            playerPosition = player.GetComponent<Transform>();
            _navMeshAgent.speed = speed;
            _rotate = GetComponentInChildren<Rotate>();
            if (_rotate == null) {
                Debug.LogError("rotate null");
            }
        }
        private bool DeltaPosition() {
            Vector2 vector = DeltaVector();
            if (Mathf.Abs(vector.x) < shootDistance &&
                Mathf.Abs(vector.y) < shootDistance) return true;
            return false;
        }

        private Vector2 DeltaVector() {
            float vectorX = -gameObject.transform.position.x + playerPosition.position.x;
            float vectorZ = -gameObject.transform.position.z + playerPosition.position.z;
            return new Vector2(vectorX, vectorZ);
        }
        public void SetShootDistance(float value) => shootDistance = value;
    }
}