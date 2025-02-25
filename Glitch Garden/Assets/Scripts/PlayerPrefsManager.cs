﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPrefsManager : MonoBehaviour {

    const string MASTER_VOLUME_KEY = "master_volume",
                 DIFF_KEY = "difficulty",
                 LEVEL_KEY = "level_unlocked_";

    public static void SetMasterVolume (float volume)
    {
        if (volume >= 0f && volume <= 1f)
        {
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
        } else
        {
            Debug.LogError("Master volume out of range");
        }
    }

    public static float GetMasterVolume ()
    {
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
    }


    public static void UnlockLevel (int level)
    {
        if (level < SceneManager.sceneCountInBuildSettings-1)
        {
            PlayerPrefs.SetInt(LEVEL_KEY + level.ToString(), 1);
        } else
        {
            Debug.LogError("Trying to unlock level " + level + " not in current build! Check your build settings");
        }
    }

    public static bool IsLevelUnlocked (int level)
    {
        int levelValue = PlayerPrefs.GetInt(LEVEL_KEY + level.ToString());
        bool isLevelUnlocked = (levelValue == 1);

        if (level < SceneManager.sceneCountInBuildSettings-1)
        {
            return isLevelUnlocked;
        } else
        {
            Debug.LogError("Trying to query level " + level + " not in current build! Check your build settings");
            return false;
        }
    }


    public static void SetDifficulty (float difficulty)
    {
        if (difficulty >= 1f && difficulty <= 3f)
        {
            PlayerPrefs.SetFloat(DIFF_KEY, difficulty);
        } else
        {
            Debug.LogError("Difficulty variable " + difficulty + " is out of range!");
        }
    }

    public static float GetDifficulty ()
    {
        return PlayerPrefs.GetFloat(DIFF_KEY);
    }
}
