using UnityEngine;
using UnityEngine.AI;

public class ChaseState : MonoBehaviour, IFSMState
{
    public FSMStateType StateName { get => FSMStateType.Chase; }
    public float MinChaseDistance = 2.0f;
    private Transform Player;
    private NavMeshAgent ThisAgent;

    private void Awake()
    {
        Player = GameObject.FindWithTag("Player").GetComponent<Transform>();
        ThisAgent = GetComponent<NavMeshAgent>();
    }

    public void OnEnter()
    {
        ThisAgent.isStopped = false;
    }

    public void OnExit()
    {
        ThisAgent.isStopped = true;
    }

    public void DoAction()
    {
        ThisAgent.SetDestination(Player.position);
    }

    public FSMStateType ShouldTransitionToState()
    {
        float DistanceDest = Vector3.Distance(transform.position, Player.position);

        if (DistanceDest <= MinChaseDistance) { return FSMStateType.Attack; }
        return FSMStateType.Chase;
    }
}
