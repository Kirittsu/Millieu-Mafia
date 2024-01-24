using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState_Reload : MonoBehaviour
{
    private EnemyReference enemyReference;

    public EnemyState_Reload(EnemyReference enemyReference)
    {
        this.enemyReference = enemyReference;
    }

    public void OnEnter()
    {
        Debug.Log("Start Reload");
        enemyReference.animator.SetTrigger("Reload");
    }

    public void OnExit()
    {
        Debug.Log("Stop Reload");
    }
}
