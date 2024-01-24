using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    public GameObject projectile;

    float timer = 10f;
    bool start = false;
    public float shootRate = 3f;
    public float offset = 1.0f;
    public float power;

    // Update is called once per frame
    void Update()
    {
        float shoot = Input.GetAxis("Fire1");

        if (shoot == 1 && timer >= shootRate)
        {
            GameObject newProjectile = Instantiate(projectile, transform.position + transform.forward * offset, transform.rotation);
            newProjectile.GetComponent<Rigidbody>().AddForce(transform.forward * power, ForceMode.VelocityChange);
            start = true;
            timer = 0;
        }

        if (start)
        {
            if (timer < shootRate)
            {
                timer += Time.deltaTime;
            }
            else
            {
                timer = shootRate;
                start = false;
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Hier wordt gecontroleerd of het geraakte object een "enemy" is
        if (collision.gameObject.CompareTag("enemy"))
        {
            Destroy(collision.gameObject); // Vernietig het object dat is geraakt
        }
    }
}
