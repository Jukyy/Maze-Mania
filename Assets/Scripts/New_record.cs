using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using AssemblyCSharp;

public class New_record : MonoBehaviour {

	private Text new_record;

	// Use this for initialization
	void Start () {
		new_record = GetComponent<Text>();

	}
	
	// Update is called once per frame
	void Update () {
		if (AplicationModel.is_record) {
			new_record.text = "New Record";
		} 
		else {
			new_record.text="";
		}
	}
}
