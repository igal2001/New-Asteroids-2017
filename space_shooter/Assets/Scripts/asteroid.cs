using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroid : MonoBehaviour
{
    [HideInInspector]
    public GameObject curPlayer;
    public float speed = 100f;
    public GameObject nextAsteroid;
    [HideInInspector]
    private Rigidbody2D rb;
    public playerScore score;

    public float camShakeAmt = 0.1f;
    public float camShakelng = 0.2f;
    [HideInInspector]
    public Camera mainCamera;
    [HideInInspector]
    public CameraShake cameraShake;

    public ParticleSystem particle;

    //Score Manager
    public GameObject sm;
    private playerScore scoreManager;

    //Audio Manager
    [HideInInspector]
    public GameObject am;
    private Audio_Manager audioManager;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        curPlayer = GameObject.FindWithTag("Player");

        am = GameObject.FindGameObjectWithTag("AudioManager"); 

        audioManager = am.GetComponent<Audio_Manager>();


        if(nextAsteroid == null)
        {
            return;
        }

        if (curPlayer == null)
        {
            return;
        }

        sm = GameObject.FindGameObjectWithTag("ScoreManager");

        scoreManager = sm.GetComponent<playerScore>();

        mainCamera = Camera.main;
        cameraShake = mainCamera.GetComponent<CameraShake>();

        rb.velocity = transform.right * speed * Time.deltaTime ;
        rb.AddTorque(Random.Range(-5f, 5f));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            player playerHolder = collision.gameObject.GetComponent<player>();
            playerHolder.hp -= 1;
            print(playerHolder.hp);

            float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
            Instantiate(nextAsteroid, transform.position, Quaternion.Euler(0, 0, angle - 60));
            Instantiate(nextAsteroid, transform.position, Quaternion.Euler(0, 0, angle + 60));
            Destroy(gameObject);
            playerHolder.respawn();
        }
    }


    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("bullet"))
        {
            Destroy(other);
            scoreManager.AddScore();
            print(scoreManager.currentScore);
            audioManager.Play("Destroy");
        }
    }

    void Destroy(Collider2D other)
    {
            Instantiate(particle, transform.position + new Vector3 (0,0, -10), transform.rotation);
            particle.Play();
            float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
            cameraShake.Shake(camShakeAmt,camShakelng);
            Instantiate(nextAsteroid, transform.position, Quaternion.Euler(0, 0, angle - 60));
            Instantiate(nextAsteroid, transform.position, Quaternion.Euler(0, 0, angle + 60));
            
            Destroy(gameObject);
            Destroy(other.gameObject);
    }


}
