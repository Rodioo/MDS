using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossMove : MonoBehaviour
{
    private Transform player;
    public GlobalStatus playerStatus;


    public int maxHp = 400;

    public int hp = 400;
    public int damage = 20;

    public float fireRate = 1f;
    private float nextFireTime;

    public GameObject bullet;
    public GameObject bulletParent;
    public GameObject horse;
    public GameObject body;

    public float speed = 10;

    int phase = 1;

    public Transform[] moveSpots;
    private int randomSpot;
    private Rigidbody2D rb;
    private Rigidbody2D horse_rb;
    private Rigidbody2D body_rb;

    public GameObject ui;
    public GameObject gameWon;
    public GameObject bossHealthUI;
    private BossHealthScript bossHealthScript;

    public GlobalStatus playerStats;

    public Animator animator;

    void Start()
    {
        if (playerStatus.difficulty == 2)
        {
            hp += 100;
            damage += 5;
            speed += 2;
            fireRate -= 0.2f;
        }
        else if (playerStatus.difficulty == 3)
        {
            hp += 200;
            damage += 10;
            speed += 4;
            fireRate -= 0.4f;

        }



        randomSpot = Random.Range(0, moveSpots.Length);
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = this.GetComponent<Rigidbody2D>();
        horse_rb = horse.GetComponent<Rigidbody2D>();
        body_rb = body.GetComponent<Rigidbody2D>();

        bossHealthScript = bossHealthUI.GetComponent<BossHealthScript>();

        bossHealthScript.setMaxHealth();
        hp = maxHp;
    }

    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        Vector2 horseDirection = moveSpots[randomSpot].position - transform.position;
        Vector2 bodyDirection = player.position - transform.position;

        float angle = Mathf.Atan2(bodyDirection.y, bodyDirection.x) * Mathf.Rad2Deg;
        body_rb.rotation = angle;

        float horseAngle = Mathf.Atan2(horseDirection.y, horseDirection.x) * Mathf.Rad2Deg;
        rb.rotation = horseAngle;
        horse_rb.rotation = horseAngle;

        transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);
        horse.transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);
        body.transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, moveSpots[randomSpot].position) < 0.5f)
            randomSpot = Random.Range(0, moveSpots.Length);

        if (nextFireTime > Time.time && nextFireTime < Time.time + 0.2f)
        {
            animator.SetBool("isShooting", true);
        }
        else if (nextFireTime < Time.time)
        {
            Instantiate(bullet, bulletParent.transform.position, bulletParent.transform.rotation);
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            int damage = getPlayerDamage(collision);
            hp -= damage;
            bossHealthScript.setHealth();
            if (hp <= 0)
            {
                ui.SetActive(false);
                bossHealthUI.SetActive(false);
                gameWon.SetActive(true);

                playerStats.reset = true;
                Destroy(gameObject);
            }
            else
            {
                ui.SetActive(true);
                bossHealthUI.SetActive(true);
                gameWon.SetActive(false);
            }
        }
    }
}
