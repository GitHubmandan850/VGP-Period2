using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomTrig : MonoBehaviour
{
    public Camera camera;
    public MeshRenderer renderer;
    public BoxCollider trig;
    public List<GameObject> targets;
    public BoxCollider colider;
    public float zoom;
    public EnemyController badman;

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
            camera.orthographicSize = zoom;
            badman.isAlive = true;
        }
    }
}
