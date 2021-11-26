using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackComponent : MonoBehaviour
{
    public float radius;
    public float hitStrength;
    public WaitForSeconds hitDelay;
    public LayerMask layerMask;

    private Collider[] result = new Collider[1];
    private MoveComponent moveComp;

    private void Awake()
    {
        this.moveComp = GetComponent<MoveComponent>();
    }

    private void Update()
    {
        StartCoroutine(Attack());
    }

    private IEnumerator Attack()
    {
        var count = Physics.OverlapSphereNonAlloc(
            transform.position,
            radius,
            result,
            layerMask
        );

        if (count > 0)
        {
            //Stop movement while hit is is progress
            this.moveComp.enabled = false;
            yield return hitDelay;

            var damageComp = result[0].GetComponent<ReceiveDamageComponent>();
            //TODO: Perform hit
            this.moveComp.enabled = true;
        }
    }
}
