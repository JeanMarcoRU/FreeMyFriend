using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Timer : MonoBehaviour
{
    public int initialTime;
    public GameObject lostGameUI;
    // public GameObject loseSound;

    [Range(-10.0f, 10.0f)]
    public float timeScale = 1;

    public static Text myText;
    private float frameTimeScale = 0f;
    public float timeInSecondsToShow = 0f;
    private float pauseTimeScale, initialTimeScale;
    public bool isPaused = false;
    public static bool stopTimer = false;
    private bool bandera = true;
    private GameObject[] mainCamara;
    private AudioSource[] sounds;

    // Start is called before the first frame update
    void Start()
    {
        stopTimer = false;
        initialTimeScale = timeScale;
        myText = GetComponent<Text>();
        timeInSecondsToShow = initialTime;
        UpdateTimer(initialTime);
        bandera = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(!stopTimer){
            if(timeInSecondsToShow > 0f)
            {
                frameTimeScale = Time.deltaTime * timeScale;
                timeInSecondsToShow -= frameTimeScale;
                UpdateTimer(timeInSecondsToShow);
            }
            else
            {       
                // colocar sonido de perdida
                if(bandera){
                    mainCamara = GameObject.FindGameObjectsWithTag("MainCamera");
                    sounds =  mainCamara[0].GetComponents<AudioSource>();

                    foreach(AudioSource sound in sounds){
                        sound.Play();
                    }
                    this.bandera = false;
                }
                

                PlayerMovement.stopPlayer = true;
                PlayerMovement.isLose = true;
                myText.text = "";
                lostGameUI.SetActive(true);

                
            }
        }
    }

    public void UpdateTimer(float timeInSeconds)
    {
        int minutes = 0;
        int seconds = 0;
        string timerText;

        if (timeInSeconds < 0) timeInSeconds = 0;

        minutes = (int)timeInSeconds / 60;
        seconds = (int)timeInSeconds % 60;

        timerText = minutes.ToString("00") + ":" + seconds.ToString("00");
        myText.text = timerText;
    }
}
