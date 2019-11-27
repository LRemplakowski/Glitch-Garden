using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour {

    public AudioClip[] levelMusicArray;
    public AudioClip levelWinSound;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        DontDestroyOnLoad(this);
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        AudioClip audioClip = levelMusicArray[scene.buildIndex];
        if (audioClip && audioSource.clip != audioClip)
        {
            audioSource.clip = audioClip;
            audioSource.loop = true;
            if (scene.buildIndex > 0) { audioSource.volume = PlayerPrefsManager.GetMasterVolume(); }
            audioSource.Play();
        }
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void ChangeVolume (float volume)
    {
        audioSource.volume = volume;
    }

    public void PlayWinSound()
    {
        AudioSource.PlayClipAtPoint(levelWinSound, transform.position);
    }

    //public void mutemusic()
    //{
    //    audiosource music = findobjectoftype<audiosource>();
    //    music.mute = !music.mute;
    //}
}
