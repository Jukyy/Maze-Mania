using UnityEngine;
using System.Collections;
using System.Timers;

public class Loading_controller : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//Wait();
		Application.LoadLevel ("Labyrinth");

	}
	
	// Update is called once per frame
	void Update () {

		//Application.LoadLevel ("Labyrinth");
	}

	/*IEnumerator Wait()
	{
		Application.LoadLevel ("Labyrinth");

	}*/
}
