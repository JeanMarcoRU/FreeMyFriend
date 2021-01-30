using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private int totalKids;
    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    public static bool stopPlayer = false;
    public static bool isLose = false;
    public GameObject[] risasWin;
    private bool bandera = true;
    private bool bandera2 = true;

    Vector2 movement;

    void Start()
    {
        stopPlayer = false;
        bandera2 = true;
    }

    // Update is called once per frame
    void Update()
    {
       
          
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

         
        /*if(bandera2 && isLose){
            print("holi print");
            Instantiate(loseSound);
            this.bandera2 = false;
        }*/
    }

    void FixedUpdate() 
    {
        if(!PauseMenu.GameIsPaused && !stopPlayer)
        {
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
         
        }
    }
}
