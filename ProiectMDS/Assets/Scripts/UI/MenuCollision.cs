using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class MenuCollision : MonoBehaviour
{
    private static bool isNinja = true;
    public static int volume = 10;
    public static int difficulty = 1;
    public static int caracter = 1;


    public static void checkMenuHit(Collider2D col, GlobalStatus globalPlayer, RoomService roomService)
    {
        Transform textTransform = col.gameObject.transform.parent;

        //Main Menu Choices

        if (textTransform.name == "ContinueGame_Text")
        {
            SceneManager.LoadScene(roomService.lastRoom);

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
            volume = Int32.Parse(volume_text.text.Split(':')[1]);
            if (volume > 0)
                volume--;
            float scaledVolume = volume / 10f;
            PlayerPrefs.SetFloat("volume", scaledVolume);
            AudioListener.volume = PlayerPrefs.GetFloat("volume");
            volume_text.text = "Volume:" + volume;
            globalPlayer.volume = volume;
        }
        else if (textTransform.name == "Volume+")
        {
            TextMeshProUGUI volume_text = textTransform.parent.Find("Volume_Text").gameObject.GetComponent<TextMeshProUGUI>();
            volume = Int32.Parse(volume_text.text.Split(':')[1]);
            if (volume < 10)
                volume++;
            float scaledVolume = volume / 10f;
            PlayerPrefs.SetFloat("volume", scaledVolume);
            AudioListener.volume = PlayerPrefs.GetFloat("volume");
            volume_text.text = "Volume:" + volume;
            globalPlayer.volume = volume;
        }
        else if (textTransform.name == "Difficulty-")
        {
            TextMeshProUGUI difficultyText = textTransform.parent.Find("DifficultyText")
                .gameObject.GetComponent<TextMeshProUGUI>();
            difficulty = Int32.Parse(difficultyText.text.Split(':')[1]);
            if (difficulty > 1)
                difficulty--;

            difficultyText.text = "Difficulty:" + difficulty;

            globalPlayer.difficulty = difficulty;
        }
        else if (textTransform.name == "Difficulty+")
        {
            TextMeshProUGUI difficultyText = textTransform.parent.Find("DifficultyText")
               .gameObject.GetComponent<TextMeshProUGUI>();
            difficulty = Int32.Parse(difficultyText.text.Split(':')[1]);
            if (difficulty < 3)
                difficulty ++ ;

            difficultyText.text = "Difficulty:" + difficulty;

            globalPlayer.difficulty = difficulty;
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
            caracter = 2;
            globalPlayer.caracter = 2;
            GameObject mainMenu = textTransform.parent.parent.Find("MainMenu").gameObject;
            GameObject switchMenu = textTransform.parent.parent.Find("SwitchMenu").gameObject;
            mainMenu.SetActive(false);
            switchMenu.SetActive(true);
        }
        else if (textTransform.name == "Left_Text" || textTransform.name == "Right_Text")
        {
            caracter = 2;
            globalPlayer.caracter = 2;
            GameObject ninja = textTransform.parent.Find("Characters").Find("Ninja").gameObject;
            GameObject archer = textTransform.parent.Find("Characters").Find("Archer").gameObject;
            if (isNinja)
            {
                isNinja = false;
                ninja.SetActive(false);
                archer.SetActive(true);
                globalPlayer.caracter = 1;
                caracter = 1;
            }
            else
            {
                isNinja = true;
                archer.SetActive(false);
                ninja.SetActive(true);
                globalPlayer.caracter = 2;
                caracter = 2;
            }
        }
        else if (textTransform.name == "Confirm_Text")
        {
            //De modificat caracterul (scos prefab-ul de ninja si adaugat cel de archer)

            GameObject mainMenu = textTransform.parent.parent.Find("MainMenu").gameObject;
            GameObject switchMenu = textTransform.parent.parent.Find("SwitchMenu").gameObject;
            switchMenu.SetActive(false);
            mainMenu.SetActive(true);
            roomService.lastRoom = "Main";
            SceneManager.LoadScene(roomService.lastRoom);
            if (caracter == 1)
            {
                globalPlayer.resetStats();

                for (int i = 0; i <= 16; ++i)
                {
                    roomService.rooms[i] = false;
                }

                for (int i = 0; i <= 3; ++i)
                {
                    globalPlayer.items[i] = false;
                }
            }
            if (caracter == 2)
            {
                globalPlayer.resetStats();

                for (int i = 0; i <= 16; ++i)
                {
                    roomService.rooms[i] = false;
                }

                for (int i = 0; i <= 3; ++i)
                {
                    globalPlayer.items[i] = false;
                }
            }
        }
        else if (textTransform.name == "Quit_Text")
        {
            Debug.Log("Quit");
            Application.Quit();
        }

    }
}
