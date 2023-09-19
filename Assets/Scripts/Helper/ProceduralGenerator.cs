using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using Control;
using Events;
using AI;
namespace Helper{
    public class ProceduralGenerator : MonoBehaviour,IController,IObserver
    {
        [SerializeField] private Pet_1 subject;  
        [SerializeField] private Arena[] prefabs;
        private List<Arena> arenas;       

        private void OnEnable() {
            subject.GetComponent<ISubject>().Add(this);
        }

        private void OnDisable() {
            subject.GetComponent<ISubject>().Remove(this);
        }
        void Start()
        {
            arenas = new List<Arena>();
            for(int i=0;i< prefabs.Length;i++){
                Arena arena =Instantiate(prefabs[i],transform);
                arena.transform.localPosition = Vector2.zero;
                arenas.Add(arena);
            }
            Reset();
        }


        private void Update(){
            if(Input.GetKeyDown(KeyCode.A))
                Reset();
        }
        
        private void Reset()
        {   
            for( int i=0;i<arenas.Count;i++)
                arenas[i].gameObject.SetActive(false);

            arenas[Random.Range(0,arenas.Count)].gameObject.SetActive(true);
        }

        public void Notify(){
            Reset();
        }

        
    }
}