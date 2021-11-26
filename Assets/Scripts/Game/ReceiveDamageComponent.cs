using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceiveDamageComponent : MonoBehaviour
{
    public float health;

    public void ReceiveDamage(float amount)
    {
        this.health -= amount;
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
