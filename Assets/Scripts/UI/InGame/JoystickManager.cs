using UnityEngine;

namespace UI.InGame {
    public class JoystickManager :MonoBehaviour {
        public Joystick joystick;

        public Vector2 Direction => joystick.Direction.sqrMagnitude > Mathf.Epsilon
            ? joystick.Direction
            : new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

    }
}