using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Attacker))]
public class Fox : MonoBehaviour {

    private Attacker attacker;

	// Use this for initialization
	void Start () {
        attacker = gameObject.GetComponent<Attacker>();
	}
	
    private void OnTriggerEnter2D (Collider2D collision)
    {
        //Debug.Log("Fox collision");
        if (collision.gameObject.GetComponent<Defender>())
        {
            //Debug.Log("Fox + " + collision);
            if (collision.gameObject.GetComponent<Gravestone>())
            {
                attacker.Jump();
            }
            else attacker.Attack(collision.gameObject);
        }
    }
}
