using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lifetime : MonoBehaviour
{
    float timer = 0;
    public float lifeTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < lifeTime)
        {
            timer += Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
