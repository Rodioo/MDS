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
}
/*
public int hp = 100;
public int gold = 0;
public int dmg = 15;
public float aspd = 1f;
public float bspd = 5f;
public float spd = 3f;
*/