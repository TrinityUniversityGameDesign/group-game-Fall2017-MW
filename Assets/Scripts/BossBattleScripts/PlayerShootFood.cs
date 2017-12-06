using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootFood : MonoBehaviour {

    public GameObject food;
    public float delay = 1.0f;
    private bool readyToShoot = true;
    public int playerNum;

    public int pooledAmt = 5;
    List<GameObject> foods;

    // Use this for initialization
    void Start()
    {
        foods = new List<GameObject>();
        for (int i = 0; i < pooledAmt; i++)
        {
            GameObject obj = (GameObject)Instantiate(food);
            obj.SetActive(false);
            foods.Add(obj);
        }

    }
    void Fire()
    {
        for (int i = 0; i < foods.Count; i++)
        {
            if (!foods[i].activeInHierarchy)
            {
                foods[i].transform.position = transform.position;
                if(GetComponent<Rigidbody2D>().velocity.x < 0)
                {
                    foods[i].GetComponent<ShotMovement>().speed = -5f;
                    foods[i].GetComponent<SpriteRenderer>().flipX = true;
                    foods[i].GetComponent<SpriteRenderer>().flipY = true;
                }
                else
                {
                    foods[i].GetComponent<SpriteRenderer>().flipX = false;
                    foods[i].GetComponent<SpriteRenderer>().flipX = false;
                    foods[i].GetComponent<ShotMovement>().speed = 5f;
                }
                
                foods[i].SetActive(true);
                break;
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (GlobalControl.GetButtonRT(playerNum) && readyToShoot)
        {
            Fire();
            readyToShoot = false;
            Invoke("ResetReadyToShoot", delay);
        }

    }
    void ResetReadyToShoot()
    {
        readyToShoot = true;
    }



    void OnCollisionEnter2D(Collision2D other)
    {
    }

}
