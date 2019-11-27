using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

    public GameObject projectile;

    private GameObject projectileParent, gun;
    private Animator animator;
    private AttackerSpawner myLaneSpawner;

	// Use this for initialization
	void Start () {
        projectileParent = GameObject.FindGameObjectWithTag("ProjectileParent");
        if (projectileParent == null)
        {
            projectileParent = new GameObject("Projectiles");
            projectileParent.tag = "ProjectileParent";
            //Debug.LogError("No GameObject with ProjectileParent tag in this scene!");
        }
        gun = gameObject.transform.Find("Gun").gameObject;
        if (gun == null)
        {
            Debug.LogError("No Gun ChildObject found at " + this);
        }
        animator = GetComponent<Animator>();
        SetMyLaneSpawner();
	}

    private void Update()
    {
        animator.SetBool("isAttacking", IsAttackerAheadInLane());
    }

    private void SetMyLaneSpawner()
    {
        foreach (AttackerSpawner spawner in FindObjectsOfType<AttackerSpawner>())
        {
            if (spawner.transform.position.y == this.transform.position.y)
            {
                myLaneSpawner = spawner;
                return;
            }
        }

        if (myLaneSpawner == null)
        {
            Debug.LogError("No AttackerSpawner found in lane " + transform.position.y);
        }
    }

    private bool IsAttackerAheadInLane()
    {
        if (myLaneSpawner.transform.childCount > 0)
        {
            foreach (Transform attacker in myLaneSpawner.transform)
            {
                if (attacker.transform.position.x > this.transform.position.x)
                {
                    return true;
                }
            }
            return false;
        }
        else return false;
    }

    private void Shoot()
    {
        GameObject newProjectile = Instantiate(projectile);
        newProjectile.transform.parent = projectileParent.transform;
        newProjectile.transform.position = gun.transform.position;
    }
}
