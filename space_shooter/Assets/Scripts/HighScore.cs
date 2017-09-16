using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HighScore : MonoBehaviour {

    public Text Highscore;
    private void Start()
    {
        Highscore.text = "Highscore : " + PlayerPrefs.GetInt("HighScore");
    }

}
