using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    // For coin Pick Up
    public Text coinsText;
    public int currentCoins;
    public int TotalCoins = 3;

    public Rigidbody rb;
    public float speed = 15f;
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

        coinsText.text = currentCoins + "/" + TotalCoins.ToString("0");
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
                currentCoins += 1;
                break;
            default:
                break;
        }
    }


}
