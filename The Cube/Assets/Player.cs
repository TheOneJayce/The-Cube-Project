using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 15f;
    private Vector3 inputVector;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        inputVector = new Vector3(Input.GetAxisRaw("Horizontal") * speed, rb.velocity.y, Input.GetAxisRaw("Vertical") * speed);
        transform.LookAt(transform.position + new Vector3(inputVector.x, 0, inputVector.z));

        rb.velocity = inputVector;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
