using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy2Bullet : MonoBehaviour
{

    Transform player;
    Vector2 target;

    public float speed;
    Rigidbody2D bulletRB;

    //CircleCollider2D ghe;


    // Start is called before the first frame update
    void Start()
    {
        bulletRB = GetComponent<Rigidbody2D>();
        
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(player.position.x, player.position.y);


        //distToPlayer = Vector2.Distance(transform.position, player.position);
        //Vector2 moveDir = (target.transform.position - transform.position);
        //bulletRB.velocity = new Vector2(moveDir.x,moveDir.y);
        Destroy(this.gameObject, 5);
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Physics2D.IgnoreLayerCollision(6, 7);
        Physics2D.IgnoreLayerCollision(6, 6);
        if (collision.gameObject.CompareTag("Player"))
            Destroy(gameObject);
        if (!collision.gameObject.CompareTag("Player") && 
            !collision.gameObject.CompareTag("slimeBullet"))
           Destroy(gameObject);
        //if (collision.gameObject.name == "HitBox")
        // MenuCollision.checkMenuHit(collision);
    }


}
