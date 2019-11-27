using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    [Range(0.0f, 60.0f)]
    public float autoLoadNextLevelAfter = 0.0f;
    //private string levelName;

    private string[] scenesArray;
    private static int sceneIndexToLoad;

    private void Start()
    {
        if (autoLoadNextLevelAfter <= 0)
        {
            Debug.Log("Level auto load disabled");
        }
        else LoadNextLevel();
    }

    public void LoadLevel(string name)
    {
        sceneIndexToLoad = GetSceneIndexByName(name);
        Resources.FindObjectsOfTypeAll<FadePanel>()[0].gameObject.SetActive(true);
        FadePanel.fadeState = FadePanel.PlayFadeOut;
        //FindObjectOfType<LevelManager>().StartCoroutine("CoLoadLevel", name);
    }

    //public IEnumerator CoLoadLevel(string name) {
    //    Debug.Log("Level load requested for: " + name);
    //    FadePanel.fadeState = FadePanel.PlayFadeOut;
    //    yield return new WaitForSeconds(1.0f);
    //    StopCoroutine("CoLoadLevel");
    //    SceneManager.LoadScene(name);
    //}

    public void QuitRequest() {
        Debug.Log("Quit requested");
        Application.Quit();
    }

    public void LoadNextLevel()
    {
        sceneIndexToLoad = SceneManager.GetActiveScene().buildIndex + 1;
        Resources.FindObjectsOfTypeAll<FadePanel>()[0].gameObject.SetActive(true);
        FadePanel.fadeState = FadePanel.PlayFadeOut;
        //FindObjectOfType<LevelManager>().StartCoroutine("CoLoadNextLevel");
    }

    //public IEnumerator CoLoadNextLevel() {
    //    yield return new WaitForSeconds(autoLoadNextLevelAfter - 1.0f);
    //    FadePanel.fadeState = FadePanel.PlayFadeOut;
    //    yield return new WaitForSeconds(1.0f);
    //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    //    StopCoroutine("CoLoadNextLevel");
    //}

    public void LoadSceneByIndex()
    {
        Debug.Log(sceneIndexToLoad);
        SceneManager.LoadScene(sceneIndexToLoad);
    }
    
    private int GetSceneIndexByName (string name)
    {
        scenesArray = GetComponent<ReadSceneNames>().scenes;
        //Debug.Log(scenesArray.Length);
        for (int index = 0; index <= scenesArray.Length; index++)
        {
            //Debug.Log(index);
            //Debug.Log(scenesArray[index]);
            if (name.Equals(scenesArray[index]))
            {
                Debug.Log(index);
                return index;
            }
        }
        Debug.LogError("No scene " +name + " found in readSceneNames.scenes!");
        return 0;
    }
}
