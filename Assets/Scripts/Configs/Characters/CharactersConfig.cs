using UnityEngine;
namespace Config.Characters {
    [CreateAssetMenu(fileName = "ÑharacterConfig", menuName = "Configs/Characters/ÑharacterConfig")]
    public class CharactersConfig : ScriptableObject {
        public float maxHP;
        public float speed;
        public float shootTimeInterval;
        public bool isDead;
    }
}