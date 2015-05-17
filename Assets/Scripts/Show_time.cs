using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using AssemblyCSharp;

public class Show_time : MonoBehaviour {

	private string message;
	private Text show_time;
	private float time;
	
	// Use this for initialization
	void Start () {
		show_time = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		if (AplicationModel.is_paused == false) {
			time = Time.fixedTime - AplicationModel.begin_time - AplicationModel.pause_time;
			int i = (int)(time * 100);
			time = (float)i;
			time = time / 100;
			show_time.text = "Time: " + time;
		}
	}
}
