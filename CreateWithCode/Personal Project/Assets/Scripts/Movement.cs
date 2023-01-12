using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Movement : MonoBehaviour
{
    public Transform player;

    public GameObject Exit;

    private Animator playerAnim;

    public float health = 100;
    public float speed = 5.0f;
    public float horizontalInput;
    public float forwardInput;
    private float healthCube = 50;

    public bool gameOver;
    public bool inPortal;
    
    public Camera mainCamera;

    public string inputID; 
 
    // Start is called before the first frame update
    void Start()
    {
        playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {        
        horizontalInput = Input.GetAxis("Horizontal" + inputID);
        forwardInput = Input.GetAxis("Vertical" + inputID);

        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        transform.Translate(Vector3.left * Time.deltaTime * speed * horizontalInput);

        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = 10.0f;
            playerAnim.SetBool("Running", true);
        }
        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
         speed = 5.0f;
         playerAnim.SetBool("Running", false);
        }

        health = Mathf.Clamp(health, 0, 100);

        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            playerAnim.SetBool("Swing_b", true);
        }
        if(Input.GetKeyUp(KeyCode.Mouse0))
        {
            playerAnim.SetBool("Swing_b", false);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("heal"))
        {
            Destroy(other.gameObject);
            health = health + healthCube;
        }

        if(other.gameObject.CompareTag("badGuy"))
        {
            health = health -= 50;
        }
        if(health == 0)
        {
            Destroy(player.gameObject);
            speed = 0;
            gameOver = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(inPortal == false)
        {
            if(other.gameObject.CompareTag("Portal"))
            {
                transform.position = Exit.transform.position;
                inPortal = true;
            }
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        inPortal = false;
    }
}
