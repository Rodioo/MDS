using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class SaveTest
{
    [Test]
    public void testSaveLoad()
    {
        var p1 = ScriptableObject.CreateInstance<GlobalStatus>();
        var r1 = ScriptableObject.CreateInstance<RoomService>();
        var p2 = ScriptableObject.CreateInstance<GlobalStatus>();
        var r2 = ScriptableObject.CreateInstance<RoomService>();
        p1.resetStats();
        p2.ninjaStats();
        r1.lastRoom = "Menu";

        SaveSystem.Save(p1, r1);
        SaveSystem.Load(p2, r2);

        Assert.AreEqual((p1.maxHp,p1.dmg,p1.aspd, p1.spd, p1.bspd), (p2.maxHp, p2.dmg, p2.aspd, p1.spd, p1.bspd));
        Assert.AreEqual(r2.lastRoom, "Menu");

    }

}
