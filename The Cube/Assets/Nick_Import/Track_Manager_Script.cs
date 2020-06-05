using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Track_Manager_Script : MonoBehaviour
{
     GameObject[] Platforms;

    // Start is called before the first frame update
    void Start()
    {
        Platforms = GameObject.FindGameObjectsWithTag("Platform");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ActivatePlatforms();
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
}
