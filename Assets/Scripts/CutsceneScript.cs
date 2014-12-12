using UnityEngine;
using System.Collections;

public class CutsceneScript : MonoBehaviour {

	public GameObject scene1;
	public GameObject scene2;
	public GameObject scene3;
	public GameObject scene4;
	public GameObject scene5;
	public GameObject scene6;
	public GameObject scene7;
	public GameObject scene8;
	public GameObject scene9;
	public GameObject scene10;
	public GameObject scene11;
	public int numScenes;

	public AudioClip disruptor;
	public AudioClip receiveOff;
	public AudioClip receiveOn;
	public AudioClip rustles;
	// Use this for initialization
	void Start () {
	}


	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			numScenes++;
			switch (numScenes)
			{
			case 1:
				Instantiate(scene1);
				audio.PlayOneShot(disruptor);
				break;
			case 2:

				Destroy(GameObject.Find("Scene1(Clone)"));
				Instantiate(scene2);
				break;
			case 3:
				Destroy(GameObject.Find("Scene2(Clone)"));
				audio.PlayOneShot(receiveOn);
				Instantiate(scene3);
				break;
			case 4:
				Destroy(GameObject.Find("Scene3(Clone)"));
				Instantiate(scene4);
				break;
			case 5:
				Destroy(GameObject.Find("Scene4(Clone)"));
				Instantiate(scene5);
				break;
			case 6:
				Destroy(GameObject.Find("Scene5(Clone)"));
				audio.PlayOneShot(rustles);
				Instantiate(scene6);
				break;
			case 7:
				Destroy(GameObject.Find("Scene6(Clone)"));
				Instantiate(scene7);
				break;
			case 8:
				Destroy(GameObject.Find("Scene7(Clone)"));
				Instantiate(scene8);
				break;
			case 9:
				Destroy(GameObject.Find("Scene8(Clone)"));
				Instantiate(scene9);
				break;
			case 10:
				Destroy(GameObject.Find("Scene9(Clone)"));
				audio.PlayOneShot(receiveOff);
				Instantiate(scene10);
				break;
			case 11:
				Destroy(GameObject.Find("Scene10(Clone)"));
				Instantiate(scene11);
				break;
			default:
				break;
			
			}
				}
		
	}
}
