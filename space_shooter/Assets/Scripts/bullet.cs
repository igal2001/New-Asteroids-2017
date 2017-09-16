using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {

    public float moveSpeed;
    private Rigidbody2D rb;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
        rb.transform.Translate(Vector2.up * Time.deltaTime * moveSpeed );
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }


}
