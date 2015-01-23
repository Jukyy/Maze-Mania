using UnityEngine;
using System.Collections;
using System.Diagnostics;

using System;
using System.IO;
using System.Text.RegularExpressions;

public class Read_file : MonoBehaviour {
	
	bool didnt_read=true;
	public Process generator = new Process();
	public GameObject corridor_start;
	public GameObject corridor_end;
	public GameObject corridor_straight;
	public GameObject corridor_t;
	public GameObject corridor_turn;
	public GameObject corridor_cross;
	public GameObject corridor_finish;

	public GameObject maze_key;
	private GameObject temp_model;

	public Texture finish_texture;

	public Transform pos;
	public float width;
	public float height;
	public string maze_size;

	void Start () {
		if (didnt_read) {
			float posx = pos.transform.position.x;
			float posz = pos.transform.position.z;

			var fileName = "Assets\\Generator\\parser.txt";
			var pars = File.CreateText(fileName);

			generator.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
			generator.StartInfo.CreateNoWindow = true;
			generator.StartInfo.UseShellExecute = false;
			generator.StartInfo.FileName = "Assets\\Generator\\MazeGenerator_2.0.exe";
			generator.StartInfo.Arguments = maze_size;
			generator.EnableRaisingEvents = true;
			generator.Start();
			generator.WaitForExit();

			string[] templates = System.IO.File.ReadAllLines(@"Assets\\Generator\\maze.stf");
			bool key = false;
			bool finish = false;
			foreach (string line in templates){
				key = false;
				finish = false;
				pars.WriteLine(line);
				string[] arguments = Regex.Split(line, ",");
				pars.Write ("x = " + arguments[0]);
				pars.Write (" y = " + arguments[1]);
				pars.Write (" template_index = " + arguments[2]);
				pars.Write (" template_rotaton = " + arguments[3]);
				if(arguments.Length==5){
					if(arguments[4].Equals("1")){
						key = true;
						pars.Write(" KEY");
					}
					//Feature add-ons
				}
				pars.WriteLine("");

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
				}
				temp_model.AddComponent("MeshCollider");
				if(key){
					//GameObject obj = Instantiate(maze_key) as GameObject;
					//obj.GetComponent<Rotator>().rotationPoint = temp_model.transform.position;
					//Vector3 objPos = temp_model.transform.position;
					//objPos.y -= 1;
					//obj.transform.position = objPos;
					//temp_model.renderer.material.color = Color.magenta;
					pos.rotation = Quaternion.Euler (0.0f, 0.0f, 0.0f);
					temp_model = Instantiate (maze_key, pos.position, pos.rotation) as GameObject;
				}
				if (finish){
					temp_model.renderer.material.color= Color.cyan;
					temp_model.renderer.material.SetTexture(1, finish_texture);
				}
			}
			pars.Close();

		}
		didnt_read = false;
	}

}
