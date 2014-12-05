using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;

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
	public int bombStrength = 100;
	public GameObject bombExplosion;
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
	private bool paused;
	
	public GameObject playerShip;
	//public GameObject enemyPrefab;
	private GameObject[] spawners;
	private List <GameObject> Enemy;
	
	public GUIStyle customButton;
	public Texture2D bgImage; 
	public Texture2D startBtnImg;
	public Texture2D quitBtnImg;	
	private bool startSpawn;

	public TextAsset EnemySpawn;
	private EnemyQueue[] enemySpawnAray;
	private float levelTimeEllapsed = 0.0f;
	private int enemySpawnCount = 0;
	private int count = 0;
	void OnGUI () {
		
		// Make a background box
		
		// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
		if (gameOver) {
			GUI.BeginGroup (new Rect (0, 0, Screen.width, Screen.height));
			GUI.Box (new Rect (0, 0, Screen.width, Screen.height), bgImage);
			GUI.Box (new Rect (0, 0, Screen.width, Screen.height), "#␣Rekt");
			if (GUI.Button (new Rect (Screen.width / 2 - 50, Screen.height / 2 - 50, 100, 20), "Start", customButton)) {
				Application.LoadLevel (0);
			}
			
			// Make the second button.
			if (GUI.Button (new Rect (Screen.width / 2 - 50, Screen.height / 2 - 25, 100, 20), "Quit", customButton)) {	
				//this works. but Quit() is ignored in the editor/web player
				Application.Quit ();
			}
			
			GUI.EndGroup ();	
		}
		
		
	}
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
		
		
				Instantiate (playerShip);
		
				spawners = GameObject.FindGameObjectsWithTag ("Spawn");
				//sort array into list
				//linq 
				//http://stackoverflow.com/questions/722868/sorting-a-list-using-lambda-linq-to-objects
				InvokeRepeating ("SpawnTimeTable", 1, 1);
				Enemy = new List<GameObject> ();

				JSONObject jo = new JSONObject (EnemySpawn.text);
				JSONArray ja = jo.getJSONArray ("Queue");
				enemySpawnAray = new EnemyQueue [ja.length()];
				for (int i = 0; i < enemySpawnAray.Length; i++) {
			enemySpawnAray [i] = new EnemyQueue (ja.getJSONObject(i).getString ("pattern"), ja.getJSONObject(i).getString ("enemy"), ja.getJSONObject(i).getString ("path"), ja.getJSONObject(i).getDouble ("time"));		
				}

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
		if (Input.GetKeyDown (KeyCode.P)) {
			if(paused){
				Time.timeScale = 1;
				paused = false;
			}else{
				Time.timeScale = 0;
				paused = true;
			}
		}
		if (restart)
		{
			if (Input.GetKeyDown (KeyCode.R))
			{
				Instantiate(playerShip);
				restart=false;
				//Application.LoadLevel (Application.loadedLevel);
			}
		}
		abilityText.text = "ability:" + abilityCharge;
		bombText.text = "bomb:" + bombCount;
		if (playerLives > -1) {
			lifeText.text = "life:" + playerLives;
		} else {
			lifeText.text = "life:0";
			
		}


		//spawn based on json
		if (enemySpawnCount < enemySpawnAray.Length) {
						if (enemySpawnAray [enemySpawnCount].time < levelTimeEllapsed) {

								//Debug.Log (enemySpawnAray [enemySpawnCount].pattern);
				GameObject spawn = spawners [0];
				GameObject enemyPrefab = (GameObject) Resources.Load("prefabs/" + enemySpawnAray [enemySpawnCount].enemy); 
				GameObject clone = Instantiate (enemyPrefab, spawn.transform.position, Quaternion.Euler(90, 0, 0)) as GameObject;
				clone.name = "Enemy - " + Time.time.ToString ();
				iTween.MoveTo(clone, iTween.Hash("path", iTweenPath.GetPath(enemySpawnAray [enemySpawnCount].path), "speed", 1));
				TextAsset textAsset = (TextAsset) Resources.Load("patterns/" + enemySpawnAray [enemySpawnCount].pattern);
				//Debug.Log (bulletPattern.text);
				clone.GetComponent<Pixelnest.BulletML.BulletSourceScript>().xmlFile = textAsset;
								enemySpawnCount += 1;
						} else {
								levelTimeEllapsed += Time.deltaTime;
						}
		}
		else{
				Debug.Log ("End of Level");
			}
	}
	
	void SpawnTimeTable(){
		if (startSpawn) {
			GameObject spawn = spawners [0];
			//GameObject clone = Instantiate (enemyPrefab, spawn.transform.position, Quaternion.Euler(90, 0, 0)) as GameObject;
			//GameObject clone = Instantiate (enemyPrefab) as GameObject;
			//clone.name = "Enemy - " + Time.time.ToString ();
//			if(count % 2 == 0){
//				iTween.MoveTo(clone, iTween.Hash("path", iTweenPath.GetPath("New Path 2"), "speed", 5));
//			}
//			else{
//				iTween.MoveTo(clone, iTween.Hash("path", iTweenPath.GetPath("New Path 1"), "speed", 5));
//			}
//			//clone.GetComponent<Pixelnest.BulletML.BulletSourceScript>().xmlFile = bulletFile;
//			Enemy.Add (clone);
//		}
//		count++;
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
		}
	
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
		if(playerLives <0){
			
			GameOver ();
		}else{
			restart = true;
		}
	}
	
	public void bombUsed(){
		if (bombCount > 0) {
			Debug.Log ("bomb used");
			GameObject[] everything = GameObject.FindGameObjectsWithTag ("Enemy");
			for (int i = 0; i < everything.Length; i++) {
				Instantiate (bombExplosion, everything [i].transform.position, everything [i].transform.rotation);
				enemy e = (enemy) everything[i].GetComponent(typeof(enemy));
				e.doDmg(10);
			}
			GameObject[] bullets = GameObject.FindGameObjectsWithTag("enemy");
			for(int i = 0; i < bullets.Length; i++){
				Instantiate (bombExplosion, bullets [i].transform.position, bullets [i].transform.rotation);
				Destroy (bullets [i]);
			}
			bombCount = bombCount -1;
			bombText.text = "bomb:" + bombCount;
		}
		
	}
	public void abilityUsed(){
		if (abilityCharge == 100) {
			abilityCharge = 0;
			//use ability
		}
	}
	
}