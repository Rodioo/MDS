using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScript : MonoBehaviour
{
    public GlobalStatus globalPlayer;
    void Start()
    {
        globalPlayer.initPosition = new Vector2(-5, 0);
    }
}
