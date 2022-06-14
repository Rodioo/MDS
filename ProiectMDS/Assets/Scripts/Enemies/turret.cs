using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class turret : MonoBehaviour
{
    public GlobalStatus playerStatus;
    public Animator animator;


    public float shootingRange;

    public float fireRate = 1.1f;
    private float nextFireTime;

    public GameObject bullet;
    public GameObject bulletParent;

    private Rigidbody2D rb;

    private Transform player;

    public int hp = 25;
    public int damage = 25;

    private int turretGold;



    public RoomService roomService;
    // Start is called before the first frame update
    void Start()
    {
        if (playerStatus.difficulty == 2)
        {
            hp += 5;
            damage += 5;
            fireRate -= 0.1f;
        }
        else if (playerStatus.difficulty == 3)
        {
            hp += 10;
            damage += 10;
            fireRate -= 0.1f;
        }


        if (roomService.rooms[SceneManager.GetActiveScene().buildIndex])
        {
            Destroy(gameObject);
            Debug.Log("ghe");
        }

        //nextFireTime = Time.time + fireRate;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = this.GetComponent<Rigidbody2D>();

        turretGold = Random.Range(5, 10);
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;


        Vector3 direction = player.position - transform.position;

        /*float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;*/

        float distanceFromPlayer = Vector2.Distance(player.position,
            transform.position);

        if (distanceFromPlayer <= shootingRange && nextFireTime > Time.time && nextFireTime < Time.time + 0.5f)
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
        script.playerStats.gold += turretGold;

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
        Gizmos.DrawWireSphere(transform.position, shootingRange);
    }
}
