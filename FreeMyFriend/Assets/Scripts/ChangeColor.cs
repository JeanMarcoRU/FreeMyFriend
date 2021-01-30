﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class ChangeColor : MonoBehaviour
{
    private float timeToChangeColor;
    private float timeToBlack;
    public Light2D light;
    public Color[] colorList = new Color[5];
    public Color black;
    // Start is called before the first frame update
    void Start()
    {
        timeToChangeColor = 0.2f;
        timeToBlack = 5f;
    }

    // Update is called once per frame
    void Update()
    {

        timeToChangeColor -= Time.deltaTime;
        timeToBlack -= Time.deltaTime;

        if (timeToBlack <= 0)
        {
            LightsOut();
        }
        else if (timeToChangeColor <= 0)
        {
            ChangeColors();
        }

       
       
    }

    private void LightsOut()
    {
        light.color = black;
        timeToChangeColor = 2f;
        timeToBlack = 7f;
    }

    private void ChangeColors()
    {
        int randNumber = UnityEngine.Random.Range(0, 5);
        Color nextColor = colorList[randNumber];
        light.color = nextColor;
        timeToChangeColor = 0.2f;
    }
}
