using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Track_Manager_Script : MonoBehaviour
{
    [Header("General Settings")]

    public float TimeLeft = 1;
    public bool StopTimer = false;

    public float NumberOfRows = 10f;
    public float CurrentRow = 0;
    float row = 0;

    public int TotalCoins = 3;
    int CurrentCoins = 0;


    [Header("References")]

    GameObject[] Platforms;
    GameObject[] Enemies;
    public Text TimerText;
    public Text CoinsText;
    public Slider ProgressSlider;

    public Transform CoinImageSpawnPoint;
    public GameObject CoinImage;
    public GameObject DestroyedImage;

    // Start is called before the first frame update
    void Start()
    {
        Platforms = GameObject.FindGameObjectsWithTag("Platform");
    }

    // Update is called once per frame
    void Update()
    {
       /* if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject TemporaryCoin = (GameObject.FindGameObjectWithTag("Coin"));
            TemporaryCoin.GetComponent<Coin_Script>().DisableImage();
            Destroy(TemporaryCoin);
            CurrentCoins += 1;
        }*/

        TimerText.text = TimeLeft.ToString("0");
        //CoinsText.text = CurrentCoins + "/" + TotalCoins.ToString("0");

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
    }

    void ActivatePlatforms()
    {
        Platforms = GameObject.FindGameObjectsWithTag("Platform");
        Enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject platform in Platforms)
        {
            platform.GetComponent<Track_Platform_Script>().ActivatePlatformMovement();
        }

        foreach (GameObject enemyobject in Enemies)
        {
            enemyobject.GetComponent<AI_Ball_Script>().ActivateEnemy();
        }

    }

    public void ResetTimer()
    {
        StopTimer = false;
        TimeLeft = 0.5f;
    }

    public void CoinSetup(int Row, GameObject thecoin)
    {
        GameObject image = Instantiate(CoinImage, CoinImageSpawnPoint);
        image.transform.Translate(Vector3.up * Row * 50);
        thecoin.GetComponent<Coin_Script>().LinkToImage(image);
    }

    public void CoinDestroyed(GameObject theobject)
    {
        Instantiate(DestroyedImage, theobject.transform);
       // theobject.SetActive(false);
    }
}
