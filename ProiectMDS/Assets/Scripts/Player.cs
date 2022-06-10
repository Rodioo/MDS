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

    public int hp = 100;

    private bool isHit;
    private float timeSinceLastHit;

    private void Start()
    {
        timeSinceLastHit = Time.time;
        isHit = false;
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
    }

    void FixedUpdate()
    {
        
        if(movement.x != 0 && movement.y != 0)
        {
            rb.MovePosition(rb.position + movement * (moveSpeed/2) * Time.fixedDeltaTime);
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
        return 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        int damage = getEnemyDamage(collision);
        if (collision.gameObject.CompareTag("Spider"))
        {
            if(!isHit)
            {
                hp -= damage;
                isHit = true;
            }
            if(hp <= 0)
            {
                Debug.Log("GG");
            }
        }
    }
}
