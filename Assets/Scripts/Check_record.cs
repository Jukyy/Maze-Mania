using UnityEngine;
using System;
using System.Collections;
using System.IO;
using System.Text.RegularExpressions;
using AssemblyCSharp;

public class Check_record : MonoBehaviour {

	// Use this for initialization
	void Start () {
		int [] n = new int[5];
		float time = AplicationModel.time;

		string path = @"Maze Mania_Data\\hs.mhs";
		string [] temp;
		float [,] times = new float[5,3];
		int level;
		
		switch (AplicationModel.maze_size) {
		case AplicationModel.tiny_maze_size: {level=0; break;}
		case AplicationModel.small_maze_size: {level=1; break;}
		case AplicationModel.medium_maze_size: {level=2; break;}
		case AplicationModel.huge_maze_size: {level=3; break;}
		case AplicationModel.dyed_maze_size: {level=4; break;}
		default: {level=0; break;}
		}

		if(File.Exists(path)){
			string[] high_score = System.IO.File.ReadAllLines(path);
			System.IO.File.Delete (path);

			for(int i = 0; i < 5; i++){
				temp= Regex.Split(high_score[i], " ");
				times[i,0]=(float)Convert.ToDecimal(temp[0]);
				times[i,1]=(float)Convert.ToDecimal(temp[1]);
				n[i]=Convert.ToInt32(temp[2]);
			}

			var fileName = path;
			var hs = File.CreateText(fileName);

			if(times[level,0]>time || times[level,0]==0){
				times[level,0]=time;
				AplicationModel.is_record=true;
			}
			times[level,1]=(time+times[level,1]*n[level])/(n[level]+1);
			n[level]+=1;

			for(int k = 0; k < 5; k++){
				hs.WriteLine(times[k,0] + " " + times[k,1] + " " + n[k]);
			}
			hs.Close();
			
		}
		else{
			var fileName = path;
			var hs = File.CreateText(fileName);

			for(int k = 0; k < 5; k++){
				if(k==level){
					hs.WriteLine(time + " " + time + " " + 1);
				}
				else{
					hs.WriteLine("0 0 0");
				}
			}

			hs.Close();
			AplicationModel.is_record=true;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
