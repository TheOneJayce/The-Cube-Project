using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Track_Platform_Script : MonoBehaviour
{
    bool IsMoving = false;
    bool IsDestroyed = false;
    float RandomStartDealy = 0;

    private Vector3 targetScale;
    float speed = 2f;

    // Start is called before the first frame update
    void Start()
    {
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
        yield return new WaitForSeconds(RandomStartDealy);
        IsMoving = true;
        yield return new WaitForSeconds(1.5f);
        IsMoving = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "PlatformBreak")
        {
            IsDestroyed = true;
            Debug.Log("IsDestoryed");
        }
    }
}
