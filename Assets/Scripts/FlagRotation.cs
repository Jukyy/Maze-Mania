using UnityEngine;
using System.Collections;

public class FlagRotation : MonoBehaviour {

	public float rotation_speed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(0, rotation_speed * Time.deltaTime, 0);
	}
}
