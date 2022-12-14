using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

[Header("Speed & Stuff")]
public float jumpForce = 100;
public float gravityMultiplyer = 1;
public float dbForce = 200;
[Header("Particals & audio")]
public ParticleSystem explotionParticle;
public ParticleSystem runningDirt;
public AudioClip jumpSound;
public AudioClip deathSound;
[Header("Bools")]
public bool IsOnGround = true;
public bool gameOver = false;
public bool inAir = false;
public bool hasDbJumped = false;
[Header("Ints")]

private Animator playerAnim;
private AudioSource playerAudio;
private Rigidbody playerRb;


    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        Physics.gravity *= gravityMultiplyer;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsOnGround && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            IsOnGround = false;
            playerAnim.SetTrigger("Jump_trig");
            runningDirt.Stop();
            playerAudio.PlayOneShot(jumpSound, 1.0f);
            inAir = true;
            hasDbJumped = true;
        }else if(Input.GetKeyDown(KeyCode.Space) && inAir && hasDbJumped)
        {
            playerRb.AddForce(Vector3.up * dbForce, ForceMode.Impulse);
            hasDbJumped = false;
            IsOnGround = false;
            playerAudio.PlayOneShot(jumpSound, 1.0f);
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
        }else if(collision.gameObject.CompareTag("Obsticle"))
        {
            Debug.Log("Game Over They Stole You're Liver");
            gameOver = true;
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            explotionParticle.Play();
            runningDirt.Stop();
            playerAudio.PlayOneShot(deathSound, 1.0f);
        }
        
    }
}
