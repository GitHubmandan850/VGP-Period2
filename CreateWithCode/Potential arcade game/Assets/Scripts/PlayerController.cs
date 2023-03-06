using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerController : MonoBehaviour
{
    public GameObject player;
    public GameObject Gun;
    public float health = 100;
    public float speed = 5.0f;
    private float horizontalInput;
    private float forwardInput;
    
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
            speed = 8.0f;
        }
        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
         speed = 5.0f;
        }

        health = Mathf.Clamp(health, 0, 100);
    }

    private void OnCollisionEnter(Collision other)
    {
        if(health < 0)
        {
            Destroy(player.gameObject);
            speed = 0;
        }
    }

    private void OnCollisionEnter(Collider other)
    {
        if(other.CompareTag("Gun"))
        {
            Gun.SetActive(true);
        }
    }
}

