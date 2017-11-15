using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyerPlayerMovement : MonoBehaviour
{
	public int playerNum = 1;
    public float speed = 4;
    private bool canMove = true;
    private float stun = 2.0f;

    public AudioSource source;

    // Use this for initialization
    void Start()
    {
        //GlobalControl.AddPlayer(1);
        AudioSource source = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
			transform.position += new Vector3((GlobalControl.GetHorizontal(playerNum) * 0.05f * speed), (GlobalControl.GetVertical(playerNum) * 0.05f * speed), 0);
    }

    void OnTriggerEnter2D(Collider2D other)
    {	
        if (other.gameObject.layer == LayerMask.NameToLayer("Obstacles"))
        {
			canMove = false;
			StartCoroutine(ObstacleTimer(stun));
            source.Play();
        }
        else if(other.gameObject.layer == LayerMask.NameToLayer("ScreenBottom"))
        {
            Debug.Log("Hits Bottom.");
            gameObject.SetActive(false);
        }
    }

    private IEnumerator ObstacleTimer(float seconds)
    {
        canMove = false;
        yield return new WaitForSeconds(seconds);
        canMove = true;
    }

}
