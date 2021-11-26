using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BulkMoveComponent : MonoBehaviour
{
    public List<Transform> towers;
    public List<NavMeshAgent> agents = new List<NavMeshAgent>();

    // Update is called once per frame
    void Update()
    {
        agents.ForEach((agent) =>
        {
            var currentPosition = agent.transform.position;
            var prevDistance = float.PositiveInfinity;
            var target = agent.transform.position;
            towers.ForEach((tower) =>
            {
                var distance = (tower.position - currentPosition).sqrMagnitude;
                target = distance < prevDistance ? tower.position : target;
                prevDistance = Mathf.Min(distance, prevDistance);
            });

            agent.SetDestination(target);
        });
        agents.Clear();
    }
}
