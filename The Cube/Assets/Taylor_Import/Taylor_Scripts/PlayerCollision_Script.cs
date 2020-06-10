using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollision_Script : MonoBehaviour
{

    public GameObject Player;
    PlayerScript playerScriptRef;

    public GameObject loseMenu;
    public GameObject winMenu;

    public Text explanationText;

    // Start is called before the first frame update
    void Start()
    {
        playerScriptRef = Player.GetComponent<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        // If player falls below Y -10, player loses
        if(Player.gameObject.transform.position.y <= -10)
        {
            loseMenu.SetActive(true);
            Player.SetActive(false);

            explanationText.text = "You Fell";
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        //If player collides with obstacle, they lose
        if(collision.gameObject.tag == "Obstacle" || collision.gameObject.tag == "Enemy")
        {
            loseMenu.SetActive(true);
            Player.SetActive(false);

            explanationText.text = "You hit an enemy or obstacle";
        }
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "WinTrigger" && playerScriptRef.currentCoins >= playerScriptRef.TotalCoins)
        {
            winMenu.SetActive(true);
            Player.SetActive(false);
        }
        else if(other.gameObject.tag == "WinTrigger" && playerScriptRef.currentCoins <= playerScriptRef.TotalCoins)
        {
            loseMenu.SetActive(true);
            Player.SetActive(false);

            explanationText.text = "You must collect all of the coins";
        }
    }
}
