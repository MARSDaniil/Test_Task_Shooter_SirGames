using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Config.Characters {
    [CreateAssetMenu(fileName = "MobConfig", menuName = "Configs/Characters/MobConfig")]
    public class MobConfig : CharactersConfig {
        public float shootDistance;
    }
}