using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

[Header("Speed & Stuff")]
public float jumpForce = 100;
public float gravityMultiplyer = 1;
public bool IsOnGround = true;
public bool gameOver = false;

private Rigidbody playerRb;


    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityMultiplyer;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsOnGround)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            IsOnGround = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            IsOnGround = true;
        }else if(collision.gameObject.CompareTag("Obsticle"))
        {
            Debug.Log("Game Over Nerd");
            gameOver = true;
        }
    }
}
