using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Ball_Script : MonoBehaviour
{

    bool IsMoving = false;
    bool IsDestroyed = false;

    private Vector3 targetScale;

    public int CurrentPosition = 1;
    float speed = 2f;
    public bool IsMovingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        if(CurrentPosition == 4)
        {
            IsMovingRight = false;
        }

        targetScale = new Vector3(0f, 0f, 0f);

    }

    // Update is called once per frame
    void Update()
    {
        if (IsMoving == true && IsDestroyed != true)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * 5);

            if(IsMovingRight == true)
            {
                transform.Translate(Vector3.left * Time.deltaTime * 5);
            }
            else if(IsMovingRight == false)
            {
                transform.Translate(Vector3.right * Time.deltaTime * 5);
            }

        }

        if (IsDestroyed == true)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, targetScale, speed * Time.deltaTime);

            if (transform.localScale == targetScale)
            {
                Destroy(gameObject);
            }
        }

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "PlatformBreak")
        {
            this.GetComponent<Rigidbody>().useGravity = true;
            this.GetComponent<Rigidbody>().isKinematic = false;
            IsDestroyed = true;
        }
    }


    public void ActivateEnemy()
    {
        StartCoroutine(EnemyMoveTimer());

        
    }

    IEnumerator EnemyMoveTimer()
    {

        //yield return new WaitForSeconds(RandomStartDealy);
        IsMoving = true;
        yield return new WaitForSeconds(1.4f);
        IsMoving = false;

        if(IsMovingRight == true)
        {
            if(CurrentPosition == 5)
            {
                IsMovingRight = false;
            }
            else
            {
                CurrentPosition += 1;

                if(CurrentPosition == 5)
                {
                    IsMovingRight = false;
                }
            }
        }

        if (IsMovingRight == false)
        {
            if (CurrentPosition == 1)
            {
                IsMovingRight = true;
            }
            else
            {
                CurrentPosition -= 1;

                if(CurrentPosition == 1)
                {
                    IsMovingRight = true; ;
                }
            }
        }


    }

}
