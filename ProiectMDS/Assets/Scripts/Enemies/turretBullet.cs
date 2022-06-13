using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretBullet : MonoBehaviour
{

    Transform player;
    Vector2 target;

    public float speed;
    Rigidbody2D bulletRB;

    //CircleCollider2D ghe;
    private Vector2 val;

    // Start is called before the first frame update
    void Start()
    {
        Physics2D.IgnoreLayerCollision(10, 10);
        Physics2D.IgnoreLayerCollision(6, 10);
        Physics2D.IgnoreLayerCollision(8, 10);
        bulletRB = GetComponent<Rigidbody2D>();

        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(player.position.x, player.position.y);
        //enemy2 = GameObject.FindGameObjectWithTag("shooter");
        //enemy2Location = new Vector2(enemy2.position.x, enemy2.position.y);

        val = new Vector2((transform.position.x - player.position.x) * 1000,
            (transform.position.y - player.position.y) * 1000);

        //distToPlayer = Vector2.Distance(transform.position, player.position);
        //Vector2 moveDir = (target.transform.position - transform.position);
        //bulletRB.velocity = new Vector2(moveDir.x,moveDir.y);
        Destroy(this.gameObject, 5);
    }

    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target -= val;
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

        //if (transform.position.x == target.x && transform.position.y == target.y)
        //{
        // Destroy(gameObject);
        // }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        /*Physics2D.IgnoreLayerCollision(6, 7);
        Physics2D.IgnoreLayerCollision(6, 6);
        Physics2D.IgnoreLayerCollision(6, 10);*/
        Physics2D.IgnoreLayerCollision(10, 10);
        Physics2D.IgnoreLayerCollision(6, 10);
        if (collision.gameObject.CompareTag("Player"))
            Destroy(gameObject);
        if (!collision.gameObject.CompareTag("Player") &&
            !collision.gameObject.CompareTag("slimeBullet"))
            Destroy(gameObject);
        //if (collision.gameObject.name == "HitBox")
        // MenuCollision.checkMenuHit(collision);
    }


}
