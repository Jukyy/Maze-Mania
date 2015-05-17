using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using AssemblyCSharp;

public class Check_pause : MonoBehaviour {

	public Canvas pause_canvas;
	private Canvas _pause_canvas;

	private float pause_begin_time;
	private float pause_end_time;

	private bool toggle;

	// Use this for initialization
	void Start () {
		pause_begin_time = 0.0f;
		pause_end_time = 0.0f;
		AplicationModel.pause_time = pause_end_time - pause_begin_time;
		toggle = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape)){
			if(toggle){
				pause_begin_time = Time.fixedTime;
				AplicationModel.is_paused=true;
				_pause_canvas = Instantiate(pause_canvas) as Canvas;
				toggle= !toggle;
			}
			else {
				pause_end_time = Time.fixedTime;
				AplicationModel.pause_time+=pause_end_time-pause_begin_time;
				Destroy(_pause_canvas);
				AplicationModel.is_paused=false;
				toggle= !toggle;
			}
		}
	}
}
