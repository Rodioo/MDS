using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Shooting : MonoBehaviour
{
    public Animator animator;

    public Transform firePoint;
    public GameObject shurikenPrefab;

    public float bulletForce = 5f;
    public float fireSpeed = 5f;

    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
            animator.SetBool("IsShooting", true);
        }
        else if(Input.GetButtonUp("Fire1"))
        {
            animator.SetBool("IsShooting", false);
        }
    }

    void Shoot()
    {
        GameObject shuriken = Instantiate(shurikenPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = shuriken.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }

}
