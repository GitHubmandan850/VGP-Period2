using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaserController : MonoBehaviour
{

[Header("Speed & Stuff")]
public float jumpForce = 100;
public float gravityMultiplyer = 1;
public float dbForce = 200;
[Header("Particals & audio")]
public ParticleSystem runningDirt;
[Header("Bools")]
public bool IsOnGround = true;
public bool gameOver = false;
public bool inAir = false;
public bool hasDbJumped = false;

private Animator playerAnim;
private AudioSource playerAudio;
private Rigidbody playerRb;


    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        Physics.gravity *= gravityMultiplyer;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsOnGround)
        {
            hasDbJumped = true;
            inAir = true;
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            IsOnGround = false;
            playerAnim.SetTrigger("Jump_trig");
            runningDirt.Stop();
        }else if(Input.GetKeyDown(KeyCode.Space) && inAir && hasDbJumped)
        {
            playerRb.AddForce(Vector3.up * dbForce, ForceMode.Impulse);
            hasDbJumped = false;
            IsOnGround = false;
            runningDirt.Stop();
        }else if(hasDbJumped == false)
        {
           
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            inAir = false;
            hasDbJumped = false;
            IsOnGround = true;
            runningDirt.Play();
        }

    }
}
