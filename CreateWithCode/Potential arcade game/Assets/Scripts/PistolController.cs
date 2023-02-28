using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolController : MonoBehaviour
{

private Animator PistolAnim;

    // Start is called before the first frame update
    void Start()
    {
        PistolAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PistolAnim.SetTrigger("Fire");
        }
    }
}
