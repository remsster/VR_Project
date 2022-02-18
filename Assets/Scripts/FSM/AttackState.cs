using UnityEngine;

public class AttackState : MonoBehaviour, IFSMState
{
    public FSMStateType StateName { get => FSMStateType.Attack; }
    public ParticleSystem WeaponPS;
    private Transform ThisPlayer;

    public void OnEnter()
    {
        WeaponPS.Play();
    }

    public void OnExit()
    {
        WeaponPS.Stop();
    }

    public void DoAction()
    {
        Vector3 Direction = (ThisPlayer.position - transform.position).normalized;
        Direction.y = 0;
        transform.rotation = Quaternion.LookRotation(Direction, Vector3.up);
    }

    public FSMStateType ShouldTransitionToState()
    {
        return FSMStateType.Attack;
    }

}
