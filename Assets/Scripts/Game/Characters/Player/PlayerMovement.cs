using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Characters.Components;
namespace Game.Characters.Player {
    public class PlayerMovement : Movement {

        private Vector3 directionVectorFromJoystick;
        private void Update() {
            Direction = directionVectorFromJoystick;
        }

        public void SetDirectionVector(Vector2 value) {
            directionVectorFromJoystick.x = value.x;
            directionVectorFromJoystick.z = value.y;
            //SetDirectionAngle(value);
        }

        private void SetDirectionAngle(Vector2 value) {
            if (value != Vector2.zero) {
                if (value.x >= 0) transform.rotation = Quaternion.AngleAxis(Mathf.Asin(value.y) * 180 / Mathf.PI, Vector3.down);
                else transform.rotation = Quaternion.AngleAxis(Mathf.Asin(value.y) * 180 / Mathf.PI + 180, Vector3.up);
            }
        }
    }
}