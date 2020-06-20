using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike_Platform_Script : MonoBehaviour
{
    public GameObject Spikes;

    public bool IsShort;
    public bool IsLong;

    int Counter = 0;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(Counter == 0)
            {
                Counter++;

                if (IsShort == true)
                {
                    Spikes.SetActive(true);
                    Spikes.transform.Translate(Vector3.up * 1);
                }

                if (IsLong == true)
                {
                    Spikes.SetActive(true);
                    Spikes.transform.localScale = new Vector3(1,2,1);
                    Spikes.transform.Translate(Vector3.up * 3);
                }

            }


        }
    }
}
