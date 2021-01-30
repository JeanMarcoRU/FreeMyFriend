using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;


public class RandomMov : MonoBehaviour
{
    private float timeToChangeDirection;
    private float[] angles = new float[4];
    private float angle;

    public Animator animator;
    public Rigidbody2D rb;

    Vector2 movement;

    // Use this for initialization
    public void Start()
    {
        angles[0] = 0f;
        angles[1] = 90f;
        angles[2] = 180f;
        angles[3] = 270f;

        ChangeDirection();
    }

    // Update is called once per frame
    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            print("This is C#");
        }
        timeToChangeDirection -= Time.deltaTime;

        if (timeToChangeDirection <= 0)
        {
            ChangeDirection();
        }
        else
        {
            switch (angle)
            {
                case 0f:
                    movement.x = movement.x++;
                    movement.y = 0f;
                    break;
                case 90f:
                    movement.x = 0f;
                    movement.y = movement.y++;
                    break;
                case 180f:
                    movement.x = movement.x--;
                    movement.y = 0f;
                    break;
                case 270f:
                    movement.x = 0f;
                    movement.y = movement.y--;
                    break;
                default:
                    Console.WriteLine("Default case");
                    break;
            }
        }
        //GetComponent<Rigidbody2D>().velocity = transform.up * 1;
        rb.MovePosition(rb.position + movement * 3 * Time.fixedDeltaTime);
        animator.SetFloat("speed", 1f);

    }

    private void ChangeDirection()
    {
        int randNumber = UnityEngine.Random.Range(0,4);
        angle = angles[randNumber];
        switch (angle)
        {
            case 0f:
                animator.SetFloat("Horizontal", 1f);
                animator.SetFloat("Vertical", 0f);
                movement.x = 1f;
                movement.y = 0f;
                break;
            case 90f:
                animator.SetFloat("Horizontal", 0f);
                animator.SetFloat("Vertical", 1f);
                movement.x = 0f;
                movement.y = 1f;
                break;
            case 180f:
                animator.SetFloat("Horizontal", -1f);
                animator.SetFloat("Vertical", 0f);
                movement.x = -1f;
                movement.y = 0f;
                break;
            case 270f:
                animator.SetFloat("Horizontal", 0f);
                animator.SetFloat("Vertical", -1f);
                movement.x = 0f;
                movement.y = -1f;
                break;
            default:
                Console.WriteLine("Default case");
                break;
        }
        //Quaternion quat = Quaternion.AngleAxis(angle, Vector3.forward);
        //Vector3 newUp = quat * Vector3.up;
        //newUp.z = 0;
        //newUp.Normalize();
        //transform.up = newUp;
        timeToChangeDirection = 1.5f;
    }

 

    private void OnCollisionStay2D(Collision2D other)
    {
        ChangeDirection();

    }


}