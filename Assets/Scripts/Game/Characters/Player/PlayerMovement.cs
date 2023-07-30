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

    }
}