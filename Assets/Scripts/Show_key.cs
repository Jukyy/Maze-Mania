using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using AssemblyCSharp;

public class Show_key : MonoBehaviour {

	private string message;
	private Text show_key;
	
	// Use this for initialization
	void Start () {
		show_key = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		if (!AplicationModel.key) {
			show_key.text ="";
		}
		else {
			show_key.text="You got the key!";
		}
	}
}
