using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loser : MonoBehaviour {

    private LevelManager levelManager;

    [Tooltip("How many attackers can slip through before players loses a level")]
    public float levelHealth = 3;

	// Use this for initialization
	void Start () {
        levelManager = FindObjectOfType<LevelManager>();
        if (levelManager == null)
        {
            Debug.LogError("No LevelManager in scene!");
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Attacker>())
        {
            levelHealth -= 1;
            if (levelHealth <= 0)
            {
                levelManager.LoadLevel("03b Lose");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
    }
}
