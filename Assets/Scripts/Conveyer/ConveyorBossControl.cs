using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ConveyorBossControl : MonoBehaviour {
	public ConveyorController conveyor;
	public GameObject[] obPreFabs;
	public GameObject[] playerFabs;
	public float speed = 6;
	public int frameDelay = 100;
	private int BossPNum = 2;
	private Obstacle currentObstacle;
	private int frameCt = 0;
    public Text text;
	public List<GameObject> players;
	public System.Predicate<GameObject> isDisabled = IsEnabled;
    private float pause = 1.0f; 

	private static bool IsEnabled(GameObject obj)
	{
		return !obj.activeSelf;
	}

    // Use this for initialization
    void Start () {
		GlobalControl.AddPlayer (1);
		GlobalControl.AddPlayer (2);
		for (int i = 1; i <= GlobalControl.NumPlayers; i++) {
			if (PlayerState.playerType [i] == PlayerType.CHEF) {
				BossPNum = i;
			} else {
				var player = Instantiate (playerFabs [0]);
				player.transform.position += new Vector3 (i, 0, 0);
				player.GetComponent<ConveyerPlayerMovement> ().playerNum = i;
				player.GetComponent<AffectedByConveyor> ().conveyor = GetComponent<ConveyorController> ();
				players.Add (player);
			}

		}
		//
		//GlobalControl.AddPlayer (2);
		currentObstacle = Instantiate (obPreFabs[Random.Range(0,obPreFabs.Length)]).GetComponent<Obstacle>();
		currentObstacle.GetComponent<AffectedByConveyor> ().conveyor = conveyor;
		currentObstacle.transform.position = new Vector3(0, 7,0);

        StartCoroutine(GameTimer(60));
    }

    // Update is called once per frame
    void Update()
    {
		if (players.TrueForAll (isDisabled)) {
            ChangeScene("End_Screen");
            Debug.Log ("Game Over");
		}
        frameCt++;
        if (currentObstacle != null)
        {

            currentObstacle.transform.position += new Vector3(GlobalControl.GetHorizontal(BossPNum) * 0.05f * speed, 0, 0);
            //Debug.Log ("Updating " + Input.GetButton ("X_P1"));
			if (GlobalControl.GetButtonA(BossPNum))
            {
                Debug.Log("Pressed");
                currentObstacle.GetComponent<Obstacle>().setActive(conveyor);
                currentObstacle = null;
                frameCt = 0;

            }
        }
        else
        {
            if (frameCt > frameDelay)
            {
                currentObstacle = Instantiate(obPreFabs[Random.Range(0, obPreFabs.Length)]).GetComponent<Obstacle>();
                currentObstacle.GetComponent<AffectedByConveyor>().conveyor = conveyor;
                currentObstacle.transform.position = new Vector3(0, 7, 0);
                frameCt = 0;
            }
        }
    }

    private IEnumerator GameTimer(float seconds)
    {
        for (float i = seconds; i >= 0; i -= 1f)
        {
            text.text = "Time Left: " + Mathf.Round(i) + "    ";
            yield return new WaitForSeconds(1);
        }
        ChangeScene("End_Screen");
    }

    public static void ChangeScene (string levelName)
    {
        Debug.Log("Time Up");
        SceneManager.LoadScene(levelName);
    }


}
