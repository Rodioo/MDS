using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCounter : MonoBehaviour
{
    public int nr = 1;

 

    // Update is called once per frame
    void Update()
    {
        var spiderVector = GameObject.FindGameObjectsWithTag("Spider");

        var shooterVector  =   GameObject.FindGameObjectsWithTag("shooter");

        var turretVector = GameObject.FindGameObjectsWithTag("turret");

        if (spiderVector.Length == 0  && shooterVector.Length == 0 &&
            turretVector.Length == 0)
        {
            nr = 0;
            // enemy camera 1 == 0;
        }
    }
}
