using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knife_spin : MonoBehaviour
{
    //above 500 works best 
    public float z;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //rotates knife z times per sec
        transform.Rotate(0, 0, z * Time.deltaTime);
    }
}
