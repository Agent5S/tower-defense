using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject prefab;
    public BulkMoveComponent teamB;

    private Vector3 offset;
    private Vector3 dimensions;

    private void Awake()
    {
        var collider = GetComponent<Collider>();
        this.offset = collider.bounds.min;
        this.dimensions = collider.bounds.size;
        Debug.Log(offset);
        Debug.Log(dimensions);
    }

    private void Start()
    {
        InvokeRepeating("Spawn", 1, 10);
    }

    void Spawn()
    {
        var pos = new Vector3(
            Random.value * dimensions.x,
            dimensions.y,
            Random.value * dimensions.z
        );
        pos += offset;

        var character = Instantiate(prefab);
        character.transform.position = pos;
        character.transform.parent = teamB.transform;
        var moveComp = character.GetComponent<MoveComponent>();
        moveComp.defaultMove = teamB;
    }
}
