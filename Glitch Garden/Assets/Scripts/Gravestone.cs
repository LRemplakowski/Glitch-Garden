using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravestone : MonoBehaviour {

    private Animator graveStoneAnimator;

    private void Start()
    {
        graveStoneAnimator = GetComponent<Animator>();
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        Attacker attacker = collider.gameObject.GetComponent<Attacker>();
        if (attacker)
        {
            graveStoneAnimator.SetTrigger("underAttack");
        }
    }
}
