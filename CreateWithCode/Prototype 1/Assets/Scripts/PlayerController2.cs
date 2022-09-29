using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{

    public float speed = 5.0f;
    public float turnspeed;
    public float horizontalInput;
    public float forwardInput;
    public Camera Player2Cam;
    public Camera HoodCamera2;
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
        Player2Cam.enabled = !Player2Cam.enabled;
        HoodCamera2.enabled = !HoodCamera2.enabled;
    }

    }
}
