using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bounds : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y >=2){
            transform.position = new Vector3(transform.position.x, 2, 0);
        }
        else if(transform.position.y <= -4){
            transform.position = new Vector3(transform.position.x, -4, 0);
        }

    }
}
