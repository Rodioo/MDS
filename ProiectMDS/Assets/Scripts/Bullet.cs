using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class Bullet : MonoBehaviour
{
    
    //Coliziune
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
            Destroy(gameObject);
        if (collision.gameObject.name == "HitBox")
            MenuCollision.checkMenuHit(collision);
    }
}
