using UnityEngine;
using System.Collections;

public class NewStartMenu : MonoBehaviour {

	public GameObject pointer;
	public float xCordinate;
	public float yCordinate;
	private GameObject	tmpPointer;
	private Vector3 pointerPosition;
	//private float currMenuPosition;
	private Quaternion defaultQuat;
	// Use this for initialization
	void Start () {
		defaultQuat = new Quaternion (0,0,0,0);
		//currMenuPosition = 1;
		pointerPosition = new Vector3 (xCordinate,yCordinate,0);
		tmpPointer = (GameObject) Instantiate (pointer,pointerPosition,defaultQuat);
	}
	
	// Update is called once per frame
	void Update () {
//		if (Input.GetKeyDown (KeyCode.A)) {
//			Destroy(tmpPointer);
//			
//				}
//		if(Input.GetKeyDown (KeyCode.UpArrow) ){
//			Destroy(tmpPointer);
//			
//			currMenuPosition +=1;
//			pointerPosition = new Vector3 (0,currMenuPosition,0);
//			tmpPointer = (GameObject) Instantiate (pointer,pointerPosition, defaultQuat);
//			//Destroy (tmpPointer);
//		}
	}
}
