using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    public Slider slider;
    public GlobalStatus playerStats;


    private void Start()
    {
        setMaxHealth();
    }

    public void setMaxHealth()
    {
        slider.maxValue = playerStats.maxHp;
        slider.value = playerStats.hp;
    }

    public void setHealth()
    {
        slider.value = playerStats.hp;
    }
}
