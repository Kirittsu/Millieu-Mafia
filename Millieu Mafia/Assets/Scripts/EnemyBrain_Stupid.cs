using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBrain_Stupid : MonoBehaviour
{
    private GameObject player;  // Het GameObject van de speler
    private EnemyReference enemyReference;
    private float shootingDistance;
    private float pathUpdateDeadline;

    public float GetShootingDistance()
    {
        return shootingDistance;
    }

    private void Awake()
    {
        enemyReference = GetComponent<EnemyReference>();
    }

    private void Start()
    {
        shootingDistance = enemyReference.navMeshAgent.stoppingDistance;
        // Zoek het GameObject met de tag "Player" bij de start
        player = GameObject.FindGameObjectWithTag("Player");
        if (player == null)
        {
            Debug.LogError("Player GameObject not found! Make sure the player has the 'Player' tag.");
        }
    }

    private void Update()
    {
        if (player != null)
        {
            bool inRange = Vector3.Distance(transform.position, player.transform.position) <= shootingDistance;

            if (inRange)
            {
                LookTarget();
            }
            else
            {
                UpdatePath();
            }

            enemyReference.animator.SetBool("Shooting", inRange);
        }

        enemyReference.animator.SetFloat("Speed", enemyReference.navMeshAgent.desiredVelocity.sqrMagnitude);
    }

    private void UpdatePath()
    {
        if (Time.time >= pathUpdateDeadline)
        {
            pathUpdateDeadline = Time.time + enemyReference.pathUpdateDelay;
            if (player != null)
            {
                enemyReference.navMeshAgent.SetDestination(player.transform.position);
            }
        }
    }

    private void LookTarget()
    {
        if (player != null)
        {
            Vector3 lookPos = player.transform.position - transform.position;
            lookPos.y = 0;
            Quaternion rotation = Quaternion.LookRotation(lookPos);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 0.2f);
        }
    }
}
