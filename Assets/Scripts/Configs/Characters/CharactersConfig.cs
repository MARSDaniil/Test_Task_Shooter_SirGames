using UnityEngine;
namespace Config.Characters {
    [CreateAssetMenu(fileName = "�haracterConfig", menuName = "Configs/Characters/�haracterConfig")]
    public class CharactersConfig : ScriptableObject {
        public float maxHP;
        public float speed;
        public float shootTimeInterval;
        public bool isDead;
    }
}