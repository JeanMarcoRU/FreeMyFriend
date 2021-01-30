using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{

    public float[] positionsX = new float[5];
    public float[] positionsY = new float[5];
    public string name;
    public GameObject doorSound;
    public GameObject dialog;


    System.Random rnd;

    // Start is called before the first frame update
    void Start()
    {
       rnd = new System.Random();
        int rndN = rnd.Next(3);
        transform.position = new Vector3(positionsX[rndN], positionsY[rndN], -1);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if(dialog != null)
            {
                dialog.SetActive(true);
            }
            foreach (var gameObj in FindObjectsOfType(typeof(GameObject)) as GameObject[])
            {
                if (gameObj.name == name)
                {
                    
                    Destroy(gameObj);
                }
            }

            Instantiate(doorSound);
            Destroy(gameObject);

        }

    }
}
