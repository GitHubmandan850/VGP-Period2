using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if(gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        }
    }
}
