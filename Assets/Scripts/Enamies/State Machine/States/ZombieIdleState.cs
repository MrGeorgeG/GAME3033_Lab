using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieIdleState : ZombieStates
{
    private static readonly int MovementZ = Animator.StringToHash("MovementZ");

    public ZombieIdleState(ZombieComponent zombie, StateMachine stateMachine) : base(zombie, stateMachine)
    {

    }
    public override void Start()
    {
        base.Start();
        OwerZombeie.ZombieNavMesh.isStopped = true;
        OwerZombeie.ZombieNavMesh.ResetPath();
        OwerZombeie.ZombieAnimator.SetFloat("MovementZ", 0.0f);

    }
}
