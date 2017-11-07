using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knifeThrow : MonoBehaviour {
    public GameObject knife;
    public float delay = 1.0f;
    private bool readyToShoot = true;
    public int playerNum = 2;

    public int pooledAmt = 5;
    List<GameObject> knives;

    // Use this for initialization
    void Start () {
        knives = new List<GameObject>();
        for (int i=0; i < pooledAmt; i++)
        {
            GameObject obj = (GameObject)Instantiate(knife);
            obj.SetActive(false);
            knives.Add(obj);
        }

	}
	void FireMid()
    {
        for(int i = 0; i < knives.Count; i++)
        {
            if (!knives[i].activeInHierarchy)
            {
                knives[i].transform.position = transform.position;
                knives[i].SetActive(true);
                knives[i].transform.rotation = transform.rotation;
                break;
            }
        }
    }
    void FireHigh()
    {
        for (int i = 0; i < knives.Count; i++)
        {
            if (!knives[i].activeInHierarchy)
            {
                knives[i].transform.position = new Vector2(transform.position.x, transform.position.y + 2);
                knives[i].SetActive(true);
                knives[i].transform.rotation = transform.rotation;
                break;
            }
        }
    }
    void FireLow()
    {
        for (int i = 0; i < knives.Count; i++)
        {
            if (!knives[i].activeInHierarchy)
            {
                knives[i].transform.position = new Vector2(transform.position.x, transform.position.y - 2);
                knives[i].SetActive(true);
                knives[i].transform.rotation = transform.rotation;
                break;
            }
        }
    }

    // Update is called once per frame
    void Update () {
        if (GlobalControl.GetButtonDownB(playerNum) && readyToShoot){
            FireMid();
            readyToShoot = false;
            Invoke("ResetReadyToShoot", delay);
        }
        if (GlobalControl.GetButtonDownY(playerNum) && readyToShoot)
        {
            FireHigh();
            readyToShoot = false;
            Invoke("ResetReadyToShoot", delay);
        }
        if (GlobalControl.GetButtonDownX(playerNum) && readyToShoot)
        {
            FireLow();
            readyToShoot = false;
            Invoke("ResetReadyToShoot", delay);
        }

    }
    void ResetReadyToShoot()
    {
        readyToShoot = true; 
    }
 

}
