using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
namespace Helper{
    public class Arena : MonoBehaviour
    {
        [SerializeField] private Transform holder; 
        private List<ICollectable> collectables ;


        private void Awake(){
            collectables = new List<ICollectable>();
            Populate();
        }

        private void OnEnable(){
            foreach(ICollectable collectable in collectables)
                collectable.GameObject.SetActive(true);
        }

        private void Populate(){
            foreach (Transform childTransform in holder)
            {
                ICollectable collectableComponent = childTransform.GetComponent<ICollectable>();
                if (collectableComponent != null)
                {
                    collectables.Add(collectableComponent);
                }
            }
        }
    }
}