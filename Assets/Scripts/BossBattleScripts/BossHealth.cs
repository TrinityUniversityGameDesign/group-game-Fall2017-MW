using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{


    public float Bosshealth = 20;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    void OnCollisionEnter2d(Collision2D other)
    {
        if (other.gameObject.name == "pizza")
        {
            Bosshealth -= 1;
            print(Bosshealth);
        }
    }
}
