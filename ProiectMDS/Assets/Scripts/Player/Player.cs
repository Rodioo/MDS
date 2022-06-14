using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    public GlobalStatus playerStats;

    public float moveSpeed = 3f;

    public Rigidbody2D rb;

    public Camera cam;

    Vector2 movement;

    Vector2 mousePos;

    public HealthBarScript healthBarScript;

    private bool isHit;
    private float timeSinceLastHit;

    public CurrencyScript currencyScript;

    public GameObject gameOver;
    public GameObject bossHealthUI;

    private void Start()
    {
        transform.position = playerStats.initPosition;

        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            transform.position = new Vector2 (-4,0);
        }

        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            transform.position = new Vector2(-4, 0);

            float scaledVolume = playerStats.volume / 10f;
            PlayerPrefs.SetFloat("volume", scaledVolume);
            AudioListener.volume = PlayerPrefs.GetFloat("volume");
        }

        if (playerStats.caracter == 1 && gameObject.name == "Ninja")
        {
            Destroy(gameObject);
        }
        else if (playerStats.caracter == 2 && gameObject.name == "Archer")
        {
            Destroy(gameObject);
        }
        

        moveSpeed = playerStats.spd;
        timeSinceLastHit = Time.time;
        isHit = false;

        currencyScript.setCurrency(playerStats.gold);
        healthBarScript.setHealth();

        GameObject.FindGameObjectWithTag("Music").GetComponent<Music>().PlayMusic();
    }

    void Update()
    {

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        moveSpeed = playerStats.spd;
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        if(Time.time >= timeSinceLastHit + 0.5f)
        {
            isHit = false;
            timeSinceLastHit = Time.time;
        }

        currencyScript.setCurrency(playerStats.gold);

    }

    void FixedUpdate()
    {
        
        if(movement.x != 0 && movement.y != 0)
        {
            rb.MovePosition(rb.position + movement * (moveSpeed) * Time.fixedDeltaTime);
        }
        else{
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        }
        Vector2 lookDir = mousePos -rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
    }

    private int getEnemyDamage(Collision2D collision)
    {   
        if(collision.gameObject.CompareTag("Spider"))
        {
            GameObject spider = GameObject.FindGameObjectWithTag("Spider");
            Spider script = spider.GetComponent<Spider>();
            return script.damage;
        }
        if (collision.gameObject.CompareTag("Boss"))
        {
            GameObject boss = GameObject.FindGameObjectWithTag("Boss");
            BossMove script = boss.GetComponent<BossMove>();
            return script.damage;
        }
        if (collision.gameObject.CompareTag("slimeBullet"))
        {
            GameObject enemy2 = GameObject.FindGameObjectWithTag("shooter");
            enemy2move script = enemy2.GetComponent<enemy2move>();
            return script.damage;
        }

        if (collision.gameObject.CompareTag("turretBullet"))
        {
            GameObject turretObj = GameObject.FindGameObjectWithTag("turret");
            turret script = turretObj.GetComponent<turret>();
            return script.damage;
        }
        return 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        int damage = getEnemyDamage(collision);
        if (collision.gameObject.CompareTag("Spider") || 
            collision.gameObject.CompareTag("Boss") ||
            collision.gameObject.CompareTag("slimeBullet") ||
            collision.gameObject.CompareTag("turretBullet"))
        {
            if(!isHit)
            {
                playerStats.hp -= damage;
                healthBarScript.setHealth();
                isHit = true;
            }
            if(playerStats.hp <= 0)
            {
                bossHealthUI.SetActive(false);
                gameOver.SetActive(true);
                Button menuButton = gameOver.transform.Find("MenuButton").gameObject.GetComponent<Button>();
                menuButton.onClick.AddListener(() => { playerStats.reset = true; });
            }
            else
            {
                bossHealthUI.SetActive(true);
                gameOver.SetActive(false);
            }
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Spikes"))
        {
            if (!isHit)
            {
                playerStats.hp -= 10;
                healthBarScript.setHealth();
                isHit = true;
            }
            if (playerStats.hp <= 0)
            {
                bossHealthUI.SetActive(false);
                gameOver.SetActive(true);
                Button menuButton = gameOver.transform.Find("MenuButton").gameObject.GetComponent<Button>();
                menuButton.onClick.AddListener(() => { playerStats.reset = true; });
            }
            else
            {
                bossHealthUI.SetActive(true);
                gameOver.SetActive(false);
            }
        }
        if (collision.gameObject.CompareTag("Item"))
        {
            GameObject item = collision.gameObject;
            Item script = item.GetComponent<Item>();
            if (script.price <= playerStats.gold)
            {
                playerStats.spd += script.spd;
                playerStats.hp += script.hp;
                playerStats.maxHp += script.hp;
                healthBarScript.setMaxHealth();
                playerStats.dmg += script.dmg;
                playerStats.bspd += script.bspd;
                playerStats.aspd *= script.aspd;
                playerStats.gold -= script.price;
            }
        }
    }
}
