using UnityEngine;
using UnityEngine.AI;

public class WanderTarget : MonoBehaviour
{
    public float wanderRadius = 8f;
    public float wanderInterval = 3f;
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        InvokeRepeating(nameof(SetRandomDestination), 0f, wanderInterval);
    }

    void SetRandomDestination()
    {
        Vector3 randomPos = new Vector3(Random.Range(-wanderRadius, wanderRadius), 1, Random.Range(-wanderRadius, wanderRadius));
        agent.SetDestination(randomPos);
    }
}
