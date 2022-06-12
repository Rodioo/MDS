using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public string scene;
    public GlobalStatus playerStats;
    public Vector2 transitionPosition;
   
    //rivate int ghe = EnemyCount.ok;
    GameObject enemyCount;
    EnemyCounter script;
    int open;


    public RoomService roomService;

    void Update()
    {
        enemyCount = GameObject.FindGameObjectWithTag("counter");


        script = enemyCount.GetComponent<EnemyCounter>();
        open = script.nr;
      
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(SceneManager.GetActiveScene().buildIndex);
        //Debug.Log(roomService.rooms.Length);


        if ((collision.gameObject.name == "Archer" || collision.gameObject.name == "Ninja") 
            && open == 0)
        {
            //Debug.Log(SceneManager.GetActiveScene().buildIndex);

            roomService.rooms[SceneManager.GetActiveScene().buildIndex] = true;
            playerStats.initPosition = transitionPosition;
            SceneManager.LoadScene(scene);
        }

    }

}
