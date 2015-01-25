using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using AssemblyCSharp;

public class Show_score_controller : MonoBehaviour {

	private string message;
	private Text show_score;

	// Use this for initialization
	void Start () {
		show_score = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		show_score.text = "Your time is: " + AplicationModel.time + " seconds";
	}
}
