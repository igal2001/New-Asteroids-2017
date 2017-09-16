using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour {

    public Text[] score_text;
    public Text Highscore;
    [SerializeField]
    private GameObject sm;

    private playerScore curScore;

    void Update ()
    {

        curScore = sm.GetComponent<playerScore>();
        
        int CurscoreText = curScore.currentScore;

        foreach (Text s in score_text)
        {
            s.text = "Score:" + CurscoreText;
        }

        Highscore.text = "Highscore : " + PlayerPrefs.GetInt("HighScore");
    }
}
