using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private int totalKids;
    public float moveSpeed = 5f;

    public GameObject wonGameUI;
    public Rigidbody2D rb;
    public Animator animator;
    public GameObject stepsSound;
    public GameObject winSound;
    public GameObject loseSound;
    public GameObject[] steps;
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
        if(!stopPlayer)
        {
            totalKids = FindObjectsOfType<Kid> ().Length;
            if(totalKids > 0)
            {
                movement.x = Input.GetAxisRaw("Horizontal");
                movement.y = Input.GetAxisRaw("Vertical");

                animator.SetFloat("Horizontal", movement.x);
                animator.SetFloat("Vertical", movement.y);
                animator.SetFloat("Speed", movement.sqrMagnitude);
            }
            else
            {
                // provocar sonido de victoria
                if(bandera){
                    Instantiate(winSound);
                    this.bandera = false;
                }             

                Timer.stopTimer = true;
                Timer.myText.text = "";
                wonGameUI.SetActive(true);
            }
        }
         
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
            animator.SetFloat("Speed", 0f);
        }
    }
}
