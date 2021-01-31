using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Transform theTransfomr;
    public Vector2 Hrange = Vector2.zero;
    public Vector2 Vrange = Vector2.zero;
   
    public float moveSpeed = 100f;

    public Rigidbody2D rb;
    public static bool stopPlayer = false;
    public static bool isLose = false;

    Vector2 movement;

    void Start()
    {
        stopPlayer = false;
        theTransfomr = GetComponent<Transform> ();
    
    }

    // Update is called once per frame
    void Update()
    {
       
          
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        
        theTransfomr.position = new Vector3(

            Mathf.Clamp(transform.position.x,Vrange.x,Vrange.y),
            Mathf.Clamp(transform.position.y,Hrange.x,Hrange.y),
            transform.position.z

        );

         
    }

    void FixedUpdate() 
    {
      
        
       rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
         
        
    }
}
