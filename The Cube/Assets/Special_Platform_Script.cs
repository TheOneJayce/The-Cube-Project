using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Special_Platform_Script : MonoBehaviour
{
    [Header("General Settings")]

    [Header("References")]
    public GameObject StickyPlatform;
    public GameObject SpikePlatform_Short;
    public GameObject SpikePlatform_Long;
    public GameObject FallingPlatform;

    [Header("Toggles")]
    public bool IsStickyPlatform;
    public bool IsSpikePlatform_Short;
    public bool IsSpikePlatform_Long;
    public bool IsFallingPlatform;

    // Start is called before the first frame update
    void Start()
    {
        if(IsStickyPlatform == true)
        {
            StickyPlatform.SetActive(true);
        }

        if (IsSpikePlatform_Short == true)
        {
            SpikePlatform_Short.SetActive(true);
        }

        if (IsSpikePlatform_Long == true)
        {
            SpikePlatform_Long.SetActive(true);
        }

        if(IsFallingPlatform == true)
        {
            FallingPlatform.SetActive(true);
        }
    }

}
