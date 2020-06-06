using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause_Script : MonoBehaviour
{
    public static bool gameIsPaused;

    [Header("General References")]
    public GameObject pauseMenu;

    [Header("Resume Time")]
    public Text resumeTime;
    public float resumeTimeLeft;
    public GameObject resumeTimeGO;
    public GameObject resumeTimeTextGO;
    public bool gameIsResuming = false;

    [Header("Timer")]
    public GameObject TimerGO;
    public GameObject TimerTextGO;

    [Header("Track_Manager_Script Reference")]
    public GameObject trackManager;
    public Track_Manager_Script trackManagerScript;

    public void Start()
    {
        trackManagerScript = trackManager.GetComponent<Track_Manager_Script>();
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameIsPaused = !gameIsPaused;
            pauseMenu.SetActive(true);
            PauseGame();
        }

        if(gameIsResuming == true)
        {
            TimerGO.SetActive(false);
            TimerTextGO.SetActive(false);

            resumeTimeTextGO.SetActive(true);
            resumeTimeGO.SetActive(true);

            resumeTimeLeft -= Time.unscaledDeltaTime;
            resumeTime.text = resumeTimeLeft.ToString("0");

            if (resumeTimeLeft <= 0)
            {           
                Time.timeScale = 1;
                gameIsResuming = false;

                resumeTimeGO.SetActive(false);
                resumeTimeTextGO.SetActive(false);

                TimerTextGO.SetActive(true);
                TimerGO.SetActive(true);

                resumeTimeLeft = 3;

                gameIsPaused = false;
            }
        }

    }

    void PauseGame()
    {
        if (gameIsPaused)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public void ResumeGame()
    {
        gameIsResuming = true;
    }
}
