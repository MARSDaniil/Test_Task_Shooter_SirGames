using UnityEngine;
using UnityEngine.AI;
using Game.Characters.Components;
namespace Game.Characters.Runner {
    public class RunnerMovement:Movement {
        Runner runner;
        NavMeshAgent _navMeshAgent;
        Transform playerPosition;
        Rotate _rotate;
        [SerializeField] float shootDistance;

        public bool isGameStarted = false;
     
        public override void FixedUpdate() {
            base.FixedUpdate();
            if (isGameStarted) {
                _navMeshAgent.destination = playerPosition.position;
                if (!DeltaPosition(playerPosition,shootDistance)) {
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
      
        public void SetShootDistance(float value) => shootDistance = value;
    }
}