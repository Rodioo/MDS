using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainMenuScript : MonoBehaviour
{

    public TextMeshProUGUI volumeText;
    public TextMeshProUGUI difficultyText;
    public GlobalStatus playerStats;

    void Update()
    {
        volumeText.text = "VOLUME:" + playerStats.volume;
        difficultyText.text = "DIFFICULTY:" + playerStats.difficulty;
    }
}
