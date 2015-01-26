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
			
			if(AplicationModel.maze_size == AplicationModel.tiny_maze_size){
				if(times[0,0]>time){
					times[0,0]=time;
					AplicationModel.is_record=true;
				}
				times[0,1]=(time+times[0,1]*n[0])/(n[0]+1);
				n[0]+=1;
			}
			else if(AplicationModel.maze_size == AplicationModel.small_maze_size){
				if(times[1,0]>time){
					times[1,0]=time;
					AplicationModel.is_record=true;
				}
				times[1,1]=(time+times[1,1]*n[1])/(n[1]+1);
				n[1]+=1;
			}
			else if(AplicationModel.maze_size == AplicationModel.medium_maze_size){
				if(times[2,0]>time){
					times[2,0]=time;
					AplicationModel.is_record=true;
				}
				times[2,1]=(time+times[2,1]*n[2])/(n[2]+1);
				n[2]+=1;
			}
			else if(AplicationModel.maze_size == AplicationModel.huge_maze_size){
				if(times[3,0]>time){
					times[3,0]=time;
					AplicationModel.is_record=true;
				}
				times[3,1]=(time+times[3,1]*n[3])/(n[3]+1);
				n[3]+=1;
			}
			else if(AplicationModel.maze_size == AplicationModel.dyed_maze_size){
				if(times[4,0]>time){
					times[4,0]=time;
					AplicationModel.is_record=true;
				}
				times[4,1]=(time+times[4,1]*n[0])/(n[4]+1);
				n[4]+=1;
			}
			for(int k = 0; k < 5; k++){
				hs.WriteLine(times[k,0] + " " + times[k,1] + " " + n[k]);
			}
			hs.Close();
			
		}
		else{
			var fileName = path;
			var hs = File.CreateText(fileName);
			
			if(AplicationModel.maze_size == AplicationModel.tiny_maze_size){
				hs.WriteLine(time + " " + time + " " + 1);
			}
			else{
				hs.WriteLine("0 0 0");
			}
			if(AplicationModel.maze_size == AplicationModel.small_maze_size){
				hs.WriteLine(time + " " + time + " " + 1);
			}
			else{
				hs.WriteLine("0 0 0");
			}
			if(AplicationModel.maze_size == AplicationModel.medium_maze_size){
				hs.WriteLine(time + " " + time + " " + 1);
			}
			else{
				hs.WriteLine("0 0 0");
			}
			if(AplicationModel.maze_size == AplicationModel.huge_maze_size){
				hs.WriteLine(time + " " + time + " " + 1);
			}
			else{
				hs.WriteLine("0 0 0");
			}
			if(AplicationModel.maze_size == AplicationModel.dyed_maze_size){
				hs.WriteLine(time + " " + time + " " + 1);
			}
			else{
				hs.WriteLine("0 0 0");
			}

			hs.Close();
			AplicationModel.is_record=true;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
