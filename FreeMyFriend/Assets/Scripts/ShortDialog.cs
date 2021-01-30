using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShortDialog : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    public float typingSpeed;

    void Start()
    {
        StartCoroutine(type());
    }

    IEnumerator type()
    {
        foreach(char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
}
