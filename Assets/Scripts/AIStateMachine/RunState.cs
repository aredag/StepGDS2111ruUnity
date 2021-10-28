using UnityEngine;
using UnityEngine.AI;

public class RunState : StateMachineBehaviour
{
    [SerializeField] float _repathTolerance = 2;
    [SerializeField] float _repathCount = 10;
    [SerializeField] float _runSpeed= 4;

    NavMeshAgent _navAgent;
    static float ChaseRadius = 10;
    
    
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (_navAgent == null)
        {
            _navAgent = animator.GetComponent<NavMeshAgent>();
        }

        if (SomeTarget.GetInstance().transform == null)
        {
           Debug.LogError("Target is null!"); 
        }
        
        _navAgent.ResetPath();
        _navAgent.speed = _runSpeed;
    }

    public override void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!ShouldChasePlayer(animator.transform.position, SomeTarget.GetInstance().transform))
        {
           animator.SetInteger(IdleState.transitionParameter, (int)ETransition.IDLE); 
        }
        else
        {
            if (!_navAgent.hasPath ||
                (SomeTarget.GetInstance().transform.position - _navAgent.pathEndPosition).sqrMagnitude >
                _repathTolerance * _repathTolerance)
            {
               SetDestinationNearTarget(_navAgent, SomeTarget.GetInstance().transform); 
            }
        }
    }

    public void SetDestinationNearTarget(NavMeshAgent navAgent, Transform target)
    {
        NavMeshHit hit;

        float radius = 0;

        for (int i = 0; i < _repathCount; ++i)
        {
            Vector3 randomPosition = Random.insideUnitSphere * radius;
            randomPosition += target.position;
            if (NavMesh.SamplePosition(randomPosition, out hit, radius, 1))
            {
                navAgent.SetDestination(hit.position);
                break;
            }
            else
            {
                ++radius;
            }
        }
    }

    public static bool ShouldChasePlayer(Vector3 npcPos, Transform target)
    {
        return (target.position - npcPos).sqrMagnitude < ChaseRadius * ChaseRadius;
    }
}
