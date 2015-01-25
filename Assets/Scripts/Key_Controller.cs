using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class Key_Controller : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		rigidbody.transform.Rotate (0, 40 * Time.deltaTime, 0);
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Player") {
			AplicationModel.key =true;
			Destroy (gameObject);
		}
		return;
	}
}
