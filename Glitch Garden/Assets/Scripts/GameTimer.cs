using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour {

    [Tooltip("Level duration in seconds")]
    public int levelDuration = 60;

    private float durationRemaining;
    private Slider slider;
    private Image sliderFill;
    private Color finalColor, startColor;
    private bool winCalled = false;

	// Use this for initialization
	void Start () {
        durationRemaining = levelDuration;
        slider = GetComponent<Slider>();
        sliderFill = transform.GetChild(1).GetChild(0).gameObject.GetComponent<Image>();
        Debug.Log(sliderFill);
        startColor = new Color(0.8301887f, 0.1105296f, 0.03524384f);
        finalColor = new Color(0.07725753f, 0.8313726f, 0.0352941f);
        sliderFill.color = startColor;
	}
	
	// Update is called once per frame
	void Update () {
        durationRemaining -= Time.deltaTime;
        slider.value = (CalculateProgress(durationRemaining));
        sliderFill.color = LerpSliderColor();
        if (slider.value >= 1f && !winCalled)
        {
            winCalled = true;
            StartCoroutine("CoPlaySoundAndWait");
        }
	}

    private float CalculateProgress(float time)
    {
        float timePassed = levelDuration - time;
        float progress = timePassed / levelDuration;
        return progress;
    }

    private Color LerpSliderColor()
    {
        float lerpGreen = sliderFill.color.g;
        float lerpRed = sliderFill.color.r;
        float lerpBlue = sliderFill.color.b;
        if (slider.value < 0.5f)
        {
            lerpGreen = Mathf.Lerp(startColor.g, finalColor.g, slider.value*2);
        } else {
            lerpRed = Mathf.Lerp(startColor.r, finalColor.r, (slider.value - 0.5f) * 2);
        }
        lerpBlue = Mathf.Lerp(startColor.b, finalColor.b, slider.value);
        Color currentColor = new Color(lerpRed, lerpGreen, lerpBlue);
        //Debug.Log(currentColor);
        return currentColor;
    }

    private IEnumerator CoPlaySoundAndWait()
    {
        if (FindObjectOfType<MusicPlayer>())
        {
            FindObjectOfType<MusicPlayer>().PlayWinSound();
        }
        FindObjectOfType<WinText>().SetToVisivble();
        transform.parent.position = new Vector3(5, 3, -0.5f);
        yield return new WaitForSeconds(FindObjectOfType<MusicPlayer>().levelWinSound.length);
        FindObjectOfType<LevelManager>().LoadNextLevel();
        StopCoroutine("CoPlaySoundAndWait");
    }
}
