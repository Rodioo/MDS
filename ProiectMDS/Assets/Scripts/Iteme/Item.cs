using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int dmg;
    public int hp;
    public float spd;
    public float aspd;
    public float bspd;
    public int price;
    public Shop1 shop1;
    public Shop2 shop2;
    public Shop3 shop3;
    public int shop_number;

    private void Start()
    {
        if (shop_number == 1)
            shop1.setPrice(price);
        else if (shop_number == 2)
            shop2.setPrice(price);
        else if (shop_number == 3)
            shop3.setPrice(price);
        else
            price = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject player = collision.gameObject;
            Player script = player.GetComponent<Player>();

            if (script.playerStats.gold >= price)
            {

                Destroy(gameObject);
                if (shop_number == 1)
                    shop1.setPrice(0);
                else if (shop_number == 2)
                    shop2.setPrice(0);
                else if (shop_number == 3)
                    shop3.setPrice(0);
            }

        }

    }
}
