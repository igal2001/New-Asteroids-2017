using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonManager : MonoBehaviour {


    //Restart the scene
    public void PlayAndRestart ()
    {
        SceneManager.LoadScene("space_shotter");
    }

    // Quits back to the mainmenu
    public void QuitToMenu ()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
