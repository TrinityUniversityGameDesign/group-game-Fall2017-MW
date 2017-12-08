using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {


    public float Playerhealth;
    float dom;
	public float timeDelay = 300;
	public Text win;
    public GameObject deathObject;
    public Slider healthbar;
    public BossHealth boss;
    private Animator animator; 

    public AudioClip hit;
    AudioSource audioSource;

    // Use this for initialization
    void Start () {
        int alive = PlayerState.playersAlive;
        Playerhealth += alive;
        dom = Playerhealth;
        healthbar.value = healthLeft();
        BossHealth.deadPlayers = 0;
        boss = GameObject.Find("Boss").GetComponent<BossHealth>();
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        animator.SetBool("isDead", false);
        
    }
	
	// Update is called once per frame
	void Update () {
        healthbar.value = healthLeft();
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        if (gameObject && other.gameObject.layer == 11 && boss.Bosshealth > 0)
        {
            print("hit");
            Playerhealth -= 1;
            audioSource.Play();
            print(Playerhealth);
            if(Playerhealth <= 0)
            {
                BossHealth.deadPlayers += 1;
                healthbar.value = healthLeft();
                StartCoroutine(death());
                gameObject.SetActive(false);
               
            }
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (gameObject && other.gameObject.layer == 11 && boss.Bosshealth > 0)
        {
            print("hit");
            Playerhealth -= 1;
            audioSource.Play();
            if (Playerhealth <= 0)
            {
                BossHealth.deadPlayers += 1;
                healthbar.value = healthLeft();
                StartCoroutine(death());
                gameObject.SetActive(false);
            }
        }
    }
    IEnumerator death()
    {

         Instantiate(deathObject,
                     new Vector3(transform.position.x, transform.position.y, transform.position.z)
                     , Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z));
        yield return new WaitForSeconds(1);
    }

    float healthLeft()
    {
        return Playerhealth / dom;
    }

}
