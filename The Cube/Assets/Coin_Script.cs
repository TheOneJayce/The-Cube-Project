using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin_Script : MonoBehaviour
{
    GameObject TrackManager;

    public int RowNumber = 0;

    GameObject TheImage;

    // Start is called before the first frame update
    void Start()
    {
        TrackManager = GameObject.FindGameObjectWithTag("TrackManager");

        TrackManager.GetComponent<Track_Manager_Script>().CoinSetup(RowNumber, this.gameObject);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LinkToImage(GameObject theimage)
    {
        TheImage = theimage;
    }

    public void DisableImage()
    {
        TheImage.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PlatformBreak")
        {
            TrackManager.GetComponent<Track_Manager_Script>().CoinDestroyed(TheImage);
        }

        if (other.gameObject.tag == "Player")
        {
            if(other.gameObject.GetComponent<Player_AreaTrigger_Script>() != null)
            {
                return;
            }

            SoundManager.PlaySound(SoundManager.Sound.LifePick);
            other.GetComponent<Player_Health_Script>().CurrentHealth += 25;
            Destroy(gameObject);
        }
    }

}
