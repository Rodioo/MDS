using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public bool reset;
    public float[] initPosition;
    public int hp;
    public int maxHp;
    public int gold;
    public int dmg;
    public float aspd;
    public float bspd;
    public float spd;
    public bool[] items;
    public int volume;
    public int difficulty;
    public bool[] rooms;
    public string lastRoom;

    public int caracter = 1;


    public SaveData(GlobalStatus playerS, RoomService roomS)
    {
        reset = playerS.reset;
        initPosition = new float[2];
        initPosition[0] = playerS.initPosition.x;
        initPosition[1] = playerS.initPosition.y;
        hp = playerS.hp;
        maxHp = playerS.maxHp;
        gold = playerS.gold;
        dmg = playerS.dmg;
        aspd = playerS.aspd;
        bspd = playerS.bspd;
        spd = playerS.spd;
        items = new bool[playerS.items.Length];
        for(int i=0; i < playerS.items.Length; ++i)
        {
            items[i] = playerS.items[i];
        }
        volume = playerS.volume;
        difficulty = playerS.difficulty;
        caracter = playerS.caracter;

        rooms = new bool[roomS.rooms.Length];
        for(int i=0; i< roomS.rooms.Length; ++i)
        {
            rooms[i] = roomS.rooms[i];
        }
        lastRoom = roomS.lastRoom;
    }
    public void givePlayerData(GlobalStatus playerS)
    {
        playerS.reset = reset;
        playerS.initPosition.x = initPosition[0];
        playerS.initPosition.y = initPosition[1];
        playerS.hp = hp;
        playerS.maxHp = maxHp;
        playerS.gold = gold;
        playerS.dmg = dmg;
        playerS.aspd = aspd;
        playerS.bspd = bspd;
        playerS.spd = spd;
        for (int i = 0; i < items.Length; ++i)
        {
            playerS.items[i]=items[i];
        }
        playerS.volume = volume;
        playerS.difficulty = difficulty;
        playerS.caracter = caracter;
    }
    public void giveRoomData(RoomService roomS)
    {
        for (int i = 0; i < roomS.rooms.Length; ++i)
        {
            roomS.rooms[i] = rooms[i];
        }
        roomS.lastRoom = lastRoom;
    }

}
