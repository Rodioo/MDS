using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.TestTools;

public class BHealthTest
{
    [Test]
    public void BHealthTestSimplePasses()
    {
        var obj = new GameObject();
        var bosH = obj.AddComponent<BossHealthScript>();
        bosH.slider = obj.AddComponent<Slider>();
        bosH.bossScript = obj.AddComponent<BossMove>();
        bosH.bossScript.enabled = false;
        bosH.bossScript.maxHp=10;
        bosH.bossScript.hp=20;
        bosH.setMaxHealth();
        bosH.setHealth();
        Assert.AreEqual(10, bosH.slider.value);

    }


}
