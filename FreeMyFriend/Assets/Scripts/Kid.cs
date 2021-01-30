using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using static System.Console;

public class Kid : MonoBehaviour
{

    public float[] positionsX = new float[5];
    public float[] positionsY = new float[5];
    public GameObject[] risas;

    public GameObject risaSound;
    public GameObject llorarSound;
    public GameObject dialog;


    System.Random rnd; 

    // Start is called before the first frame update
    void Start()
    {
        rnd = new System.Random();
        
    }

    // Update is called once per frame
    void Update()
    {
      
        if((Math.Round(FindObjectOfType<Timer>().timeInSecondsToShow % 30)) == 0f)
        {   
            risas = GameObject.FindGameObjectsWithTag("RHH");

            foreach (GameObject sound in risas)
            {
                Destroy(sound);               
            }
            Instantiate(risaSound);
            int rndN = rnd.Next(3);
            transform.position = new Vector3(positionsX[rndN], positionsY[rndN], -1);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            dialog.SetActive(true);
            Instantiate(llorarSound);
            Destroy(gameObject);
  
        }
        
    }


}
    