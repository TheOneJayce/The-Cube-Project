using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Special_Platform_Script : MonoBehaviour
{
    [Header("General Settings")]

    [Header("References")]
    public GameObject[] StickyPlatform;

    [Header("Toggles")]
    public bool IsStickyPlatform;
    public bool IsSpikePlatform;
    public bool IsFallingPlatform;

    // Start is called before the first frame update
    void Start()
    {
        if(IsStickyPlatform == true)
        {
            foreach(GameObject sticky in StickyPlatform)
            {
                sticky.SetActive(true);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
