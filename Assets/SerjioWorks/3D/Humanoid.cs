using UnityEngine;
using UnityEngine.AI;

[DisallowMultipleComponent]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(NavMeshAgent))]
public class Humanoid : MonoBehaviour
{
    public Transform t1;
    public Transform t2;
    public float walkSpeed;
    public float runSpeed;
    public float MinDist;

    public void Start()
    {
        StartCoroutine(Coro());
    }

    private System.Collections.IEnumerator Coro()
    {
        var animator = GetComponent<Animator>();
        var agent = GetComponent<NavMeshAgent>();
        agent.speed = walkSpeed;
        animator.SetTrigger("walk");
        agent.SetDestination(t1.position);
        bool goToFirst = true;
        while (true)
        {
            if (goToFirst)
            {
                if (Vector3.Distance(transform.position, t1.transform.position) < MinDist)
                {
                    animator.SetTrigger("idle");
                    agent.speed = 0;
                    yield return new WaitForSeconds(5);
                    animator.SetTrigger("walk");
                    agent.speed = walkSpeed;
                    agent.SetDestination(t2.position);
                    goToFirst = false;
                }
            }
            else
            {
                if (Vector3.Distance(transform.position, t2.transform.position) < MinDist)
                {
                    animator.SetTrigger("idle");
                    agent.speed = 0;
                    yield return new WaitForSeconds(5);
                    animator.SetTrigger("run");
                    agent.speed = runSpeed;
                    agent.SetDestination(t1.position);
                    goToFirst = true;
                }
            }
            yield return null;
        }
    }

    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, MinDist);
    }
}