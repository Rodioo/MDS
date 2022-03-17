using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bullet : MonoBehaviour
{
    private void checkMenuHit(Collision2D col)
    {
        Transform parent = col.gameObject.transform.parent;
        GameObject mainMenu = parent.parent.gameObject;
        GameObject settingsMenu = mainMenu.transform.parent.Find("SettingsMenu").gameObject;
        Debug.Log(parent.name);
        if (parent.name == "NewGame_Text")
        {
            SceneManager.LoadScene(1);
        }
        else if(parent.name == "Settings_Text")
        {
            mainMenu.SetActive(false);
            settingsMenu.SetActive(true);
        }
        else if(parent.name == "Back_Text")
        {
            mainMenu.SetActive(true);
            //settingsMenu.SetActive(false);
        }
        else if(parent.name == "Quit_Text")
        {
            Debug.Log("Quit");
            Application.Quit();
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
        if (collision.gameObject.name == "HitBox")
            checkMenuHit(collision);
    }
}
