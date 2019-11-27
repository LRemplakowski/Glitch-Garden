using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {

    private static GameObject selectedButton;
    public static GameObject selectedDefender;
    public GameObject defender;

    private void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().color = new Color(0.1411765f, 0.1411765f, 0.1411765f);
    }

    private void OnMouseDown()
    {
        if (selectedButton != null)
        {
            selectedButton.GetComponent<SpriteRenderer>().color = new Color(0.1411765f, 0.1411765f, 0.1411765f);
            selectedButton = this.gameObject;
            selectedButton.GetComponent<SpriteRenderer>().color = Color.white;
            selectedDefender = defender;
        } else
        {
            selectedButton = this.gameObject;
            selectedButton.GetComponent<SpriteRenderer>().color = Color.white;
            selectedDefender = defender;
        }
    }
}
