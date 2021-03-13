using System.Collections;
using System.Collections.Generic;
using Systems.Health_System;
using UnityEngine;

[RequireComponent(typeof(ZombieComponent))]
public class ZombieHealthComponent : HealthComponent
{
    private StateMachine ZombeieStateMachine;
    // Start is called before the first frame update
    void Awake()
    {
        ZombeieStateMachine = GetComponent<StateMachine>();
    }

    public override void Destroy()
    {
        ZombeieStateMachine.ChanceState(ZombieStateType.Dead);
    }
}
