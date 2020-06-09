using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision_Script : MonoBehaviour
{

    public GameObject player;

    public GameObject loseMenu;
    public GameObject winMenu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // If player falls below Y -10, player loses
        if(player.gameObject.transform.position.y <= -10)
        {
            loseMenu.SetActive(true);
            player.SetActive(false);
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        //If player collides with obstacle, they lose
        if(collision.gameObject.tag == "Obstacle")
        {
            loseMenu.SetActive(true);
            player.SetActive(false);
        }
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "WinTrigger")
        {
            winMenu.SetActive(true);
            player.SetActive(false);
        }
    }
}
