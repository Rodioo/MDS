using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemy2move : MonoBehaviour
{
    public GlobalStatus playerStatus;


    public float speed;
    public Animator animator;

    private float lineOfSite = 50;
    public float shootingRange;

    public float fireRate = 1f;
    private float nextFireTime;

    public GameObject bullet;
    public GameObject bulletParent;

    private Rigidbody2D rb;

    private Transform player;

    public int hp = 30;
    public int damage = 20;

    private int shooterGold;


    public RoomService roomService;

    // Start is called before the first frame update
    void Start()
    {
        if (playerStatus.difficulty == 2)
        {
            hp += 5;
            damage += 5;
            speed += 1;
            fireRate -= 0.2f;
        }
        else if (playerStatus.difficulty == 3)
        {
            hp += 10;
            damage += 10;
            speed += 2;
            fireRate -= 0.4f;
        }


        if (roomService.rooms[SceneManager.GetActiveScene().buildIndex])
        {
            Destroy(gameObject);

        }
        nextFireTime = Time.time + fireRate;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = this.GetComponent<Rigidbody2D>();

        shooterGold = Random.Range(2, 8);
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;


        Vector3 direction = player.position - transform.position;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;


        float distanceFromPlayer = Vector2.Distance(player.position,
            transform.position);

        if (distanceFromPlayer < lineOfSite && distanceFromPlayer > shootingRange)
        {
            transform.position = Vector2.MoveTowards(this.transform.position
                , player.position, speed * Time.deltaTime);
        }
        else if (distanceFromPlayer <= shootingRange && nextFireTime > Time.time && nextFireTime < Time.time + 0.5f)
        {
            animator.SetBool("isShooting", true);
        }
        else if (distanceFromPlayer <= shootingRange &&
            nextFireTime < Time.time)
        {
            Instantiate(bullet, bulletParent.transform.position,
                Quaternion.identity);
            nextFireTime = Time.time + fireRate;
            animator.SetBool("isShooting", false);

        }
        else
        {
            animator.SetBool("isShooting", false);
        }

    }


    private int getPlayerDamage(Collision2D collision)
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player.name == "Ninja")
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
        script.playerStats.gold += shooterGold;

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            int damage = getPlayerDamage(collision);
            hp -= damage;
            if (hp <= 0)
            {
                increasePlayerGold();
                Destroy(gameObject);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, lineOfSite);
        Gizmos.DrawWireSphere(transform.position, shootingRange);
    }
}
