using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public GlobalStatus player;
    public RoomService room;
    void Start()
    {
        SaveSystem.Load(player, room);
        SceneManager.LoadScene(1);
    }
}
