using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;


public class RandomMov : MonoBehaviour
{
    private float timeToChangeDirection;
    private float[] angles = new float[4];

    // Use this for initialization
    public void Start()
    {
        angles[0] = 0f;
        angles[1] = 90f;
        angles[2] = 270f;
        angles[3] = 360f;

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

        GetComponent<Rigidbody2D>().velocity = transform.up * 1;
    }

    private void ChangeDirection()
    {
        int randNumber = UnityEngine.Random.Range(0,4);
        float angle = angles[randNumber];
        Quaternion quat = Quaternion.AngleAxis(angle, Vector3.forward);
        Vector3 newUp = quat * Vector3.up;
        newUp.z = 0;
        newUp.Normalize();
        transform.up = newUp;
        timeToChangeDirection = 2f;
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        ChangeDirection();

    }


}