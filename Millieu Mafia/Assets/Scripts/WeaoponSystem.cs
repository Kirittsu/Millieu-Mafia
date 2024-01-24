using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaoponSystem : MonoBehaviour
{
    public GameObject bullet;
    public GameObject player;
    public float bullet_speed;
    public float firing_speed;
    public float max_bullet;
    bool cooldown = false;

    public float ClipLength = 1f;
    public GameObject AudioClip;

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButton(0) && max_bullet > 0 && !cooldown)
        {
            FireBullet();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }
    }

    private void Start()
    {
        AudioClip.SetActive(false);
    }


    IEnumerator cooldown_timer()
    {

        {
            AudioClip.SetActive(true);
            yield return new WaitForSeconds(ClipLength);
            AudioClip.SetActive(false);
        }
        yield return new WaitForSeconds(firing_speed);
        cooldown = false;
        
    }

    void FireBullet()
    {

        
        GameObject bullet_clone = Instantiate(bullet, transform.position, Quaternion.identity);
        bullet_clone.SetActive(true);

        // Get the center of the screen in screen coordinates
        Vector3 screenCenter = new Vector3(Screen.width / 2, Screen.height / 2, 0);

        // Convert the screen center to a ray in world space
        Ray ray = Camera.main.ScreenPointToRay(screenCenter);

        // Get the forward direction from the pistol to the hit point
        Vector3 pistolToHitPoint = (ray.origin - transform.position).normalized;

        // Ignore the up and down rotation of the camera
        pistolToHitPoint.y = 0;

        // Set the bullet's rotation based on the calculated direction
        bullet_clone.transform.rotation = Quaternion.LookRotation(pistolToHitPoint);

        Rigidbody rb = bullet_clone.GetComponent<Rigidbody>();

        // Set collision detection mode to Continuous
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous;

        // Adjust the initial force to be forward relative to the player's orientation
        rb.AddForce(transform.forward * bullet_speed);

        max_bullet -= 1;
        cooldown = true;
        StartCoroutine(cooldown_timer());
    }

    void Reload()
    {
        max_bullet = 10;
    }

   
        
    
    
    
}
