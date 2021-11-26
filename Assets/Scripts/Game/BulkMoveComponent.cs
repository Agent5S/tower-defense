using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class BulkMoveComponent : MonoBehaviour
{
    public List<Transform> towers;
    public List<NavMeshAgent> agents = new List<NavMeshAgent>();

    public List<Transform> array { get => towers; }

    //FIXME: This shouldn't be here
    private void Awake()
    {
        GameOver.blueTowers = 3;
        GameOver.yellowTowers = 3;
    }

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

    public void RemoveTower(Transform tower)
    {
        this.towers.Remove(tower);
        if (towers.Count == 0)
        {
            SceneManager.LoadSceneAsync(2);
        }
    }

    //FIXME: I just threw these two methods in before going to sleep
    public void DecreaseBlue()
    {
        GameOver.blueTowers--;
    }

    public void DecreaseYellow()
    {
        GameOver.yellowTowers--;
    }
}
