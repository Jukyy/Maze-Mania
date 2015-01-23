using UnityEngine;
using System.Collections;

public class Key_Controller : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		rigidbody.transform.Rotate (0, 40 * Time.deltaTime, 0);
	}
}
