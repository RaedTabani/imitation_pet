using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Helper{
    public class ExperincePoint : MonoBehaviour,ICollectable
    {
        public CollectableType Type =>type;
        public float Value =>value;

        [SerializeField] private CollectableType type;
        [SerializeField] private float value;

        public void Collect(){
            Destroy(gameObject);
        }
    }
}