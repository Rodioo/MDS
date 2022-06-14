using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{

    public static void Save(GlobalStatus playS, RoomService roomS)
    {
        SaveData data = new SaveData(playS, roomS);
        BinaryFormatter form = new BinaryFormatter();
        string path = Application.persistentDataPath + "/playSave.txt";
        FileStream file = new FileStream(path, FileMode.Create);

        form.Serialize(file, data);
        file.Close();

    }

    public static void Load(GlobalStatus playS, RoomService roomS)
    {
        string path = Application.persistentDataPath + "/playSave.txt";
        if (File.Exists(path))
        {
            BinaryFormatter form = new BinaryFormatter();
            FileStream file = new FileStream(path, FileMode.Open);

            SaveData data= form.Deserialize(file) as SaveData;
            file.Close();
            data.givePlayerData(playS);
            data.giveRoomData(roomS);
        }
    }
}
