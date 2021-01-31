using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{

    public GameObject[] npcs = new GameObject[48];
    public GameObject winUI;
    public GameObject mainUI;
    public float[] arrayX = new float[48];
    public float[] arrayY = new float[48];
    public GameObject[] searching = new GameObject[3];
    public Image amigo1;
    public Image amigo2;
    public Image amigo3;
    public Sprite check;

    // Start is called before the first frame update
    public void Awake()
    {
        amigo1 = GameObject.Find("Amigo1").GetComponent<Image>();
        amigo2 = GameObject.Find("Amigo2").GetComponent<Image>();
        amigo3 = GameObject.Find("Amigo3").GetComponent<Image>();

        SearchList();
        Spawm();

    }

    // Update is called once per frame
    void Update()
    {
        if (verifyWin())
        {
            print("AHHHHHHHHHHHHHHHHHHHHHHH");
            GameObject[] timers = GameObject.FindGameObjectsWithTag("Finish");
            GameObject timer = timers[0];
            timer.GetComponent<Timer>().stopTimer = false;
            winUI.SetActive(true);
            mainUI.SetActive(false);
      
        }
    }

    public bool verifyWin()
    {
        bool win = true;
        foreach (GameObject friend in searching)
        {
            if (!friend.GetComponent<NPC>().found)
            {

                win = false;
            }
            
        }
        return win;
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


        amigo1.sprite = searching[0].GetComponent<SpriteRenderer>().sprite;
        amigo2.sprite = searching[1].GetComponent<SpriteRenderer>().sprite;
        amigo3.sprite = searching[2].GetComponent<SpriteRenderer>().sprite;

        amigo1.color = searching[0].GetComponent<SpriteRenderer>().color;
        amigo2.color = searching[1].GetComponent<SpriteRenderer>().color;
        amigo3.color = searching[2].GetComponent<SpriteRenderer>().color;
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
            Vector3 spawnPos = new Vector3(arrayX[randNumber], arrayY[randNumber], -1);
            arrayX[randNumber] = 0f;
            arrayY[randNumber] = 0f;
            Instantiate(npcs[i], spawnPos, Quaternion.identity);


        }
    }
}