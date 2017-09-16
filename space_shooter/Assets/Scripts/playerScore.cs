using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScore : MonoBehaviour {

    public int currentScore = 0;

	public void AddScore ()
    {
        currentScore += 100;

    }
}
