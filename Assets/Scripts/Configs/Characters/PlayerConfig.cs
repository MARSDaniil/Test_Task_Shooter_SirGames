
using System;
using UnityEngine;

namespace Config.Characters {
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "Configs/Characters/PlayerConfig")]

    public class PlayerConfig : ScriptableObject {
        public float HP;
        public float MaxHP;
        public bool IsDead;
        public bool Inited;
        public float Speed;
    }
}
