using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingNinja : MonoBehaviour
{
    public Animator animator;

    public Transform firePoint;
    public GameObject shurikenPrefab;

    public float bulletForce = 5f;
    public int bulletDamage = 10;
    public float fireRate = 1f;
    public float nextFire = 0f;

    void Update()
    {
        if(Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            animator.SetBool("IsShooting", true);
            Shoot();
        }
        else
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
