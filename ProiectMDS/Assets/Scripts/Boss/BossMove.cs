using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossMove : MonoBehaviour
{
    private Transform player;

    public int hp = 200;
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

    public GlobalStatus playerStats;

    public Animator animator;

    void Start()
    {
        randomSpot = Random.Range(0, moveSpots.Length);
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = this.GetComponent<Rigidbody2D>();
        horse_rb = horse.GetComponent<Rigidbody2D>();
        body_rb = body.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (phase == 1)
        {
            if (hp <= 100 )
                phase = 2;

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
            if (hp <= 0)
            {
                ui.SetActive(false);
                gameWon.SetActive(true);
                Button menuButton = gameWon.transform.Find("MenuButton").gameObject.GetComponent<Button>();

                menuButton.onClick.AddListener(() => { playerStats.reset = true; });
                Destroy(gameObject);
            }
            else
            {
                ui.SetActive(true);
                gameWon.SetActive(false);
            }
        }
    }
}
