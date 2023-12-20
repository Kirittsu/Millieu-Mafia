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



    IEnumerator cooldown_timer()
    {
        yield return new WaitForSeconds(firing_speed);
        cooldown = false;
    }

    void FireBullet()
    {
        GameObject bullet_clone = Instantiate(bullet, transform.position, Quaternion.identity);
        bullet_clone.SetActive(true);
        Rigidbody rb = bullet_clone.GetComponent<Rigidbody>();
        rb.AddForce(player.transform.forward * bullet_speed);
        max_bullet -= 1;
        cooldown = true;
        StartCoroutine(cooldown_timer());
    }

    void Reload()
    {
        max_bullet = 10;
    }
}
