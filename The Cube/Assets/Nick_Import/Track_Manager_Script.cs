using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Track_Manager_Script : MonoBehaviour
{
    [Header("General Settings")]

    public float TimeLeft = 3;
    public bool StopTimer = false;

    public float NumberOfRows = 10f;
    public float CurrentRow = 0;
    float row = 0;

    public int TotalCoins = 3;
    int CurrentCoins = 0;


    [Header("References")]

    GameObject[] Platforms;
    public Text TimerText;
    public Text CoinsText;
    public Slider ProgressSlider;

    // Start is called before the first frame update
    void Start()
    {
        Platforms = GameObject.FindGameObjectsWithTag("Platform");
    }

    // Update is called once per frame
    void Update()
    {
        TimerText.text = TimeLeft.ToString("0");
        CoinsText.text = CurrentCoins + "/" + TotalCoins.ToString("0");

        row = Mathf.Lerp(row, CurrentRow, Time.deltaTime);
        ProgressSlider.value = row;

        if (StopTimer == true)
        {
            return;
        }

        TimeLeft -= Time.deltaTime;
        if(TimeLeft <= 0)
        {
            ActivatePlatforms();
            StopTimer = true;
            CurrentRow += NumberOfRows / 100;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Destroy(GameObject.FindGameObjectWithTag("Coin"));
            CurrentCoins += 1;
        }
    }

    void ActivatePlatforms()
    {
        Platforms = GameObject.FindGameObjectsWithTag("Platform");

        foreach (GameObject platform in Platforms)
        {
            platform.GetComponent<Track_Platform_Script>().ActivatePlatformMovement();
        }
    }

    public void ResetTimer()
    {
        StopTimer = false;
        TimeLeft = 3.5f;
    }
}
