using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingNinja : MonoBehaviour
{
    public Animator animator;
    public GlobalStatus playerStats;
    public Transform firePoint;
    public GameObject shurikenPrefab;

    public float bulletForce = 5f;
    public int bulletDamage = 10;
    public float fireRate = 1f;
    public float nextFire = 0f;

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            animator.SetBool("IsShooting", true);
            bulletForce = playerStats.bspd;
            bulletDamage = playerStats.dmg;
            fireRate = playerStats.aspd;
            nextFire = Time.time + fireRate;
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
