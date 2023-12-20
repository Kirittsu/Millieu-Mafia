using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemySystem : MonoBehaviour
{
    bool lookat = false;
    public GameObject player;
    Rigidbody rb;
    public float speed = 10;
    public float multiplier = 10;
    public float speed_limit = 2;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerDetection.found)
        {
            lookat = true;
        }
        if (lookat)
        {
            transform.LookAt(player.transform);
            Vector3 vel = rb.velocity;
            if (!PlayerDetection.found && vel.x > speed_limit * -1 && vel.x < speed_limit && vel.z > speed_limit*-1 && vel.z < speed_limit)
            {
                rb.AddForce(speed * multiplier * Time.deltaTime * transform.forward);
                
            }
        }
    }
}
