using System.Collections;
using System.Collections.Generic;
using Systems.Health_System;
using UnityEngine;

public class ZombieAttackState : ZombieStates
{
    private GameObject FollowTarget;
    private IDamagable DamagableObject;

    private float AttackRange = 1.5f;

    private static readonly int MovementZHash = Animator.StringToHash("MavementZ");
    private static readonly int IsAttackingHash = Animator.StringToHash("IsAttacking");

    public ZombieAttackState(GameObject followTarget, ZombieComponent zombie, StateMachine stateMachine) : base(zombie, stateMachine)
    {
        FollowTarget = followTarget;
        UpdateInterval = 2.0f;
    }

    // Start is called before the first frame update
    public override void Start()
    {
        OwerZombeie.ZombieNavMesh.isStopped = true;
        OwerZombeie.ZombieNavMesh.ResetPath();
        OwerZombeie.ZombieAnimator.SetFloat(MovementZHash, 0.0f);
        OwerZombeie.ZombieAnimator.SetBool(IsAttackingHash, true);

        DamagableObject = FollowTarget.GetComponent<IDamagable>();
    }

    public override void IntervalUpate()
    {
        base.IntervalUpate();

        DamagableObject?.TakeDamage(OwerZombeie.ZombieDamage);
    }

    // Update is called once per frame
    public override void Update()
    {
        OwerZombeie.transform.LookAt(FollowTarget.transform.position, Vector3.up);

        float distanceBetween = Vector3.Distance(OwerZombeie.transform.position, FollowTarget.transform.position);
        if (distanceBetween > AttackRange)
        {
            StateMachine.ChanceState(ZombieStateType.Follow);
        }

        //TODO: Zombie Health < 0 Die.
    }

    public override void Exit()
    {
        base.Exit();
        OwerZombeie.ZombieAnimator.SetBool(IsAttackingHash, false);
    }
}
