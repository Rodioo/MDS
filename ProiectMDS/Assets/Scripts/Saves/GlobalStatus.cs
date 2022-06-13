using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class GlobalStatus : ScriptableObject
{
    public Vector2 initPosition;
    public int hp = 100;
    public int maxHp = 100;
    public int gold = 0;
    public int dmg = 15;
    public float aspd = 1f;
    public float bspd = 5f;
    public float spd = 3f;
    public bool[] items = new bool[4];
    
    public int volume = MenuCollision.volume;

    public int difficulty = MenuCollision.difficulty;

    public int caracter = 1;

    public void resetStats()
    {
        hp = 100;
        maxHp = 100;
        gold = 0;
        dmg = 15;
        aspd = 0.85f;
        bspd = 7f;
        spd = 6f;
        initPosition = new Vector2(1, 1);
    }

    public void ninjaStats()
    {
        hp = 75;
        maxHp = 75;
        gold = 0;
        dmg = 10;
        aspd = 0.6f;
        bspd = 9f;
        spd = 8f;
        initPosition = new Vector2(1, 1);
    }
}
