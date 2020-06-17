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

    GameObject TrackManager;
    public GameObject LeftTriggerCheck;
    public GameObject RightTriggerCheck;

    public float MoveDealay = 0.1f;
    bool MoveDelayActive = false;
    bool IsSquished = false;
    bool IsFloating = false;

    public bool IsStuck;
    public bool IsFalling;

    // Start is called before the first frame update
    void Start()
    {
        TrackManager = GameObject.FindGameObjectWithTag("TrackManager");
        rb = GetComponent<Rigidbody>();
       // DisstanceToTheGround = GetComponent<Collider>().bounds.extents.y;
       // GameObject g = GameObject.FindGameObjectWithTag("PU1");
        //emitter = g.GetComponent<MeshEmitter>();
    }

    // Update is called once per frame
    void Update()
    {
        if(IsFalling == true)
        {
            return;
        }

        //Squish
        if (Input.GetKeyDown(KeyCode.S) && IsSquished == false)
        {
            IsSquished = true;
            transform.localScale -= new Vector3(0, 1.5f, 0);
            transform.Translate(Vector3.down * 1.25f);
        }
        if (Input.GetKeyUp(KeyCode.S) && IsSquished == true)
        {
            IsSquished = false;
            transform.localScale += new Vector3(0, 1.5f, 0);
            transform.Translate(Vector3.up * 1.25f);
        }

        //Floating
        if (Input.GetKeyDown(KeyCode.W) && IsFloating == false)
        {
            IsFloating = true;
            transform.localScale -= new Vector3(0, 1.5f, 0);
            transform.Translate(Vector3.up * 2f);
        }
        if (Input.GetKeyUp(KeyCode.W) && IsFloating == true)
        {
            IsFloating = false;
            transform.localScale += new Vector3(0, 1.5f, 0);
            transform.Translate(Vector3.down * 2f);
        }

        if (TrackManager.GetComponent<Track_Manager_Script>().StopTimer == true)
        {
            //return;
        }

        if (IsStuck == true)
        {
            return;
        }

        //Snap Movement
        if (Input.GetKey(KeyCode.A) && transform.position.x != -14 && MoveDelayActive == false &&
            LeftTriggerCheck.GetComponent<Player_AreaTrigger_Script>().LeftBlocked == false)
        {
            transform.Translate(Vector3.left * 7);
            StartCoroutine(TheMoveDelay());
        }

        if (Input.GetKey(KeyCode.D) && transform.position.x != 14 && MoveDelayActive == false &&
            RightTriggerCheck.GetComponent<Player_AreaTrigger_Script>().RightBlocked == false)
        {
            transform.Translate(Vector3.right * 7);
            StartCoroutine(TheMoveDelay());
        }

        /*
        inputVector = new Vector3(Input.GetAxisRaw("Horizontal") * speed, rb.velocity.y, Input.GetAxisRaw("Vertical") * speed);
        transform.LookAt(transform.position + new Vector3(inputVector.x, 0, inputVector.z));
        bool isGrounded = Physics.Raycast(transform.position, Vector3.down, DisstanceToTheGround + 0.1f);
        if (Input.GetButtonDown("Jump") && (isGrounded))
        {
            jump = true;
        }
        */

        //Coin text does not seem to be grabbing anything so I don't know how to fix this error
       // coinsText.text = currentCoins + "/" + TotalCoins.ToString("0");

    }

    IEnumerator TheMoveDelay()
    {
        MoveDelayActive = true;
        yield return new WaitForSeconds(MoveDealay);
        MoveDelayActive = false;
    }


    void FixedUpdate()
    {
       /* rb.velocity = inputVector;
        if (jump)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            jump = false;
        }*/
    }

   /* private void OnTriggerEnter(Collider colliderTag)
    {
        if(colliderTag.gameObject.layer == 8)
        {
            return;
        }

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
    }*/

}
