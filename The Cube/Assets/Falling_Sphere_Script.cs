using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling_Sphere_Script : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Platform")
        {

            collision.gameObject.GetComponent<Track_Platform_Script>().BecomeVoid();

            //this.GetComponent<Falling_Sphere_Script>().enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            this.GetComponent<Rigidbody>().useGravity = true;
        }
    }


}
