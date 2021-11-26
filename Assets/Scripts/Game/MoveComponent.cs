using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveComponent : MonoBehaviour
{
    public float radius;
    public LayerMask layerMask;
    public BulkMoveComponent defaultMove;

    private Collider[] result = new Collider[1];
    private NavMeshAgent agent;

    private void Awake()
    {
        this.agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        var count = Physics.OverlapSphereNonAlloc(
            transform.position,
            radius,
            result,
            layerMask
        );

        if (count > 0)
        {
            this.agent.SetDestination(result[0].transform.position);
            return;
        }

        defaultMove.agents.Add(agent);
    }
}
