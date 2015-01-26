using UnityEngine;
using System;
using System.Collections;
using System.IO;
using System.Text.RegularExpressions;
using AssemblyCSharp;

public class Finish_controller : MonoBehaviour {

	public float rotation_speed;
	private float time;
	private int i;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(0, rotation_speed * Time.deltaTime, 0);
	}

	void OnTriggerEnter(Collider other) {

		if (other.tag == "Player") {
			if(AplicationModel.key ==true){
				AplicationModel.end_time=Time.fixedTime;
				time = AplicationModel.end_time-AplicationModel.begin_time;
				i = (int)(time*100);
				time = (float)i;
				time = time / 100;
				AplicationModel.time= time;
				print(AplicationModel.time);



				Application.LoadLevel("Save_time");
				Destroy (gameObject);
			}
		}
		return;
	}
}
