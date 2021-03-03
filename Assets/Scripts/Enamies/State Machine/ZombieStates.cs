public class ZombieStates : State
{
    protected ZombieComponent OwerZombeie;
    public ZombieStates(ZombieComponent zombie, StateMachine stateMachine) : base(stateMachine)
    {
        OwerZombeie = zombie;
    }
}

public enum ZombieStateType
{
    Idle,
    Attack,
    Follow,
    Dead
}