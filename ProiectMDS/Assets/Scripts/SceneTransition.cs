using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public string scene;

    void OnTriggerEnter2D(Collider2D collision){

        if(collision.gameObject.name == "Archer" || collision.gameObject.name == "Ninja")
        {
            SceneManager.LoadScene(scene);
        }

    }
}
