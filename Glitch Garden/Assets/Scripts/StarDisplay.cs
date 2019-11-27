using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class StarDisplay : MonoBehaviour {

    private Text starsCountText;
    private int starsCount = 100;

    public enum Status { SUCCESS, FAILURE};

    private void Start()
    {
        starsCountText = GetComponent<Text>();
        starsCountText.text = starsCount.ToString();
    }

    public void AddStars (int amount)
    {
        starsCount += amount;
        starsCountText.text = starsCount.ToString();
    }

    public Status UseStars (int amount)
    {
        if (starsCount >= amount)
        {
            starsCount -= amount;
            starsCountText.text = starsCount.ToString();
            return Status.SUCCESS;
        } else
        {
            return Status.FAILURE;
        }
    }
}
