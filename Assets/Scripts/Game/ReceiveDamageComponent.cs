using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ReceiveDamageComponent : MonoBehaviour
{
    public float health;
    public UnityEvent willDestroy;

    public void ReceiveDamage(float amount)
    {
        this.health -= amount;
        if (health <= 0)
        {
            willDestroy.Invoke();
            Destroy(this.gameObject);
        }
    }
}
