using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class GlobalStatus : ScriptableObject
{
    public Vector2 initPosition;
    public int hp = 200;
    public int maxHp = 200;
    public int gold = 0;
    public int dmg = 15;
    public float aspd = 1f;
    public float bspd = 5f;
    public float spd = 3f;
    public bool[] items = new bool[4];
    
    public int volume = MenuCollision.volume;

    public int difficulty = MenuCollision.difficulty;

    public int caracter = 1;
}
/*
public int hp = 100;
public int gold = 0;
public int dmg = 15;
public float aspd = 1f;
public float bspd = 5f;
public float spd = 3f;
*/