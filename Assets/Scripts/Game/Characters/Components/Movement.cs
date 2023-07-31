using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Config.Characters;
namespace Game.Characters.Components {
    [RequireComponent(typeof(Rigidbody))]
    public abstract class Movement : MonoBehaviour {
        protected Vector3 Direction { get; set; } = Vector3.zero;

        public float Speed { get; protected set; }

        protected Rigidbody _rigidbody;
        protected virtual void Start() {
            _rigidbody = GetComponent<Rigidbody>();
        }

        public virtual void StopMovement() {
            Direction = Vector3.zero;
            if (_rigidbody) _rigidbody.velocity = Vector3.zero;
        }

        protected virtual void FixedUpdate() {
            _rigidbody.velocity = (Direction) * Speed;
        }

        protected virtual void OnDisable() => StopMovement();

        public void SetDirection(Vector3 newDirection) {
            if (newDirection != Direction) Direction = newDirection;
        }
    }
}