using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Track_Platform_Script : MonoBehaviour
{
    [Header("General Settings")]

    float RandomStartDealy = 0;
    float speed = 2f;

    [Header("References")]

    GameObject TrackManager;
    private Vector3 targetScale;

    [Header("Toggles")]

    bool IsMoving = false;
    bool IsDestroyed = false;
    public bool IsEndOfTrack;

    // Start is called before the first frame update
    void Start()
    {
        TrackManager = GameObject.FindGameObjectWithTag("TrackManager");

        targetScale = new Vector3(0f, 0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        if(IsMoving == true && IsDestroyed != true)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * 5);
        }

        if(IsDestroyed == true)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, targetScale, speed * Time.deltaTime);
            
            if(transform.localScale == targetScale)
            {
                Destroy(gameObject);
            }
        }
    }

    public void ActivatePlatformMovement()
    {
        StartCoroutine(PlatformMoveTimer());
    }

    IEnumerator PlatformMoveTimer()
    {

        RandomStartDealy = Random.Range(0.25f, 0.65f);
        //yield return new WaitForSeconds(RandomStartDealy);
        IsMoving = true;
        yield return new WaitForSeconds(1.4f);
        IsMoving = false;

        if(IsEndOfTrack == true)
        {
            TrackManager.GetComponent<Track_Manager_Script>().ResetTimer();
        }

    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "PlatformBreak")
        {
            this.GetComponent<Rigidbody>().useGravity = true;
            this.GetComponent<Rigidbody>().isKinematic = false;
            IsDestroyed = true;
        }
    }
}
