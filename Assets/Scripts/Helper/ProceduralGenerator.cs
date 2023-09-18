using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace Helper{
    public class ProceduralGenerator : MonoBehaviour
    {
        [SerializeField] private Arena[] prefabs;
        private List<Arena> arenas;       

        void Start()
        {
            arenas = new List<Arena>();
            for(int i=0;i< prefabs.Length;i++){
                arenas.Add(Instantiate(prefabs[i],Vector3.zero,Quaternion.identity,transform));
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
        
    }
}