using UnityEngine;

public class Shooting : MonoBehaviour {

    public GameObject bullet;
    private float distance = 1.5f;
    public float fireRate = 0.25f;
    private float next = 0f;
	
	// Update is called once per frame
	void Update () {

        if (next >0)
        {
            next = next - Time.deltaTime;
        } else if (Input.GetKey(KeyCode.Space))
        {
            next = next + fireRate;
            Instantiate(bullet, transform.position + (transform.up * distance), transform.rotation);
            FindObjectOfType<Audio_Manager>().Play("Shoot");
        }
    }
}
