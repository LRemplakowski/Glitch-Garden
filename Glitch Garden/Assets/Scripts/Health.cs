using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    public float health = 100;

    public void DealDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            BeGone();
        }
    }

    public void BeGone()
    {
        Destroy(gameObject);
    }
}
