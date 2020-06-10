using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 5f;
    public float jumpForce = 20f;
    private bool jump;
    private float DisstanceToTheGround;

    private Vector3 inputVector;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        DisstanceToTheGround = GetComponent<Collider>().bounds.extents.y;
    }

    // Update is called once per frame
    void Update()
    {
        inputVector = new Vector3(Input.GetAxisRaw("Horizontal") * speed, rb.velocity.y, Input.GetAxisRaw("Vertical") * speed);
        transform.LookAt(transform.position + new Vector3(inputVector.x, 0, inputVector.z));
        bool isGrounded = Physics.Raycast(transform.position, Vector3.down, DisstanceToTheGround + 0.1f);
        if (Input.GetButtonDown("Jump") && (isGrounded))
        {
            jump = true;
        }

    }

    void FixedUpdate()
    {
        rb.velocity = inputVector;
        if (jump)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            jump = false;
        }
    }

    private void OnTriggerEnter(Collider colliderTag)
    {
        switch (colliderTag.tag)
        {
            case "Coin":
                Destroy(colliderTag.gameObject);
                break;
            case "PowerOne":
                Destroy(colliderTag.gameObject);
                StartCoroutine(PowerOne(5f));
                break;
            default:
                break;
        }
    }

    IEnumerator PowerOne(float waitTime)
    {
        speed = 30f;
        yield return new WaitForSeconds(waitTime);
        speed = 5f;
    }
}
