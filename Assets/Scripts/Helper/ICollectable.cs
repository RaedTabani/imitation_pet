using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Helper{
    public interface ICollectable 
    {
        public CollectableType Type{get;}
        public GameObject GameObject{get;}
        public float Value{get;}

        public void Collect();
    }

    public enum CollectableType{
        Coin,
        XP
    }
}