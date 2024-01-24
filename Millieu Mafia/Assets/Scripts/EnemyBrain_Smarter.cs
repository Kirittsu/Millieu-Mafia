using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyBrain_Smarter : MonoBehaviour
{
    private EnemyReference enemyReference;
    private StateMachine stateMachine;

    void Start()
    {
        enemyReference = GetComponent<EnemyReference>();
        stateMachine = new StateMachine();



        //void At(IState from, IState to, Func<bool> condition) => stateMachine.AddTransition(from, to, condition);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
