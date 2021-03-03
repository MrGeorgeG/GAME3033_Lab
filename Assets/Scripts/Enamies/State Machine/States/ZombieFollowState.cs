using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieFollowState : ZombieStates
{
    private readonly GameObject FollowTarget;
    private static readonly int MovementZHash = Animator.StringToHash("MovementZ");
    private const float stopDistance = 1.5f;
    public ZombieFollowState(GameObject followTarget, ZombieComponent zombie, StateMachine stateMachine) : base(zombie, stateMachine)
    {
        FollowTarget = followTarget;
        UpdateInterval = 2.0f;

    }
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        OwerZombeie.ZombieNavMesh.SetDestination(FollowTarget.transform.position);
    }

    public override void IntervalUpate()
    {
        base.IntervalUpate();
        OwerZombeie.ZombieNavMesh.SetDestination(FollowTarget.transform.position);
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();

        OwerZombeie.ZombieAnimator.SetFloat(MovementZHash, OwerZombeie.ZombieNavMesh.velocity.normalized.z);

        float dsitanceBetween = Vector3.Distance(OwerZombeie.transform.position, FollowTarget.transform.position);
        if(dsitanceBetween < stopDistance)
        {
            StateMachine.ChanceState(ZombieStateType.Attack);
        }
        //TODO: Zombie Health < 0 Die.
        
    }

   
}
