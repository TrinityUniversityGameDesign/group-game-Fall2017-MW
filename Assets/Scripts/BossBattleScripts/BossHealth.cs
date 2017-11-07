using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public Sprite healthImg;

    public float Bosshealth = 20;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    { 
        if(Bosshealth <= 0)
        {
            Destroy(gameObject);
        }
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        if (gameObject)
        {
            Bosshealth -= 1;
            print(Bosshealth);
        }
    }
}
