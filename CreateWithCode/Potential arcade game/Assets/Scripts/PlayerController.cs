using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerController : MonoBehaviour
{
    public GameObject player;
    private Rigidbody Rb;
    public GameObject Gun;
    public float health = 100;
    public float speed = 5.0f;
    private float horizontalInput;
    private float forwardInput;
    public GameManager gamemanager;
    
    private string inputID; 
 
    // Start is called before the first frame update
    void Start()
    {
    
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
            speed = 8f;
        }
        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
         speed = 5.0f;
        }
        if(gamemanager.isGameActive = false)
        {
            speed = 0;
        }
        if(gamemanager.isGameActive = true)
        {
            speed = 5;
        }

        health = Mathf.Clamp(health, 0, 100);
    }

    private void OnCollisionEnter(Collision other)
    {
        if(health < 0)
        {
            Destroy(player.gameObject);
            speed = 0;
            gamemanager.isGameActive = false;
        }
    }
}

