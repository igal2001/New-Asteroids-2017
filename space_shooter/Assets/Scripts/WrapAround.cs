using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrapAround : MonoBehaviour {

    private float leftConstraint = 0.0f;
    private float rightConstraint = 0.0f;
    private float upConstraint = 0.0f;
    private float downConstraint = 0.0f;
    private float buffer = .91f;

	void Awake () {
        leftConstraint = Camera.main.ScreenToWorldPoint(new Vector2(0.0f, 0.0f)).x;
        rightConstraint = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0.0f)).x;
        upConstraint = Camera.main.ScreenToWorldPoint(new Vector2(0.0f, 0.0f)).y;
        downConstraint = Camera.main.ScreenToWorldPoint(new Vector2(0.0f, Screen.height)).y;
    }
	
	// Update is called once per frame
	void Update () {
        Vector2 temp = transform.position;
		if(this.transform.position.x <leftConstraint - buffer)
        {
            transform.position = new Vector2(rightConstraint + buffer, temp.y);
        }
        
        if (this.transform.position.x > rightConstraint + buffer)
        {
            transform.position = new Vector2(leftConstraint - buffer, temp.y);
        }

        if (this.transform.position.y < upConstraint - buffer)
        {
            transform.position = new Vector2(temp.x, downConstraint + buffer);
        }

        if (this.transform.position.y > downConstraint + buffer)
        {
            transform.position = new Vector2(temp.x, upConstraint - buffer);
        }
    }
}
