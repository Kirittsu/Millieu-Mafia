using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Camera cam;


    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            cam.fieldOfView = 40;
        }
        else
        {
            cam.fieldOfView = 60;
        }
    }
}
