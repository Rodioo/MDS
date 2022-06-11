using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy2Bullet : MonoBehaviour
{

    GameObject target;
    public float speed;
    Rigidbody2D bulletRB;

    //CircleCollider2D ghe;


    // Start is called before the first frame update
    void Start()
    {
        bulletRB = GetComponent<Rigidbody2D>();
        
        target = GameObject.FindGameObjectWithTag("Player");
        Vector2 moveDir = (target.transform.position - transform.position)
            * speed;
        bulletRB.velocity = new Vector2(moveDir.x,moveDir.y);
        Destroy(this.gameObject, 2);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Physics2D.IgnoreLayerCollision(6, 7);
        if (collision.gameObject.CompareTag("Player"))
            Destroy(gameObject);
        if (!collision.gameObject.CompareTag("Player") && 
            !collision.gameObject.CompareTag("slimeBullet"))
           Destroy(gameObject);
        //if (collision.gameObject.name == "HitBox")
        // MenuCollision.checkMenuHit(collision);
    }


}
