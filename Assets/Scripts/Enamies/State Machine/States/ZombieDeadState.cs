using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieDeadState : ZombieStates
{
    private static readonly int MovementZHash = Animator.StringToHash("MovementZ");
    private static readonly int IsDeadHash = Animator.StringToHash("IsDead");
    public ZombieDeadState(ZombieComponent zombie, StateMachine stateMachine) : base(zombie, stateMachine)
    {
        
    }

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        OwerZombeie.ZombieNavMesh.isStopped = true;
        OwerZombeie.ZombieNavMesh.ResetPath();

        OwerZombeie.ZombieAnimator.SetFloat(MovementZHash, 0);
        OwerZombeie.ZombieAnimator.SetBool(IsDeadHash, true);
    }

    public override void Exit()
    {
        base.Exit();
        OwerZombeie.ZombieNavMesh.isStopped = false;
        OwerZombeie.ZombieAnimator.SetBool(IsDeadHash, false);
    }
}
