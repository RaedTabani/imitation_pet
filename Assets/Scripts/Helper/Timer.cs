using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Events;
using AI;
namespace Helper{
    
    public class Timer : MonoBehaviour,IObserver
    {
        [SerializeField] private Pet_1 subject;  

        public float counter =0;

        public int Counter{get=> (int) counter;}
        
        private void OnEnable() {
            subject.GetComponent<ISubject>().Add(this);
        }
        private void OnDisable() {
            subject.GetComponent<ISubject>().Remove(this);
        }
        void FixedUpdate()
        {
            counter++;
        }
        public void Notify(){
            Reset();
        }

        public void Reset(){
            counter =0;
        }
    }
}