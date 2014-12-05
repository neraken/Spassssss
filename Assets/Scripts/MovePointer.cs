using UnityEngine;
using System.Collections;

public class MovePointer : MonoBehaviour {
	public int numMenuItems = 3;
	public int menuStartPosition = 1;
	private int menuCurrPosition;
	public const int STARTGAME = 1;
	public const int QUITGAME = 2;
	// Use this for initialization
	void Start () {
		menuCurrPosition = menuStartPosition;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.W) && menuCurrPosition > 1){
			transform.Translate(0.0f,1.6f,0.0f);
			menuCurrPosition--;
		}
		if (Input.GetKeyDown (KeyCode.S) && menuCurrPosition < numMenuItems) {
			transform.Translate(0.0f,-1.6f,0.0f);
			menuCurrPosition++;

		}
		if (Input.GetKeyDown (KeyCode.Return)) {
			switch(menuCurrPosition)
			{
			case STARTGAME:
				Application.LoadLevel(1);
				break;
			case QUITGAME:
				Application.Quit();
				break;
			default:
				break;

			}

				}
	}
}
