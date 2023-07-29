using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Config.Characters;
namespace Game.Characters.Components {
    [RequireComponent(typeof(Rigidbody))]
    public abstract class Movement : MonoBehaviour {
        //public MovementConfig movementConfig;
        protected Vector3 Direction { get; set; } = Vector3.zero;

        //public event Action<Vector2> DirectionChanged;
        // public readonly Mutable<bool> IsMoving = new Mutable<bool>();

        //public ModifiedParameter<float> speed = new ModifiedParameter<float>(1f, (f1, f2) => f1 * f2);
        public float Speed { get; protected set; }

        // protected Level level;
        protected Rigidbody _rigidbody;
        CharactersConfig charactersConfig;
        protected virtual void Start() {
           // level = GetComponentInParent<Level>();
         //   speed.BaseValue = movementConfig.baseSpeed;
            _rigidbody = GetComponent<Rigidbody>();
            //StopMovement();
            //  Speed = charactersConfig.speed;
            Speed = 1f;
        }

        public virtual void StopMovement() {
            Direction = Vector3.zero;
      //      IsMoving.Value = false;
            if (_rigidbody) _rigidbody.velocity = Vector3.zero;
        //    DirectionChanged?.Invoke(Direction);
        }

        protected virtual void FixedUpdate() {
         //   IsMoving.Value = Direction.sqrMagnitude > 0 && speed > 0;
            _rigidbody.velocity = (Direction) * Speed;
        }

        protected virtual void OnDisable() => StopMovement();

        void SetDirection(Vector3 newDirection) {
            if (newDirection != Direction)
            {
                Direction = newDirection;
            }
        }
    }
}