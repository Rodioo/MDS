using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthScript : MonoBehaviour
{
    public Slider slider;
    public BossMove bossScript;

    private void Start()
    {
        setMaxHealth();
    }

    public void setMaxHealth()
    {
        slider.maxValue = bossScript.maxHp;
        slider.value = bossScript.maxHp;
    }

    public void setHealth()
    {
        slider.value = bossScript.hp;
    }
}
