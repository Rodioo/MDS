using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class MenuCollision : MonoBehaviour
{
    private static bool isNinja = true;

    public static void checkMenuHit(Collider2D col, GlobalStatus globalPlayer, RoomService roomService)
    {
        Transform textTransform = col.gameObject.transform.parent;




        //Main Menu Choices
        if (textTransform.name == "NewGame_Text")
        {
            SceneManager.LoadScene(1);
            globalPlayer.hp = 100;
            globalPlayer.gold = 0;
            globalPlayer.initPosition = new Vector2(1, 1);

            for(int i= 0; i<=16; ++i)
            {
                roomService.rooms[i] = false;
            }

        }
        else if (textTransform.name == "Settings_Text")
        {
            GameObject mainMenu = textTransform.parent.parent.Find("MainMenu").gameObject;
            GameObject settingsMenu = textTransform.parent.parent.Find("SettingsMenu").gameObject;
            mainMenu.SetActive(false);
            settingsMenu.SetActive(true);
        }
        //Settings Menu Choices
        else if (textTransform.name == "Volume-")
        {
            TextMeshProUGUI volume_text = textTransform.parent.Find("Volume_Text").gameObject.GetComponent<TextMeshProUGUI>();
            int volume = Int32.Parse(volume_text.text.Split(':')[1]);
            if (volume > 0)
                volume--;
            PlayerPrefs.SetFloat("volume", volume);
            AudioListener.volume = PlayerPrefs.GetFloat("volume");
            volume_text.text = "Volume:" + volume;
        }
        else if (textTransform.name == "Volume+")
        {
            TextMeshProUGUI volume_text = textTransform.parent.Find("Volume_Text").gameObject.GetComponent<TextMeshProUGUI>();
            int volume = Int32.Parse(volume_text.text.Split(':')[1]);
            if (volume < 10)
                volume++;
            PlayerPrefs.SetFloat("volume", volume);
            AudioListener.volume = PlayerPrefs.GetFloat("volume");
            volume_text.text = "Volume:" + volume;
        }
        else if (textTransform.name == "Brightness-")
        {
            TextMeshProUGUI brightness_text = textTransform.parent.Find("Brightness_Text").gameObject.GetComponent<TextMeshProUGUI>();
            int brightness = Int32.Parse(brightness_text.text.Split(':')[1]);
            if (brightness > 0)
                brightness--;
            brightness_text.text = "Brightness:" + brightness;
        }
        else if (textTransform.name == "Brightness+")
        {
            TextMeshProUGUI brightness_text = textTransform.parent.Find("Brightness_Text").gameObject.GetComponent<TextMeshProUGUI>();
            int brightness = Int32.Parse(brightness_text.text.Split(':')[1]);
            if (brightness < 5)
                brightness++;
            brightness_text.text = "Brightness:" + brightness;
        }
        else if (textTransform.name == "Back_Text")
        {
            GameObject mainMenu = textTransform.parent.parent.Find("MainMenu").gameObject;
            GameObject settingsMenu = textTransform.parent.parent.Find("SettingsMenu").gameObject;
            settingsMenu.SetActive(false);
            mainMenu.SetActive(true);
        }
        //Switch Menu Choices
        else if (textTransform.name == "SwitchCharacter_Text")
        {
            GameObject mainMenu = textTransform.parent.parent.Find("MainMenu").gameObject;
            GameObject switchMenu = textTransform.parent.parent.Find("SwitchMenu").gameObject;
            mainMenu.SetActive(false);
            switchMenu.SetActive(true);
        }
        else if (textTransform.name == "Left_Text" || textTransform.name == "Right_Text")
        {
            GameObject ninja = textTransform.parent.Find("Characters").Find("Ninja").gameObject;
            GameObject archer = textTransform.parent.Find("Characters").Find("Archer").gameObject;
            if (isNinja)
            {
                isNinja = false;
                ninja.SetActive(false);
                archer.SetActive(true);
            }
            else
            {
                isNinja = true;
                archer.SetActive(false);
                ninja.SetActive(true);
            }
        }
        else if (textTransform.name == "Confirm_Text")
        {
            //De modificat caracterul (scos prefab-ul de ninja si adaugat cel de archer)

            GameObject mainMenu = textTransform.parent.parent.Find("MainMenu").gameObject;
            GameObject switchMenu = textTransform.parent.parent.Find("SwitchMenu").gameObject;
            switchMenu.SetActive(false);
            mainMenu.SetActive(true);
        }
        else if (textTransform.name == "Quit_Text")
        {
            Debug.Log("Quit");
            Application.Quit();
        }

    }
}
