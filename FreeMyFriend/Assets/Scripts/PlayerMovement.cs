using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   
    public float moveSpeed = 100f;

    public Rigidbody2D rb;
    public static bool stopPlayer = false;
    public static bool isLose = false;

    Vector2 movement;

    void Start()
    {
        stopPlayer = false;
    
    }

    // Update is called once per frame
    void Update()
    {
       
          
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

         
    }

    void FixedUpdate() 
    {
      
        
       rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
         
        
    }
}
