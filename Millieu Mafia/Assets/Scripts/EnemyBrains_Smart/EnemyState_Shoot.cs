using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState_Shoot : MonoBehaviour
{
    private EnemyReference enemyReference;
    private Transform target;

    public EnemyState_Shoot(EnemyReference enemyReference)
    {
        this.enemyReference = enemyReference;
    }

    public void OnEnter()
    {
        Debug.Log("Start Shooting");
        target = GameObject.FindWithTag("Player").transform;
    }

    public void OnExit()
    {
        Debug.Log("Stop Shooting");
        enemyReference.animator.SetBool("Shooting", false);
        target = null;
    }

    public void Tick()
    {
        if (target != null)
        {
            Vector3 lookPos = target.position - enemyReference.transform.position;
            lookPos.y = 0;
            Quaternion rotation = Quaternion.LookRotation(lookPos);
            enemyReference.transform.rotation = Quaternion.Slerp(enemyReference.transform.rotation, rotation, 0.2f);

            enemyReference.animator.SetBool("Shooting", true);
        }
    }
}
