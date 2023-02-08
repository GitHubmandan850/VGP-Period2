using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FpCamera : MonoBehaviour
{
    public Transform player;
    public float mousesensitivity= 3f;
    float cameraVerticalRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Mouse X") * mousesensitivity;
        float inputY = Input.GetAxis("Mouse Y") * mousesensitivity;

        cameraVerticalRotation -= inputY;
        cameraVerticalRotation = Mathf.Clamp(cameraVerticalRotation, -90f, 90f);
        transform.localEulerAngles = Vector3.right * cameraVerticalRotation;

        player.Rotate(Vector3.up * inputX);
    }
}
