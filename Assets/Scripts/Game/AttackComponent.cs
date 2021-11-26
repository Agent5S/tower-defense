using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackComponent : MonoBehaviour
{
    public float radius;
    public float hitStrength;
    public float hitDelay;
    public LayerMask layerMask;

    private Collider[] result = new Collider[1];
    private MoveComponent moveComp;
    private WaitForSeconds waitForDelay;
    private Coroutine coroutine;

    private void Awake()
    {
        this.moveComp = GetComponent<MoveComponent>();
        this.waitForDelay = new WaitForSeconds(hitDelay);
    }

    private void Update()
    {
        this.coroutine = StartCoroutine(Attack());
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
            var damageComp = result[0].GetComponent<ReceiveDamageComponent>();
            if (damageComp)
            {
                //Stop movement while hit is is progress
                this.moveComp.enabled = false;
                this.enabled = false;
                damageComp.ReceiveDamage(hitStrength);

                yield return waitForDelay;
                this.moveComp.enabled = true;
                this.enabled = true;
            }
        }
    }

}
