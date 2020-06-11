using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    // For coin Pick Up
    public Text coinsText;
    public int currentCoins = 0;
    public int TotalCoins = 3;

    public Rigidbody rb;
    public float speed = 5f;
    public float jumpForce = 20f;
    private bool jump;
    private float DisstanceToTheGround;
    private MeshEmitter emitter;
    private Vector3 inputVector;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        DisstanceToTheGround = GetComponent<Collider>().bounds.extents.y;
        GameObject g = GameObject.FindGameObjectWithTag("PU1");
        emitter = g.GetComponent<MeshEmitter>();
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

        //Coin text does not seem to be grabbing anything so I don't know how to fix this error
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
        emitter.emit = true;
        speed = 30f;
        yield return new WaitForSeconds(waitTime);
        emitter.emit = false;
        speed = 5f;
    }

}
