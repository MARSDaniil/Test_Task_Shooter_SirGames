using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Config.Items.Bullet {
    [CreateAssetMenu(fileName = "Bullet", menuName = "Configs/Items/Bullet")]
    public class BulletConfig :ScriptableObject {
        public float speed;
        public float timeOfLife;
    }
}