using UnityEngine;
using System.Collections;

public class testspawn : MonoBehaviour {

	public float spawnRate = 1.0f;
	private float count = 0.0f;
	public GameObject enemy;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(count > spawnRate){
			Instantiate(enemy);
			count = 0.0f;
		}
		count += Time.deltaTime;
	}
}
