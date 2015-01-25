using UnityEngine;
using System.Collections;
using System.Diagnostics;

using System;
using System.IO;
using System.Text.RegularExpressions;

using AssemblyCSharp;

public class Read_file : MonoBehaviour {

	public Process generator = new Process();
	public GameObject corridor_start;
	public GameObject corridor_end;
	public GameObject corridor_straight;
	public GameObject corridor_t;
	public GameObject corridor_turn;
	public GameObject corridor_cross;
	public GameObject corridor_finish;

	public GameObject player;
	public GameObject maze_key;
	public GameObject finish_object;
	private GameObject temp_model;

	public Transform pos;
	public float width;
	public float height;
	public float key_height;
	public float finish_height;
	public float player_height;
	private string maze_size;

	void Start () {
		//yield WaitForSeconds (0.5);
		Wait (10.0f);
		float posx = pos.transform.position.x;
		float posz = pos.transform.position.z;
		maze_size = AplicationModel.maze_size.ToString ();

		//var fileName = "Assets\\Generator\\parser.txt";
		//var pars = File.CreateText(fileName);

		bool key, finish = false;

		generator.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
		generator.StartInfo.CreateNoWindow = true;
		generator.StartInfo.UseShellExecute = false;
		//generator.StartInfo.FileName = "Assets\\Generator\\MazeGenerator_2.0.exe";
		generator.StartInfo.FileName = "Generator\\MazeGenerator_2.0.exe";
		generator.StartInfo.Arguments = maze_size;
		generator.EnableRaisingEvents = true;
		generator.Start();
		generator.WaitForExit();

		//string[] templates = System.IO.File.ReadAllLines(@"Assets\\Generator\\maze.stf");
		string[] templates = System.IO.File.ReadAllLines(@"Generator\\maze.stf");
		System.IO.File.Delete (@"Generator\\maze.stf");

		foreach (string line in templates){
			key = false;
			//pars.WriteLine(line);
			string[] arguments = Regex.Split(line, ",");
			//pars.Write ("x = " + arguments[0]);
			//pars.Write (" y = " + arguments[1]);
			//pars.Write (" template_index = " + arguments[2]);
			//pars.Write (" template_rotaton = " + arguments[3]);
			if(arguments.Length==5){
				if(arguments[4].Equals("1")){
					key = true;
					//pars.Write(" KEY");
				}
					//Feature add-ons
			}
			//pars.WriteLine("");

			pos.position = new Vector3 (posx + float.Parse(arguments[0]) * width,
				                        height,
				                        posz + float.Parse(arguments[1]) * width);

			if(arguments[2]=="0"){
				pos.rotation = Quaternion.Euler (90.0f,
					                             float.Parse(arguments[3]) + 90.0f,
					                             0.0f);
				temp_model=Instantiate (corridor_start, pos.position, pos.rotation) as GameObject;
			}
			if(arguments[2]=="4"){
				pos.rotation = Quaternion.Euler (90.0f,
					                             float.Parse(arguments[3]) + 90.0f,
					                             0.0f);
				temp_model=Instantiate (corridor_end, pos.position, pos.rotation) as GameObject;
			}
			else if(arguments[2]=="5"){
				pos.rotation = Quaternion.Euler (90.0f,
					                             float.Parse(arguments[3]) + 180.0f,
					                             0.0f);
				temp_model=Instantiate (corridor_straight, pos.position, pos.rotation) as GameObject;
			}
			else if(arguments[2]=="6"){
				pos.rotation = Quaternion.Euler (90.0f,
					                             float.Parse(arguments[3]) + 180.0f,
					                             0.0f);
				temp_model=Instantiate (corridor_t, pos.position, pos.rotation) as GameObject;
			}
			else if(arguments[2]=="7"){
				pos.rotation = Quaternion.Euler (90.0f,
					                             float.Parse(arguments[3]) + 90.0f,
					                             0.0f);
				temp_model=Instantiate (corridor_turn, pos.position, pos.rotation) as GameObject;
			}
			else if(arguments[2]=="8"){
				pos.rotation = Quaternion.Euler (90.0f,
					                             float.Parse(arguments[3]),
					                             0.0f);
				temp_model=Instantiate (corridor_cross, pos.position, pos.rotation) as GameObject;
			}
			else if(arguments[2]=="9"){
				pos.rotation = Quaternion.Euler (90.0f,
					                             float.Parse(arguments[3]) + 90.0f,
					                             0.0f);
				temp_model=Instantiate (corridor_end, pos.position, pos.rotation) as GameObject;

				finish = true;
			}
			temp_model.AddComponent("MeshCollider");
			if(key){
				pos.position = new Vector3 (posx + float.Parse(arguments[0]) * width,
					                        key_height,
					                        posz + float.Parse(arguments[1]) * width);
				pos.rotation = Quaternion.Euler (0.0f, 0.0f, 0.0f);
				temp_model = Instantiate (maze_key, pos.position, pos.rotation) as GameObject;
			}
			if (finish){
				pos.position = new Vector3 (posx + float.Parse(arguments[0]) * width,
				                            finish_height,
				                            posz + float.Parse(arguments[1]) * width);
				pos.rotation = Quaternion.Euler (0.0f, 0.0f, 0.0f);
				temp_model= Instantiate(finish_object, pos.position, pos.rotation) as GameObject;
				finish = false;
			}
		}
		//pars.Close();

		pos.position = new Vector3 (0.0f, player_height, 0.0f);
		pos.rotation = Quaternion.Euler (0.0f, 90.0f, 0.0f);
		temp_model =Instantiate (player, pos.position, pos.rotation) as GameObject;
	}

	IEnumerator Wait(float seconds)
	{
		yield return new WaitForSeconds(seconds);
	}
}
