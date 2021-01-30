using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameWin : MonoBehaviour
{
    public void mainMenu() {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

}
