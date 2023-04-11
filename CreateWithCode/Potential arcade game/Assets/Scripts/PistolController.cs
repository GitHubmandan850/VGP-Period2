using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolController : MonoBehaviour
{

    private Animator PistolAnim;
    public GameObject Bulletprefab;
    public GameObject Casingprefab;
    public GameObject FirePoint;
    public GameObject CasingPoint;
    public float Bulletspeed = 10f;
    public float Casingspeed = 100f;
    public float timeDestroy = 5f;
    public float spareAmmo = 150;
    private bool canShoot = true;
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        PistolAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if(gameManager.ammo == 0f)
        {
            canShoot = false;
            PistolAnim.SetBool("Empty", true);
        }
        if (Input.GetKeyDown(KeyCode.Space) && canShoot)
        {
            PistolAnim.SetTrigger("Fire");
            GameObject bullet = Instantiate(Bulletprefab, FirePoint.transform.position, Quaternion.identity) as GameObject;
            bullet.GetComponent<Rigidbody>().AddForce(transform.right * Bulletspeed);
            Destroy(bullet, timeDestroy);
            GameObject casing = Instantiate(Casingprefab, CasingPoint.transform.position, Quaternion.identity) as GameObject;
            casing.GetComponent<Rigidbody>().AddForce(Vector3.down * Casingspeed);
            Destroy(casing, 2f);
            gameManager.ammo -= 1;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            gameManager.ammo = 10;
            canShoot = true;
            PistolAnim.SetBool("Empty", false);
            PistolAnim.SetBool("Reloading", true);
        }else
        {
            PistolAnim.SetBool("Reloading", false);
        }
    }
}
