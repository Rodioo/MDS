using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingArcher : MonoBehaviour
{

    public GlobalStatus playerStats;
    public Transform firePoint;
    public GameObject arrowPrefab;

    public float bulletForce = 5f;
    public int bulletDamage = 15;
    public float fireRate = 1f;
    public float nextFire = 0f;
    public Quaternion rot = new Quaternion();

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            bulletForce = playerStats.bspd;
            bulletDamage = playerStats.dmg;
            fireRate = playerStats.aspd;
            nextFire = Time.time + fireRate;
            Shoot();
        }
        else
        {
        }
    }

    void Shoot()
    {
        rot = firePoint.rotation * Quaternion.Euler(0, 0, 90);
        GameObject arrow = Instantiate(arrowPrefab, firePoint.position, rot);
        Rigidbody2D rb = arrow.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }


}