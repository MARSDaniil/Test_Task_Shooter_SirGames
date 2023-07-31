using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Config.Characters;
using Game;

namespace Game.Characters {

    public abstract class Character: MonoBehaviour {
        public CharactersConfig charactersConfig;
        public float HP { get; protected set; }
        public float MaxHP { get; protected set; }
        public bool IsDead { get; protected set; }
        public bool Inited { get; private set; }
        public float TimeInterval { get; protected set; }
        public float Speed { get; protected set; }



        public virtual void Init() {
            MaxHP = charactersConfig.maxHP;
            HP = MaxHP;
            TimeInterval = charactersConfig.shootTimeInterval;
            Speed = charactersConfig.speed;
            IsDead = charactersConfig.isDead;
        }
    }

} 