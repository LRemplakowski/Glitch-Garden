using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour {

    private Camera mainCamera;
    private GameObject defenderParent;
    private StarDisplay starDisplay;

    private void Start()
    {
        mainCamera = FindObjectOfType<Camera>();
        defenderParent = GameObject.FindGameObjectWithTag("DefenderParent");
        if (defenderParent == null)
        {
            defenderParent = new GameObject("Defenders");
            defenderParent.tag = "DefenderParent";
            //Debug.LogError("No GameObject with DefenderParent tag in this scene!");
        }
        starDisplay = FindObjectOfType<StarDisplay>();
    }

    private void OnMouseDown()
    {
        StarDisplay.Status canSpawn;
        GameObject defender = Button.selectedDefender;
        canSpawn = starDisplay.UseStars(defender.GetComponent<Defender>().starCost);
        if (canSpawn == StarDisplay.Status.SUCCESS)
        {
            SpawnDefender(defender);
        }
        else Debug.Log("Insufficient stars");
    }

    private Vector2 SnapToGrid (Vector2 rawWorldPos)
    {
        return new Vector2(Mathf.RoundToInt(rawWorldPos.x), Mathf.RoundToInt(rawWorldPos.y));
    }

    private Vector2 GetClickedWorldPosition()
    {
        Vector2 position = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        return position;
    }

    private void SpawnDefender(GameObject defender)
    {
        Instantiate(defender, SnapToGrid(GetClickedWorldPosition()), Quaternion.identity, defenderParent.transform);
    }
}
