using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Void_Trigger_Script : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponent<PlayerScript>().IsFalling = true;
            other.GetComponent<Rigidbody>().useGravity = true;
        }
    }

}
