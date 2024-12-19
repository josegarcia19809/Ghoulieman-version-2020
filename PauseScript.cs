using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject audioManager;
    private AudioSource audio;
    
    private AudioSource pauseAudio;
    public AudioClip pauseClip;

    private void Start()
    {
        audio = audioManager.GetComponent<AudioSource>();
        pauseAudio = audio.GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Paused();
            }
        }
    }

    private void Resume()
    {
        Time.timeScale = 1f;
        GameIsPaused = false;
        audio.Play();
        pauseAudio.PlayOneShot(pauseClip);
    }

    private void Paused()
    {
        Time.timeScale = 0f;
        GameIsPaused = true;
        audio.Pause();
        pauseAudio.PlayOneShot(pauseClip);
    }
}