using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Config.Characters;
namespace Game.Characters {

    public abstract class Character: MonoBehaviour {
        CharactersConfig charactersConfig;
        public float HP { get; protected set; }
        public float MaxHP { get; protected set; }
        public bool IsDead { get; protected set; }
        public bool Inited { get; private set; }
        public float DamageValue { get; protected set; }

        public void Init() {
            MaxHP = charactersConfig.maxHP;
            HP = MaxHP;
            DamageValue = charactersConfig.shootValue;
        }
    }

} 