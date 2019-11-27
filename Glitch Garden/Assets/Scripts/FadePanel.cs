using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadePanel : MonoBehaviour {

    public static int fadeState = 0;
    public const int NoFade = 0;
    public const int PlayFadeOut = 1;
    public const int PlayFadeIn = 2;

    // Use this for initialization
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // Update is called once per frame
    void Update () {
        if (fadeState == NoFade)
        {
            return;
        } else if (fadeState == PlayFadeOut)
        {
            FadeOut();
        } else if (fadeState == PlayFadeIn)
        {
            FadeIn();
        }
	}

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void FadeOut()
    {
        //Destroy(GameObject.Find("Buttons"));
        //Destroy(GameObject.FindGameObjectWithTag("DefenderParent"));
        //Destroy(GameObject.Find("Spawners"));
        //Destroy(GameObject.FindGameObjectWithTag("ProjectileParent"));
        GetComponent<Animator>().Play("fadeOut");
        fadeState = NoFade;
        StartCoroutine("DeactivateObject");
    }

    private void FadeIn()
    {
        GetComponent<Animator>().Play("fadeIn");
        fadeState = NoFade;
        StartCoroutine("DeactivateObject");
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex != 0)
        {
            fadeState = PlayFadeIn;
        }
    }

    private IEnumerator DeactivateObject()
    {
        yield return new WaitForSeconds(1.0f);
        gameObject.SetActive(false);
        StopCoroutine("DeactivateObject");
    }

    private void CallLoadLevel()
    {
        Debug.Log("LoadLevel called");
        GetComponent<Animator>().SetTrigger("clipFinished");
        FindObjectOfType<LevelManager>().LoadSceneByIndex();
    }
}
