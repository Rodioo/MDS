using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PauseTest
{
    [Test]
    public void testPasued()
    {
        var obj = new GameObject();
        var pause = obj.AddComponent<PauseMenuScript>();
        pause.pauseMenuUI = new GameObject();
        pause.pauseGame();
        Assert.AreEqual(PauseMenuScript.isPaused, true);
    }

    [Test]
    public void testResumed()
    {
        var obj = new GameObject();
        var pause = obj.AddComponent<PauseMenuScript>();
        pause.pauseMenuUI = new GameObject();
        pause.resumeGame();
        Assert.AreEqual(PauseMenuScript.isPaused, false);
    }

}
