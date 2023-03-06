using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public GameObject Enemyman;

    private void OnCollisionEnter(Collider other)
    {
        if(other.CompareTag("Bullet"))
        {
            Destroy(Enemyman);
        }
    }
}
