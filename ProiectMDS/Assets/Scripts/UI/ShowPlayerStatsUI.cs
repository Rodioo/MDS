using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowPlayerStatsUI : MonoBehaviour
{

    public GameObject statsMenuUI;
    public GameObject healthtext;
    public GlobalStatus playerStats;

    public Text damageText;
    public Text attackSpeedText;
    public Text bulletSpeedText;
    public Text movementSpeedText;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Tab))
        {
            showStatsUI();
        }
        else
        {
            hideStatsUI();
        }
    }

    private void loadPlayerStats()
    {
        healthtext.GetComponent<Text>().text = playerStats.hp + "/" + playerStats.maxHp;
        damageText.text = playerStats.dmg.ToString();
        attackSpeedText.text = playerStats.aspd.ToString();
        bulletSpeedText.text = playerStats.bspd.ToString();
        movementSpeedText.text = playerStats.spd.ToString();
    }

    private void showStatsUI()
    {
        loadPlayerStats();
        healthtext.SetActive(true);
        statsMenuUI.SetActive(true);
    }

    private void hideStatsUI()
    {
        healthtext.SetActive(false);
        statsMenuUI.SetActive(false);
    }


}
