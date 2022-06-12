using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Spider : MonoBehaviour
{
    public Animator animator;

    private Transform player;
    private Rigidbody2D rb;
    private Vector2 movement;
    public float moveSpeed = 1f;
    public int hp = 30;
    public int damage = 20;
    private int spiderGold;

    public RoomService roomService;


    // Start is called before the first frame update
    void Start()
    {
        if (roomService.rooms[SceneManager.GetActiveScene().buildIndex])
        {
            Destroy(gameObject);

        }

        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = this.GetComponent<Rigidbody2D>();
        spiderGold = Random.Range(1, 6);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.position - transform.position;
        //Debug.Log(direction);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;

        direction.Normalize();
        movement = direction;

    }

    private void FixedUpdate()
    {
        moveCharacter(movement);
    }

    void moveCharacter(Vector2 direction)
    {   if(direction.x!=0 && direction.y!=0)
        {
            rb.MovePosition((Vector2)transform.position + (direction * moveSpeed/2 * Time.deltaTime));
        }
        else
        {
            rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
        }
    }

    private int getPlayerDamage()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if(player.name == "Ninja")
        {
            ShootingNinja script = player.GetComponent<ShootingNinja>();
            return script.bulletDamage;
        }
        if (player.name == "Archer")
        {
            ShootingArcher script = player.GetComponent<ShootingArcher>();
            return script.bulletDamage;
        }
        return 0;
    }

    private void increasePlayerGold()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Player script = player.GetComponent<Player>();
        script.playerStats.gold += spiderGold;
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {
            int damage = getPlayerDamage();
            hp -= damage;
            if(hp <= 0)
            {
                increasePlayerGold();
                Destroy(gameObject);
            }
        }

    }
}
