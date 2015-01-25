using UnityEngine;
using System.Collections;

public class Button_return : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ClickReturn(){
		Application.LoadLevel("Menu");
	}
}
