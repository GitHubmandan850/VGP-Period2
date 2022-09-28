using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 5.0f;
    public float turnspeed;
    public float horizontalInput;
    public float forwardInput;
    public Camera mainCamera;
    public Camera hoodCamera;
    public KeyCode switchKey;
    public string inputID;


    void Start()
    {
        
    }


    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal" + inputID);
        forwardInput = Input.GetAxis("Vertical" + inputID);

        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        transform.Rotate(Vector3.up,Time.deltaTime * turnspeed * horizontalInput);

    if(Input.GetKeyDown(switchKey))
    {
        mainCamera.enabled = !mainCamera.enabled;
        hoodCamera.enabled = !hoodCamera.enabled;
    }

    }
}
