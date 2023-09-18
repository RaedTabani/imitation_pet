using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Movement{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Jumper : MonoBehaviour
    {
        [SerializeField] private Transform feet;
        private Rigidbody2D rb;

        private bool isJumping = false;
        private float counter;
        [SerializeField] private float force;
        [SerializeField] private float time;
        [SerializeField] private float radius;
        [SerializeField] private LayerMask groundMask;
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();

            counter =0;
        }

        public void Jump(int value){
            if(value == 0){
                isJumping = false;
                return;
            }

            Debug.Log($" GROUNDED {IsGrounded() } {value}");
            if(IsGrounded()){
                isJumping = true;
                counter = time;
                rb.velocity = new Vector2(rb.velocity.x, force);
            }
            else if(isJumping){
                if(counter >0){
                    rb.velocity = new Vector2(rb.velocity.x, force);
                    counter -=Time.deltaTime;    
                }
                else{
                    isJumping = false;
                }
            }
        }

        private bool IsGrounded(){
            RaycastHit2D hit = Physics2D.Raycast(feet.position, Vector2.down,radius, groundMask);
            return hit.collider != null;
            
        }
        
    }
}