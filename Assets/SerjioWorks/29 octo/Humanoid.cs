using UnityEngine;
using UnityEngine.AI;

[DisallowMultipleComponent]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(NavMeshAgent))]
public class Humanoid : MonoBehaviour
{
    NavMeshAgent agent;
    Animator animator;
    public Transform t1;
    public Transform t2;
    public float speed;
    public float MinDist;

    public void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
        agent.SetDestination(t1.position);
    }

    public void Update()
    {
        if (Vector3.Distance(transform.position, t1.transform.position) < MinDist)
            agent.SetDestination(t2.position);
        else if (Vector3.Distance(transform.position, t2.transform.position) < MinDist)
            agent.SetDestination(t1.position);
    }
}