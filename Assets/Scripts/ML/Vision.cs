using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI{
    public class Vision : MonoBehaviour
    {
        [SerializeField] private Collider target;
        private Bounds bounds;

        void Start(){
            bounds = target.bounds;
        }

    }
}