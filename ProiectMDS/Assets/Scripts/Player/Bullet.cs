using UnityEngine;


public class Bullet : MonoBehaviour
{
    public GlobalStatus globalPlayer;
    public RoomService roomService;
    //Coliziune
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Physics2D.IgnoreLayerCollision(7, 7);
        Physics2D.IgnoreLayerCollision(7, 9);
        if (!collision.gameObject.CompareTag("Player"))
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "HitBox")
        {
            MenuCollision.checkMenuHit(collision, globalPlayer, roomService);
            Destroy(gameObject);
        }
            

    }

}
