using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class GlobalStatus : ScriptableObject
{
    public Vector2 initPosition;
    public int hp = 100;
    public int gold = 0;
}
