using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 3f;

    public Rigidbody2D rb;

    public Camera cam;

    Vector2 movement;

    Vector2 mousePos;

    public HealthBarScript healthBarScript;

    private bool isHit;
    private float timeSinceLastHit;

    public CurrencyScript currencyScript;
    public GlobalStatus playerStats;

    private void Start()
    {
        transform.position = playerStats.initPosition;
        timeSinceLastHit = Time.time;
        isHit = false;

        currencyScript.setCurrency(playerStats.gold);
        healthBarScript.setHealth(playerStats.hp);
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        if(Time.time >= timeSinceLastHit + 0.5f)
        {
            isHit = false;
            timeSinceLastHit = Time.time;
        }

        currencyScript.setCurrency(playerStats.gold);

    }

    void FixedUpdate()
    {
        
        if(movement.x != 0 && movement.y != 0)
        {
            rb.MovePosition(rb.position + movement * (moveSpeed) * Time.fixedDeltaTime);
        }
        else{
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        }
        Vector2 lookDir = mousePos -rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
    }

    private int getEnemyDamage(Collision2D collision)
    {   
        if(collision.gameObject.CompareTag("Spider"))
        {
            GameObject spider = GameObject.FindGameObjectWithTag("Spider");
            Spider script = spider.GetComponent<Spider>();
            return script.damage;
        }
        if (collision.gameObject.CompareTag("Boss"))
        {
            GameObject boss = GameObject.FindGameObjectWithTag("Boss");
            BossMove script = boss.GetComponent<BossMove>();
            return script.damage;
        }
        if (collision.gameObject.CompareTag("slimeBullet"))
        {
            GameObject enemy2 = GameObject.FindGameObjectWithTag("shooter");
            enemy2move script = enemy2.GetComponent<enemy2move>();
            return script.damage;
        }
        return 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        int damage = getEnemyDamage(collision);
        if (collision.gameObject.CompareTag("Spider") || 
            collision.gameObject.CompareTag("Boss") ||
            collision.gameObject.CompareTag("slimeBullet"))
        {
            if(!isHit)
            {
                playerStats.hp -= damage;
                healthBarScript.setHealth(playerStats.hp);
                isHit = true;
            }
            if(playerStats.hp <= 0)
            {
                Debug.Log("GG");
            }
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Spikes"))
        {
            if (!isHit)
            {
                playerStats.hp -= 10;
                healthBarScript.setHealth(playerStats.hp);
                isHit = true;
            }
            if (playerStats.hp <= 0)
            {
                Debug.Log("GG");
            }
        }
    }
}
