using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public GameObject Bulletprefab;
    public float Bulletspeed = 10f;
    public float timeDestroy = 5f;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bullet = Instantiate(Bulletprefab, transform.position, Quaternion.identity) as GameObject;
            bullet.GetComponent<Rigidbody>().AddForce(transform.right * Bulletspeed);
            Destroy(bullet, timeDestroy);
        }
    }
}
