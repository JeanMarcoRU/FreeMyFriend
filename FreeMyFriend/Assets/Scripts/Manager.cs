using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Manager : MonoBehaviour
{

    public GameObject[] npcs = new GameObject[48];
    public float[] arrayX = new float[48];
    public float[] arrayY = new float[48];
    private GameObject[] searching = new GameObject[3];

    // Start is called before the first frame update
    void Start()
    {
        SearchList();
        Spawm();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SearchList()
    {
        int randNumber;
        for (int j = 0; j < 3; j++)
        {
            randNumber = Random.Range(0, 48);
            while (searching.Contains(npcs[randNumber]))
            {
                randNumber = Random.Range(0, 48);
            }
                
            searching[j] = npcs[randNumber];
        }
        

    }

    public void Spawm()
    {
        for (int i = 0; i < 48; i++)
        {
            int randNumber = Random.Range(0, 48);
            while ( arrayX[randNumber]  == 0f || arrayY[randNumber] == 0f)
            {
                randNumber = Random.Range(0, 48);
                
            }
            Vector3 spawnPos = new Vector3(arrayX[randNumber], arrayY[randNumber],-1);
            arrayX[randNumber] = 0f;
            arrayY[randNumber] = 0f;
            Instantiate(npcs[i], spawnPos, Quaternion.identity);


        }
    }
}