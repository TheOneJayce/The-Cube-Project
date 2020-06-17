using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sticky_Platform_Script : MonoBehaviour
{

    public GameObject BubbleOne;
    public GameObject BubbleTwo;
    public GameObject BubbleThree;
    public GameObject BubbleFour;

    GameObject Player;



    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Player = other.gameObject;
            StartCoroutine(PlayerStuck());
        }
    }

    IEnumerator PlayerStuck()
    {
        Player.GetComponent<PlayerScript>().IsStuck = true;
        yield return new WaitForSeconds(1f);
        BubbleOne.SetActive(false);
        BubbleTwo.SetActive(false);
        BubbleThree.SetActive(false);
        BubbleFour.SetActive(false);
        Player.GetComponent<PlayerScript>().IsStuck = false;


    }

}
