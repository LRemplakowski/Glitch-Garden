using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (Attacker))]
public class Lizard : MonoBehaviour {

    private Attacker attacker;

    private void Start()
    {
        attacker = gameObject.GetComponent<Attacker>();
    }

    private void OnTriggerEnter2D (Collider2D collision)
    {
        //Debug.Log(collision);
        if (collision.gameObject.GetComponent<Defender>())
        {
           // Debug.Log("Collision " + collision.gameObject);
            attacker.Attack(collision.gameObject);
        }
    }
}
