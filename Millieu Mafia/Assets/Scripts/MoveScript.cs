using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
    public float moveDistance = 2f; // Adjust this value to set the distance the spawner moves
    public float moveSpeed = 2f;    // Adjust this value to set the speed of the movement

    private bool moveRight = true;
    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        // Move the spawner left and right
        if (moveRight)
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }
        
        // Change direction when reaching the move distance
        if (Mathf.Abs(transform.position.x - initialPosition.x) >= moveDistance)
        {
            moveRight = !moveRight;
        }
    }
}
