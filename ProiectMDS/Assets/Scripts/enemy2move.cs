using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy2move : MonoBehaviour
{

    public float speed;

    public float lineOfSite;
    public float shootingRange;
    
    public float fireRate = 1f;
    private float nextFireTime;

    public GameObject bullet;
    public GameObject bulletParent;

    private Rigidbody2D rb;

    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.position - transform.position;
        
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;


        float distanceFromPlayer = Vector2.Distance(player.position,
            transform.position);

        if(distanceFromPlayer < lineOfSite  && distanceFromPlayer > shootingRange)
        {
            transform.position = Vector2.MoveTowards(this.transform.position
                , player.position, speed * Time.deltaTime);
        }
        else if(distanceFromPlayer <= shootingRange && 
            nextFireTime < Time.time)
        {
            Instantiate(bullet, bulletParent.transform.position,
                Quaternion.identity);
            nextFireTime = Time.time + fireRate;

        }

       
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, lineOfSite);
        Gizmos.DrawWireSphere(transform.position, shootingRange);

    }
}
