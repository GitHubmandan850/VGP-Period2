using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomTrig : MonoBehaviour
{
    public Camera camera;
    public MeshRenderer renderer;
    public BoxCollider trig;
    public BoxCollider colider;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<MeshRenderer>();
        colider = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            colider.enabled = true;
            renderer.enabled = true;
            camera.orthographicSize = 6.0f;

        }
    }
}
