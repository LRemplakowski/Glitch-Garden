using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Attacker : MonoBehaviour {

    [Tooltip("Seconds between appearances")]
    public float seenEverySeconds;

    [Range(-3f, 3f)]
    private float currentSpeed;
    private Animator animator;
    private GameObject currentTarget;

	// Use this for initialization
	void Start () {
        animator = gameObject.GetComponent<Animator>();
	}

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    Debug.Log(collision);
    //}

    public void SetSpeed(float speed)
    {
        currentSpeed = speed;
    }

    public void StrikeCurrentTarget(float damage)
    {
        if (currentTarget)
        {
            currentTarget.GetComponent<Health>().DealDamage(damage);
        }
        else animator.SetBool("isAttacking", false);
    }

    public void Attack (GameObject target)
    {
        currentTarget = target;
        animator.SetBool("isAttacking", true);
        //Debug.Log(animator.GetBool("isAttacking"));
    }

    public void Jump ()
    {
        animator.SetTrigger("jumpTrigger");
    }
}
