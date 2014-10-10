using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour
{
	public GameObject hazard;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;

	public int power;
	public int astroidHealth;
	public int playerLives;
	public int bombCount;
	public int abilityCharge;
	
	public GUIText lifeText;
	
	public GUIText bombText;

	public GUIText scoreText;
	public GUIText restartText;
	public GUIText gameOverText;
	public GUIText abilityText;
	
	private bool gameOver;
	private bool restart;
	private int score;

	
	public GameObject engines_enemy;
	private GameObject[] spawners;
	private List <GameObject> Enemy;

	private bool startSpawn;
	
	void Start ()
	{
		gameOver = false;
		restart = false;
		restartText.text = "";
		gameOverText.text = "";
		abilityCharge = 100;
		lifeText.text = "life:" + playerLives;
		bombText.text = "bomb:" + bombCount;
		abilityText.text = "Ability:" + abilityCharge + "%";
		score = 0;
		UpdateScore ();
		//StartCoroutine (SpawnWaves ());
		startSpawn = false;

		spawners = GameObject.FindGameObjectsWithTag ("Spawn");
		//sort array into list
		//linq 
		//http://stackoverflow.com/questions/722868/sorting-a-list-using-lambda-linq-to-objects
		InvokeRepeating ("SpawnTimeTable",1,1);
		Enemy = new List<GameObject> ();
	}
	
	void Update ()
	{
		if (abilityCharge < 100) {
			++abilityCharge;
				}
		if(Input.GetKeyDown (KeyCode.Y))
		   {
			startSpawn = true;
		}
		if (restart)
		{
			if (Input.GetKeyDown (KeyCode.R))
			{
				Application.LoadLevel (Application.loadedLevel);
			}
		}
		abilityText.text = "ability:" + abilityCharge;
		bombText.text = "bomb:" + bombCount;
		lifeText.text = "life:" + playerLives;

	}

	void SpawnTimeTable(){
		if (startSpawn) {
						GameObject spawn = spawners [Random.Range (0, spawners.Length)];
						GameObject clone = Instantiate (engines_enemy, spawn.transform.position, Quaternion.identity) as GameObject;
						clone.name = "Enemy - " + Time.time.ToString ();
						Enemy.Add (clone);
				}

	}
//	IEnumerator SpawnWaves ()
//	{
//		yield return new WaitForSeconds (startWait);
//		while (true)
//		{
//			for (int i = 0; i < hazardCount; i++)
//			{
//				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
//				Quaternion spawnRotation = Quaternion.identity;
//				Instantiate (hazard, spawnPosition, spawnRotation);
//				yield return new WaitForSeconds (spawnWait);
//			}
//			yield return new WaitForSeconds (waveWait);
//			
//			if (gameOver)
//			{
//				restartText.text = "Press 'R' for Restart";
//				restart = true;
//				break;
//			}
//		}
//	}
	
	public void AddScore (int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();
	}
	
	void UpdateScore ()
	{
		scoreText.text = "Score: " + score;
	}
	
	public void GameOver ()
	{
		gameOverText.text = "Game Over!";
		gameOver = true;
	}

	public void playerDestroyed()
	{
		playerLives = playerLives -1;
		lifeText.text = "Life:" + playerLives;
		if(playerLives >0){
			
			GameOver ();
		}
		}

	public void bombUsed(){
		
		bombCount = bombCount -1;
		bombText.text = "bomb:" + bombCount;
	}
	public void abilityUsed(){
		if (abilityCharge == 100) {
			abilityCharge = 0;
			//use ability
				}
		}

}