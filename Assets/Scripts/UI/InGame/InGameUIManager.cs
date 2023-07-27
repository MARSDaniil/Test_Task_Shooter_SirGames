using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace UI.InGame {
    public class InGameUIManager :MonoBehaviour {
        [Header("Input")]
        public GameObject input;
        public JoystickManager joystickManager;
        public Button ShootButton;
    }
}