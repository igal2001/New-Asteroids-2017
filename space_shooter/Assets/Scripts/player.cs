using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {

    public float moveSpeed;
    public float rotateSpeed;

    [HideInInspector]
    public GameObject canvas;

    public GameObject sm;
    private playerScore PlayerScore;

    SpriteRenderer disablespriteRenderer;
    BoxCollider2D disableboxCollider;
    Shooting disableShooting;
    public ParticleSystem[] PlayerPS;
    
    //Renderer hideRenderer;

    public float camShakeAmt = 0.5f;
    public float camShakelng = 0.2f;

    public int hp = 3;

    public Camera mainCamera;
    public CameraShake cameraShake;

    public GameObject am;
    private Audio_Manager audioManager;

    [Header("The explosion prefab")]
    public GameObject explosion;
    [HideInInspector]
    public Rigidbody2D rb;
	// Use this for initialization
	void Start () {
        PlayerScore = sm.GetComponent<playerScore>();
        rb = GetComponent<Rigidbody2D>();
        disablespriteRenderer = GetComponent<SpriteRenderer>();
        disableboxCollider = GetComponent<BoxCollider2D>();
        disableShooting = GetComponent<Shooting>();
        audioManager = am.GetComponent<Audio_Manager>();

        mainCamera = Camera.main;
        cameraShake = mainCamera.GetComponent<CameraShake>();
    }

    private void Update()
    {
        if (hp <= 0)
        {
            GameOver();
        }
    }

    public void respawn ()
    {
        cameraShake.Shake(camShakeAmt, camShakelng);
        explosion = Instantiate(explosion, transform.position, transform.rotation);
        audioManager.Play("Respawn");
        disablespriteRenderer.enabled = false;
        disableboxCollider.enabled = false;
        disableShooting.enabled = false;

        foreach (ParticleSystem s in PlayerPS)
        {
            s.Stop();
        }

        StartCoroutine(finishRespawn());
    }

    IEnumerator finishRespawn()
    {
        yield return new WaitForSeconds(1f);

        disablespriteRenderer.enabled = true;
        disableboxCollider.enabled = true;
        disableShooting.enabled = true;
        Vector2 tempVec = new Vector2(0, 0);
        transform.position = tempVec;
        rb.velocity = new Vector2(0, 0);
        foreach (ParticleSystem s in PlayerPS)
        {
            s.Play();
        }
        disableboxCollider.enabled = false;
        this.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.2f);
        StartCoroutine(spawnProtection());
    }

    IEnumerator spawnProtection ()
    {
        yield return new WaitForSeconds(3f);
        disableboxCollider.enabled = true;
        this.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
    }

    private void GameOver()
    {
        FindObjectOfType<Audio_Manager>().Play("Death");
        Destroy(this.gameObject);
        if (PlayerPrefs.GetInt("HighScore") < PlayerScore.currentScore)
        {
            PlayerPrefs.SetInt("HighScore", PlayerScore.currentScore);
        }
        canvas.SetActive(true);
    }

    // Update is called once per frame
    void FixedUpdate () {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.AddRelativeForce(Vector2.up * Time.deltaTime * moveSpeed);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.AddRelativeForce(Vector2.down * Time.deltaTime * moveSpeed);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {

            rb.AddTorque(Time.deltaTime * rotateSpeed);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddTorque(-Time.deltaTime * rotateSpeed);
        }
    }
}
