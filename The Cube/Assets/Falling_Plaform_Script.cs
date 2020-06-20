using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling_Plaform_Script : MonoBehaviour
{
    public GameObject ParentPlatform;

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            ParentPlatform.GetComponent<Track_Platform_Script>().BecomeVoid();
        }
    }
}
