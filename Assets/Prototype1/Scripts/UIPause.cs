using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPause : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject startPanel;

    bool paused = false;
    bool intro = true;
  
    void Start()
    {
        paused = false;
        pausePanel.SetActive(false);
        Time.timeScale = 0;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Pause();
    }


    public void Pause()
    {
        paused = !paused;
        Time.timeScale = paused ? 0 : 1;
        pausePanel.SetActive(paused);
    }

    public void Intro()
    {
        intro = !intro;
        Time.timeScale = 1;
        startPanel.SetActive(intro);
    }
}
