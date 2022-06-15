using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class StatTest
{
    [Test]
    public void resetArcher()
    {
        var player = ScriptableObject.CreateInstance<GlobalStatus>();
        player.resetStats();
        Assert.AreEqual(player.maxHp, player.hp);
        Assert.AreEqual(player.initPosition, new Vector2(1, 1));
        Assert.AreEqual(player.gold, 0);
        Assert.Greater(player.aspd, 0);
        Assert.Greater(player.spd, 0);
        Assert.Greater(player.bspd, 0);
    }

    [Test]
    public void resetNinja()
    {
        var player = ScriptableObject.CreateInstance<GlobalStatus>();
        player.ninjaStats();
        Assert.AreEqual(player.maxHp, player.hp);
        Assert.AreEqual(player.initPosition, new Vector2(1,1));
        Assert.AreEqual(player.gold, 0);
        Assert.Greater(player.aspd, 0);
        Assert.Greater(player.spd, 0);
        Assert.Greater(player.bspd, 0);


    }
}
