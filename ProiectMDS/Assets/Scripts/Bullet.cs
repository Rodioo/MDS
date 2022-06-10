using UnityEngine;


public class Bullet : MonoBehaviour
{
    
    //Coliziune
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
            Destroy(gameObject);
        if (collision.gameObject.name == "HitBox")
            MenuCollision.checkMenuHit(collision);
    }

}
