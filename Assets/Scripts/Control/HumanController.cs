using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Movement;

namespace Control{

    [RequireComponent(typeof(Mover))]
    [RequireComponent(typeof(Jumper))]
    public class HumanController : MonoBehaviour
    {
        private Mover mover;
        private Jumper jumper;
        private void Start()
        {
            mover = GetComponent<Mover>();
            jumper = GetComponent<Jumper>();
        }

        private void Update(){
            if(Input.GetKey(KeyCode.Space))
                jumper.Jump(1);
            else if(Input.GetKeyUp(KeyCode.Space))
                jumper.Jump(0);
        }
        // Update is called once per frame
        private void FixedUpdate()
        {
            float x = Input.GetAxis("Horizontal");
            float y = Input.GetAxis("Vertical");

            mover.Move(new Vector2(x,y));

        }
    }
}