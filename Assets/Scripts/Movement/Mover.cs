using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Movement{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Mover : MonoBehaviour
    {
        [SerializeField] private bool xAxis;
        [SerializeField] private bool yAxis; 

        [SerializeField] private float speed;

        public Vector2 Velocity{get=>rb.velocity;}
        private Rigidbody2D rb;

        void Start()
        {
            rb = GetComponent<Rigidbody2D>();    
        }

        public void Move(Vector2 direction){
            Vector2 velocity = Vector2.zero;
            if(xAxis)
                velocity += new Vector2(direction.x,0);
            if(yAxis)
                velocity += new Vector2(0,direction.y);

            //Debug.Log($"{direction.x} {velocity.x}");
            rb.velocity = new Vector2(velocity.x * speed,rb.velocity.y);
        }
    }
}