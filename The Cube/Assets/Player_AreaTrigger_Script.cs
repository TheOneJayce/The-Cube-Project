using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_AreaTrigger_Script : MonoBehaviour
{

    public bool IsLeftTrigger;
    public bool IsRightTrigger;

    public bool LeftBlocked = false;
    public bool RightBlocked = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(IsLeftTrigger == true)
        {
            if (other.gameObject.tag == "Obstacle" || other.gameObject.tag == "Enemy")
            {
                LeftBlocked = true;
            }
        }

        if(IsRightTrigger == true)
        {
            if (other.gameObject.tag == "Obstacle" || other.gameObject.tag == "Enemy")
            {
                RightBlocked = true;
            }
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (IsLeftTrigger == true)
        {
            if (other.gameObject.tag == "Obstacle" || other.gameObject.tag == "Enemy")
            {
                LeftBlocked = false;
            }
        }

        if (IsRightTrigger == true)
        {
            if (other.gameObject.tag == "Obstacle" || other.gameObject.tag == "Enemy")
            {
                RightBlocked = false;
            }
        }
    }

}
