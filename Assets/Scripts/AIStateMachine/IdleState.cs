using UnityEngine;
using UnityEngine.AI;

public enum ETransition
{
   IDLE, //0
   WANDER, //1
   CHASE //2
}

public class IdleState : StateMachineBehaviour 
{
    public const string transitionParameter = "State";
    
    NavMeshAgent _navAgent;

    [SerializeField] float minWalkDistance = 5;
    [SerializeField] float maxWalkDistance = 15;
    [SerializeField] float walkSpeed = 1;
    
    
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.LogError("Entered in Idle State");

        if (_navAgent == null)
        {
            _navAgent = animator.GetComponent<NavMeshAgent>();
        }
        
        _navAgent.ResetPath();
        _navAgent.speed = walkSpeed;
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (RunState.ShouldChasePlayer(animator.transform.position, SomeTarget.GetInstance().transform))
        {
            animator.SetInteger(transitionParameter, (int)ETransition.CHASE);
        }
        else
        {
            if (_navAgent.hasPath)
            {
               animator.SetInteger(transitionParameter, (int)ETransition.WANDER); 
            }
            else
            {
                SetRandomDestination(_navAgent);
            }
        }
    }

    public void SetRandomDestination(NavMeshAgent navAgent)
    {
        float radius = Random.Range(minWalkDistance, maxWalkDistance);
        Vector3 randomPosition = Random.insideUnitSphere * radius;
        randomPosition += navAgent.transform.position;
        NavMeshHit hit;

        if (NavMesh.SamplePosition(randomPosition, out hit, radius, 1))
        {
            navAgent.SetDestination(hit.position);
        }
    }
}
