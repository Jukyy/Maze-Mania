using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class Button_pick_size : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void clikcTiny(){
		AplicationModel.maze_size = AplicationModel.tiny_maze_size;
		Application.LoadLevel ("Loading");
	}

	public void clikcSmall(){
		AplicationModel.maze_size = AplicationModel.small_maze_size;
		Application.LoadLevel ("Loading");
	}

	public void clikcMedium(){
		AplicationModel.maze_size = AplicationModel.medium_maze_size;
		Application.LoadLevel ("Loading");
	}

	public void clikcHuge(){
		AplicationModel.maze_size = AplicationModel.huge_maze_size;
		Application.LoadLevel ("Loading");
	}

	public void clikcDontYouEvenDare(){
		AplicationModel.maze_size = AplicationModel.dyed_maze_size;
		Application.LoadLevel ("Loading");
	}
}
