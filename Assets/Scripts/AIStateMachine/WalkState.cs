using UnityEngine;
using UnityEngine.AI;

public class WalkState : StateMachineBehaviour
{
    
    NavMeshAgent _navAgent;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (_navAgent == null)
        {
            _navAgent = animator.GetComponent<NavMeshAgent>();
        }
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (RunState.ShouldChasePlayer(animator.transform.position,SomeTarget.GetInstance().transform))
        {
            animator.SetInteger(IdleState.transitionParameter, (int)ETransition.CHASE);
        }
        else if (!_navAgent.hasPath)
        {
            animator.SetInteger(IdleState.transitionParameter, (int)ETransition.IDLE);
        }
    }
    
}
