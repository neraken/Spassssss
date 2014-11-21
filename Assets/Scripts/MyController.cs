using UnityEngine;
using System.Collections;

public class MyController : MonoBehaviour {

	private static MyController myController;
	// Use this for initialization
	public static MyController Instance(){
		if (!myController) {
			myController = FindObjectOfType(typeof (MyController)) as MyController;
			
				}
		return myController;
	}

	public void FoundMe(){

	}
}
