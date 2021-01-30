﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialog : MonoBehaviour
{

    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    public float typingSpeed;

    public GameObject continuarButton;
    public GameObject dialogCanvas;

    void Start()
    {
        Timer.stopTimer = true;
        PlayerMovement.stopPlayer = true;
        dialogCanvas.SetActive(true);
        StartCoroutine(Type());
    }

    void Update()
    {
        if(textDisplay.text == sentences[index])
        {
            continuarButton.SetActive(true);
        }
    }

    IEnumerator Type()
    {
        foreach(char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextSentence()
    {
        continuarButton.SetActive(false);

        if(index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else
        {
            textDisplay.text = "";
            Timer.stopTimer = false;
            PlayerMovement.stopPlayer = false;
            continuarButton.SetActive(false);
            dialogCanvas.SetActive(false);
        }
    }
}
